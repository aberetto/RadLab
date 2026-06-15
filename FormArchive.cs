using System.Data;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using static RadLab.ClassMonitoring;
using static RadLab.ClassDistribution;
using static RadLab.ClassDB;
using static RadLab.ClassMonitoring.ChartMonitoring;
using static RadLab.ClassMain;
using static RadLab.ClassDevice;

namespace RadLab
{
    public partial class FormArchive : Form
    {
        readonly ChartMonitoring ChartMonitoring;
        readonly ChartDistribution ChartDistribution;
        readonly Filter FilterDistr = new(0);
        DateTime PrevData = DateTime.MinValue;

        public FormArchive()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            ChartMonitoring = new()
            {
                chart = chartCPS,
                IsArchive = true
            };
            ChartDistribution = new()
            {
                chart = chartDistribution
            };

            // Apply localization on form creation
            ApplyLocalization();
        }

        private void FormArchive_Load(object sender, EventArgs e)
        {
            FormResize();

            ChartMonitoring.Initialize();
            ChartDistribution.Initialize();

            ChartMonitoring.chart.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            ChartMonitoring.chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            ChartMonitoring.chart.Series[0].Enabled = true;
            ChartMonitoring.chart.Series[1].Enabled = true;
            FillChartMonitoring();
            FormResize();
        }

