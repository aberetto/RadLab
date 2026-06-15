using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.EntityFrameworkCore;

namespace RadLab
{
    internal class ClassDB
    {

        public class MainConfig
        {
            public int Id { get; set; }
            public uint FilterCPS { get; set; } = 100;
            public uint FilterDistr { get; set; } = 100;
            public float Coeff1 { get; set; } = 0.02F;
            public float Coeff2 { get; set; } = 0.2F;
            public string Language { get; set; } = "ru";
    }

        public class ApplicationDbContext : DbContext
        {
            public DbSet<MainConfig> Settings { get; set; } = null!;

            public ApplicationDbContext()
            {
                Database.EnsureCreated();
                // Add Language column if it doesn't exist (migration for existing databases)
                try
                {
                    Database.ExecuteSqlRaw("ALTER TABLE Settings ADD COLUMN Language TEXT NOT NULL DEFAULT 'ru'");
                }
                catch { /* Column already exists, ignore */ }
                
                int c = (from s in Settings
                         select s.Id).Count();
                if (c == 0)
                {
                    MainConfig DefaultSettings = new();
                    Settings.Add(DefaultSettings);
                    SaveChanges();
                    MessageBox.Show(Localization.GetString("DefaultSettingsLoaded"));
                }
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=settings.db");
                optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }

        public class ArchiveDB
        {
            public ConcurrentQueue<ArchiveT.MonitoringData> ArchiveMonitoringBuffer { get; set; } = new();            
            public bool NeedToSave = false;

            public void ArchiveThread()
            {
                Thread.CurrentThread.Name = "ArchiveThread";
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    try
                    {
                        if (NeedToSave)
                        {
                            SaveArchive(ArchiveMonitoringBuffer);
                            NeedToSave = false;
                        }
                    }
                    catch { }
                    Thread.Sleep(10);
                }
            }
        }

        public static void SaveConfig(MainConfig t)
        {
            using (ApplicationDbContext db = new())
            {
                db.Settings.Update(t);
                db.SaveChanges();
            }
        }
        public static MainConfig LoadConfig()
        {
            using (ApplicationDbContext db = new())
            {
                MainConfig Config = (from s in db.Settings select s).First();
                return Config;
            }
        }

        public static void SaveArchive(ConcurrentQueue<ArchiveT.MonitoringData> ArchiveBufer)
        {
            using ArchiveT.ArchiveDbContext arch = new();
            while (!ArchiveBufer.IsEmpty)
            {
                ArchiveBufer.TryDequeue(out ArchiveT.MonitoringData? Rec);
                if (Rec != null)
                {
                    arch.MonitoringDatas.Update(Rec);
                }
            }
            arch.SaveChanges();
            arch.Dispose();
        }

        public class ArchiveT
        {
            [Index("Time")]
            public class MonitoringData
            {
                public uint Id { get; set; }
                public long Time { get; set; }
                public uint CurrentCPS { get; set; }   
                public float FilteredCPS { get; set; }
            }