        private void FillChartMonitoring()
        {
            ChartMonitoring.StartDateTime = DateStartPicker.Value.Date;
            ChartMonitoring.EndDateTime = DateStartPicker.Value.Date.AddDays(1);

            LoadFromArchive(ChartMonitoring.chart, ChartMonitoring.StartDateTime, ChartMonitoring.EndDateTime);
            ChartMonitoring.AutoScaleY();
            DataPoint? Dp = ChartMonitoring.chart.Series["CurrentCPS"].Points.LastOrDefault();
            DataPoint? Sp = ChartMonitoring.chart.Series["CurrentCPS"].Points.FirstOrDefault();
            if (Dp != null && Sp != null)
            {
                if (PrevData != ChartMonitoring.StartDateTime)
                {
                    DateTime ViewMinimum = DateTime.FromOADate(Sp.XValue);
                    DateTime ViewMaximum = DateTime.FromOADate(Dp.XValue);
                    ChartMonitoring.DeltaXScaleView = (int)(ViewMaximum - ViewMinimum).TotalSeconds + 30;
                    PrevData = ChartMonitoring.StartDateTime;
                    ChartMonitoring.chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.ToEnd);
                }
            }
        }

        private void DateStartPicker_ValueChanged(object sender, EventArgs e)
        {
            FillChartMonitoring();
        }

        private void ButtonDistrRefresh_Click(object sender, EventArgs e)
        {
            FillChartMonitoring();
        }

        private void ButtonNavMinus_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Minus);
        }

        private void ButtonNavPlus_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Plus);
        }

        private void ButtonNavStart_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.ToStart);
        }

        private void ButtonNavLeft_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Left);
        }

        private void ButtonNavRight_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Right);
        }

        private void ButtonNavEnd_Click(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.ToEnd);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ChartMonitoring.SelectionChanged)
            {
                ChartMonitoring.SelectionChanged = false;
                IEnumerable<DataPoint> PointValues = ChartMonitoring.chart.Series[0].Points.Where(point => point.XValue >= ChartMonitoring.SelectionStartDateTime.ToOADate() && point.XValue <= ChartMonitoring.SelectionEndDateTime.ToOADate());
                if (PointValues.Any())
                {
                    int Cnt = PointValues.Count();
                    FilterDistr.Clear();
                    FilterDistr.ReSize(Cnt);
                    foreach (DataPoint point in PointValues)
                    {
                        ClassDevice.PointsBuferT pointsBuffer = new() { CntPerSec = (uint)point.YValues[0], Time = DateTime.FromOADate(point.XValue) };
                        FilterDistr.AddValue(pointsBuffer);
                    }
                    ChartDistribution.chart.Series[0].Points.Clear();
                    ChartDistribution.chart.ChartAreas[0].AxisX.Minimum = -1;

                    uint MaxIndex2 = (uint)FilterDistr.MaxIndex + 2;
                    if (MaxIndex2 > 65535) MaxIndex2 = 65535;
                    if (MaxIndex2 < 10) MaxIndex2 = 10;
                    ChartDistribution.chart.ChartAreas[0].AxisX.Maximum = MaxIndex2;
                    double Interval = AxisAutoScale(FilterDistr.MinIndex, MaxIndex2, 20);
                    if (Interval < 1) { Interval = 1; }
                    ChartDistribution.chart.ChartAreas[0].AxisX.Interval = (int)Interval;
                    for (uint ch = FilterDistr.MinIndex; ch < MaxIndex2 + 1; ch++)
                    {
                        ChartDistribution.chart.Series[0].Points.AddXY(ch, FilterDistr.DistributionArray[ch]);
                    }
                    DistributionTimeFilter.Text = FilterDistr.Count().ToString();
                    double Variance = FilterDistr.GetVariance();
                    textBoxMean.Text = FilterDistr.GetAverage().ToString("F2");
                    textBoxVariance.Text = Variance.ToString("F2");
                    textBoxDistrSum.Text = FilterDistr.GetSum().ToString();
                    textBoxSigma.Text = Math.Sqrt(Variance).ToString("F2");
                    LabelStartTime.Text = ChartMonitoring.SelectionStartDateTime.ToString("HH:mm:ss");
                    LabelEndTime.Text = ChartMonitoring.SelectionEndDateTime.ToString("HH:mm:ss");
                }
            }
            ChartMonitoring.AutoScaleY();
        }

        private void FormArchive_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {
            int Board = 4;

            groupBox1.Width = groupBox4.Location.X - Board * 8; ;
            groupBox2.Width = groupBox1.Width;

            groupBox1.Height = (this.ClientSize.Height - groupBox1.Location.Y) / 2 - Board;
            ButtonNavStart.Location = new Point(ButtonNavStart.Location.X, groupBox1.Height - ButtonNavStart.Height - Board);
            ButtonNavLeft.Location = new Point(ButtonNavLeft.Location.X, groupBox1.Height - ButtonNavLeft.Height - Board);
            ButtonNavMinus.Location = new Point(ButtonNavMinus.Location.X, groupBox1.Height - ButtonNavMinus.Height - Board);
            ButtonNavPlus.Location = new Point(ButtonNavPlus.Location.X, groupBox1.Height - ButtonNavPlus.Height - Board);
            ButtonNavRight.Location = new Point(ButtonNavRight.Location.X, groupBox1.Height - ButtonNavRight.Height - Board);
            ButtonNavEnd.Location = new Point(ButtonNavEnd.Location.X, groupBox1.Height - ButtonNavEnd.Height - Board);
            chartCPS.Height = ButtonNavStart.Location.Y - chartCPS.Location.Y;

            groupBox2.Location = new Point(groupBox2.Location.X, groupBox1.Location.Y + groupBox1.Height);
            groupBox2.Height = groupBox1.Height;
        }

        private void ButtonDistrExport_Click(object sender, EventArgs e)
        {
            Queue<PointsBuferT> BuferNow = FilterDistr.GetBufer();
            SaveFileDialog saveFileDialog1 = new()
            {
                Title = Localization.GetString("SaveCsvTitle"),
                DefaultExt = "csv",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var csv = new StringBuilder();
                    string time = "DateTime";
                    string cnt = "CntPerSec";
                    string line = $"{time};{cnt}";
                    csv.AppendLine(line);
                    while (BuferNow.Count > 0)
                    {
                        PointsBuferT point = BuferNow.Dequeue();
                        time = point.Time.ToString("yyyy.MM.dd HH:mm:ss");
                        cnt = point.CntPerSec.ToString();
                        line = $"{time};{cnt}";
                        csv.AppendLine(line);
                    }
                    File.WriteAllText(saveFileDialog1.FileName, csv.ToString());
                }
                catch
                {
                    MessageBox.Show(Localization.GetString("SaveCsvError"));
                }
            }
        }

        /// <summary>
        /// Applies localization to all translatable controls on the Archive form.
        /// Uses "FA_" prefix keys to avoid collisions with FormMain control names.
        /// </summary>
        private void ApplyLocalization()
        {
            groupBox1.Text = Localization.GetText("FA_groupBox1");
            groupBox2.Text = Localization.GetText("FA_groupBox2");
            groupBox3.Text = Localization.GetText("FA_groupBox3");
            groupBox4.Text = Localization.GetText("FA_groupBox4");

            label1.Text = Localization.GetText("FA_label1");
            label2.Text = Localization.GetText("FA_label2");
            label3.Text = Localization.GetText("FA_label3");
            label6.Text = Localization.GetText("FA_label6");
            label12.Text = Localization.GetText("FA_label12");
            label15.Text = Localization.GetText("FA_label15");
            label16.Text = Localization.GetText("FA_label16");
            label17.Text = Localization.GetText("FA_label17");
            label18.Text = Localization.GetText("FA_label18");
            label31.Text = Localization.GetText("FA_label31");

            ButtonDistrExport.Text = Localization.GetText("FA_ButtonDistrExport");
            ButtonDistrRefresh.Text = Localization.GetText("FA_ButtonDistrRefresh");
        }
    }
}