            public class ArchiveDbContext : DbContext
            {
                public DbSet<MonitoringData> MonitoringDatas { get; set; } = null!;                
                public ArchiveDbContext()
                {
                    Database.EnsureCreated();
                }
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlite("Data Source=archive.db");
                    optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information);
                }
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<MonitoringData>().Property(p => p.Time).HasColumnType("integer(8)");
                    modelBuilder.Entity<MonitoringData>().Property(p => p.CurrentCPS).HasColumnType("integer(4)");
                    modelBuilder.Entity<MonitoringData>().Property(p => p.FilteredCPS).HasColumnType("real");
                }
            }
        }

        public class MonitoringPoint
        {
            public uint CurrentCPS { get; set; }
            public float FilteredCPS { get; set; }
        }

        public static void AddPointToArchiveBuffer(DateTime t, ConcurrentQueue<ArchiveT.MonitoringData> ArchiveBufer, MonitoringPoint point)
        {
            ArchiveT.MonitoringData Data = new()
            {
                Time = t.ToFileTime(),
                CurrentCPS = point.CurrentCPS,
                FilteredCPS = point.FilteredCPS
            };
            ArchiveBufer.Enqueue(Data);
        }

        public static DateTime FindFirstRecord()
        {
            using (ArchiveT.ArchiveDbContext arch = new())
            {
                DateTime Time = DateTime.FromFileTime((from q in arch.MonitoringDatas
                                                       orderby q.Time
                                                       select q.Time).FirstOrDefault());
                return Time;
            }
        }

        public static DateTime FindLastRecord()
        {
            using (ArchiveT.ArchiveDbContext arch = new())
            {
                DateTime Time = DateTime.FromFileTime((from q in arch.MonitoringDatas
                                                       orderby q.Time descending
                                                       select q.Time).FirstOrDefault());
                return Time;
            }
        }

        public static void LoadFromArchive(Chart chart, DateTime StartTime, DateTime EndTime)
        {
            long lStartTime = StartTime.ToFileTime();
            long lEndTime = EndTime.ToFileTime();

            using (ArchiveT.ArchiveDbContext arch = new())
            {
                var ArchMaed = (from q in arch.MonitoringDatas
                                where q.Time >= lStartTime && q.Time <= lEndTime
                                select new
                                {
                                    q.Time,
                                    q.CurrentCPS,
                                    q.FilteredCPS
                                });
                DateTime TimePrev = DateTime.Now;
                chart.Series["CurrentCPS"].Points.Clear();
                chart.Series["FilteredCPS"].Points.Clear();
                foreach (var s in ArchMaed)
                {
                    DateTime pTime = DateTime.FromFileTime(s.Time);
                    if (TimePrev.AddSeconds(2) < pTime)
                    {
                        DataPoint dataPoint = new();
                        dataPoint.SetValueXY(TimePrev.AddSeconds(2), 0);
                        dataPoint.IsEmpty = true;
                        chart.Series["CurrentCPS"].Points.Add(dataPoint);
                        chart.Series["FilteredCPS"].Points.Add(dataPoint);
                    }
                    chart.Series["CurrentCPS"].Points.AddXY(pTime, s.CurrentCPS);
                    chart.Series["FilteredCPS"].Points.AddXY(pTime, s.FilteredCPS);
                    TimePrev = pTime;
                }
                DataPoint dataPoint2 = new();
                dataPoint2.SetValueXY(TimePrev.AddSeconds(1), 0);
                dataPoint2.IsEmpty = true;
                chart.Series["CurrentCPS"].Points.Add(dataPoint2);
                chart.Series["FilteredCPS"].Points.Add(dataPoint2);
            }
        }

        public static MonitoringPoint? GetPointFromArchive(DateTime Time)
        {
            using (ArchiveT.ArchiveDbContext arch = new())
            {
                double SearchInterval = 1;
                DateTime NewStartTime = Time.AddSeconds(-SearchInterval);
                DateTime NewEndTime = Time.AddSeconds(SearchInterval);
                long lTime = Time.ToFileTime();
                long lNewStartTime = NewStartTime.ToFileTime();
                long lNewEndTime = NewEndTime.ToFileTime();
                var Val1 = (

                    from q in arch.MonitoringDatas
                    where q.Time >= lNewStartTime && q.Time <= lTime
                    orderby q.Time descending
                    select new
                    {
                        q.Time,
                        q.CurrentCPS,
                        q.FilteredCPS
                    }).FirstOrDefault();
                var Val2 = (

                    from q in arch.MonitoringDatas
                    where q.Time >= lTime && q.Time <= lNewEndTime
                    orderby q.Time
                    select new
                    {
                        q.Time,
                        q.CurrentCPS,
                        q.FilteredCPS
                    }).FirstOrDefault();

                if (Val1 == null && Val2 != null)
                {
                    Val1 = Val2;

                }
                else if (Val1 != null && Val2 != null)
                {
                    long LeftDiff = lTime - Val1.Time;
                    long RightDiff = Val2.Time - lTime;
                    if (RightDiff < LeftDiff)
                    {
                        Val1 = Val2;
                    }
                }
                if (Val1 != null)
                {
                    MonitoringPoint Result = new()
                    {
                        CurrentCPS = Val1.CurrentCPS,
                        FilteredCPS = Val1.FilteredCPS
                    };
                    return Result;
                }
            }
            return null;
        }
    }
}
