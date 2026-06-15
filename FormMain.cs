// dotnet publish /p:PublishProfile="Релиз минимум"

//using System;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
//using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RadLab.ClassDB;
using static RadLab.ClassDevice;
using static RadLab.ClassDistribution;
using static RadLab.ClassMain;
using static RadLab.ClassMonitoring;
using static RadLab.ClassMonitoring.ChartMonitoring;

namespace RadLab
{
    public partial class FormMain : Form
    {
        public SerialPortDetector Detector;
        private Button ButtonLanguage;
        private ToolTip toolTipConnectionStatus;
        readonly ChartMonitoring ChartMonitoring;
        readonly ChartDistribution ChartDistribution;
        Dictionary<string, string[]> PortNames = [];
        readonly ArchiveDB Archive;
        readonly Filter FilterCPSSimple = new(0);
        readonly Filter FilterCPS = new(0);
        readonly Filter FilterDistr = new(0);
        float Coeff1, Coeff2;
        bool StartSimpleCounter = false;
        readonly int MinSizeStdW = 520; //=505+16
        readonly int MinSizeStdH = 390; //330; //310;
        int PrevWidthStandart;// = 520;    //600;
        int PrevHeightStandart;// = 390;   //370;        

        int label1LocationX = 320;
        int label1LocationY = 110;   
        int LabelSimpleTimeLocationX = 345;
        int LabelSimpleTimeLocationY = 150; 
        int LabelSimpleAverageLocationX = 13;
        int LabelSimpleAverageLocationY = 150;  
        int label34LocationX = 10;
        int label34LocationY = 110;                        

        int PrevWidthExt = 1160;
        int PrevHeightExt = 714;
        readonly int MinSizeExtW = 1160;
        readonly int MinSizeExtH = 714;

        public FormMain()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            // Create and configure language toggle button
            ButtonLanguage = new Button
            {
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(450, 10),
                Name = "ButtonLanguage",
                Size = new Size(40, 27),
                Text = "En",
                UseVisualStyleBackColor = true
            };
            ButtonLanguage.Click += ButtonLanguage_Click;
            tabPage1.Controls.Add(ButtonLanguage);
            // ...

            toolTipConnectionStatus = new ToolTip();
            toolTipConnectionStatus.SetToolTip(PictureConnectionStatus, label33.Text);

            Detector = new SerialPortDetector("RadLabDetector");
            Archive = new();
            ChartMonitoring = new()
            {
                chart = chartCPS
            };
            ChartDistribution = new()
            {
                chart = chartDistribution
            };

            float ScaleX = this.AutoScaleDimensions.Width / 96F;
            float ScaleY = this.AutoScaleDimensions.Height / 96F;

            if (ScaleX < 0.5f || ScaleY < 0.5f || ScaleX > 2.5f || ScaleY > 2.5f)
            {
                ScaleX = 1.0f;
                ScaleY = 1.0f;
            }
            PrevWidthStandart = (int)(ScaleX * PrevWidthStandart);
            PrevHeightStandart = (int)(ScaleY * PrevHeightStandart);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ChartMonitoring.Initialize();
            //ChartMonitoring.chart.ChartAreas[0].CursorX.IsUserEnabled = false;
            //ChartMonitoring.chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            DateTime t = DateTime.Now;
            ChartMonitoring.StartDateTime = t.AddSeconds(-ChartMonitoring.DeltaXScaleView);
            ChartMonitoring.EndDateTime = t.AddSeconds(0);
            ChartMonitoring.chart.Series[0].Enabled = true;
            ChartMonitoring.chart.Series[1].Enabled = true;

            ChartDistribution.Initialize();
            ChartDistribution.chart.Series[0].Enabled = true;

            UpdatePortNames();
            FilterCPSSimple.ReSize(65535);

            MainConfig Config = LoadConfig();
            ushort FilterCPSValue = (ushort)Config.FilterCPS;
            ushort FilterDistrValue = (ushort)Config.FilterDistr;
            Coeff1 = Config.Coeff1;
            Coeff2 = Config.Coeff2;
            FilterCPS.ReSize(FilterCPSValue);
            FilterDistr.ReSize(FilterDistrValue);

            TextBoxTimeFilter.TextChanged -= TextBoxTimeFilter_TextChanged;
            TextBoxTimeDistribution.TextChanged -= TextBoxTimeDistribution_TextChanged;
            TextBoxCoeff1.TextChanged -= TextBoxCoeff1_TextChanged;
            TextBoxCoeff2.TextChanged -= TextBoxCoeff2_TextChanged;
            TextBoxTimeFilter.Text = FilterCPSValue.ToString();
            TextBoxTimeDistribution.Text = FilterDistrValue.ToString();
            TextBoxCoeff1.Text = Coeff1.ToString(new CultureInfo("en-US"));
            TextBoxCoeff2.Text = Coeff2.ToString(new CultureInfo("en-US"));
            TextBoxTimeFilter.TextChanged += TextBoxTimeFilter_TextChanged;
            TextBoxTimeDistribution.TextChanged += TextBoxTimeDistribution_TextChanged;
            TextBoxCoeff1.TextChanged += TextBoxCoeff1_TextChanged;
            TextBoxCoeff2.TextChanged += TextBoxCoeff2_TextChanged;

            Thread DeviceConnectThread = new(new ThreadStart(Detector.ConnectionThread));
            Thread DeviceReaderThread = new(new ThreadStart(Detector.PortReaderThread));
            DeviceConnectThread.Start();
            DeviceReaderThread.Start();
            Detector.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Detector.PacketRead);

            Detector.ReadyToConnect = true;
            Detector.lastPackedReceivedAt = DateTime.Now;
            if (!Detector.PortName.Equals(""))
            {
                Detector.NeedToConnect = true;
                Detector.Status = ConnectStatus.Connecting;
            }

            Thread ArchiveThread = new(new ThreadStart(Archive.ArchiveThread));
            ArchiveThread.Start();

            CheckFormMode();
            FormResize();
        }

        const int WM_HOTKEY = 0x0312;
        const int WM_DEVICECHANGE = 0x0219;
        const int DBT_DEVICEARRIVAL = 0x8000;                   // Новое устройство подключено и готово к использованию
        const int DBT_DEVICEREMOVECOMPLETE = 0x8004;            // Устройство отключено
        const int DBT_DEVNODES_CHANGED = 0x0007;                // Любое изменение в аппаратном профиле        
        const uint DBT_DEVTYP_PORT = 0x00000003;              // Тип устройства: serial, parallel

        [StructLayout(LayoutKind.Sequential)]
        struct DEV_BROADCAST_HDR
        {
            public uint dbcd_size;
            public uint dbcd_devicetype;
            public uint dbcd_reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        readonly struct DEV_BROADCAST_PORT_Fixed
        {
            readonly uint dbcp_size;
            readonly uint dbcp_devicetype;
            readonly uint dbcp_reserved;
        }

        // Отслеживаем подключение устройств
        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case WM_DEVICECHANGE:
                        var DevHdrPtr = Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                        DEV_BROADCAST_HDR DevHdr;
                        if (DevHdrPtr != null)
                        {
                            DevHdr = (DEV_BROADCAST_HDR)DevHdrPtr;
                            if (DevHdr.dbcd_devicetype == DBT_DEVTYP_PORT)
                            {
                                checked
                                {
                                    string? Msg = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt64() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
                                    if (m.WParam.ToInt64() == DBT_DEVICEREMOVECOMPLETE)
                                    {
                                        if (Detector.PortName.Equals(Msg))
                                        {
                                            Detector.Disconnect();
                                            Detector.Status = ConnectStatus.Disconnect;
                                        }
                                    }
                                }
                                UpdatePortNames();
                            }
                        }
                        break;
                }
            }
            catch { }
            base.WndProc(ref m);
        }

        private void UpdatePortNames()
        {
            PortNames = ClassMain.GetPortNames(true);
        }

        bool StopMonitoringFlag = false;
        private int TimePrev;
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (Detector.Status != ConnectStatus.Connect)
            {
                if (PortNames.Count > 0)
                {
                    string NewPortName = PortNames.FirstOrDefault().Key;
                    if (!Detector.PortName.Equals(NewPortName))
                    {
                        Detector.PortName = NewPortName;
                    }
                    Detector.NeedToConnect = true;
                    Detector.Connect();
                }
                else
                {
                    if (Detector.Status == ConnectStatus.Disconnect)
                    {
                        Detector.PortName = "";
                        Detector.NeedToConnect = false;
                    }
                }
            }
            if (Detector.StatusPrev != Detector.Status)
            {
                Detector.StatusPrev = Detector.Status;
                PictureConnectionStatus.Refresh();
            }

            DateTime t = DateTime.Now;
            int TimeNow = t.Second;
            if (TimeNow != TimePrev && !StopMonitoringFlag && Detector.Status == ConnectStatus.Connect)
            {
                TimePrev = TimeNow;
                ChartMonitoring.StartDateTime = t.AddSeconds(-ChartMonitoring.DeltaXScaleView);
                ChartMonitoring.EndDateTime = t.AddSeconds(0);
            }
            for (int i = 0; i < Detector.PointsBufer.Count; i++)
            {
                Detector.PointsBufer.TryDequeue(out PointsBuferT? point);

                // Отображение для упрощённого режима
                if (point != null && StartSimpleCounter && Detector.Status == ConnectStatus.Connect)
                {
                    FilterCPSSimple.AddValue(point);
                    ushort Time = FilterCPSSimple.Count();
                    double Avg = FilterCPSSimple.GetAverage();
                    double Variance = FilterCPSSimple.GetVariance();
//                    double Sigma = 2.0 * Math.Sqrt(Variance);
                    double Sigma = 1.0 * Math.Sqrt(Variance);
                    string StrAvg, StrErr;

                    // 3 значащих цифры:
                    if (Avg >= 100)
                    {
                        StrAvg = Avg.ToString("f0");
                        StrErr = Sigma.ToString("f0");
                    }
                    else if (Avg >= 10)
                    {
                        StrAvg = Avg.ToString("#0.#");
                        StrErr = Sigma.ToString("#0.#");
                    }
                    else if (Avg >= 1)
                    {
                        StrAvg = Avg.ToString("0.##");
                        StrErr = Sigma.ToString("0.##");
                    }
                    else
                    {
                        StrAvg = Avg.ToString("0.###");
                        StrErr = Sigma.ToString("0.###");
                    }
                    /*
                    // 4 значащих цифры:
                    if (Avg >= 1000)
                    {
                        StrAvg = Avg.ToString("f0");
                        StrErr = Sigma.ToString("f0");
                    }
                    else if (Avg >= 100)
                    {
                        StrAvg = Avg.ToString("##0.#");
                        StrErr = Sigma.ToString("##0.#");
                    }
                    else if (Avg >= 10)
                    {
                        StrAvg = Avg.ToString("#0.##");
                        StrErr = Sigma.ToString("#0.##");
                    }
                    else if (Avg >= 1)
                    {
                        StrAvg = Avg.ToString("0.###");
                        StrErr = Sigma.ToString("0.###");
                    }
                    else
                    {
                        StrAvg = Avg.ToString("0.####");
                        StrErr = Sigma.ToString("0.####");
                    }
                    */

                    if (Time < 4 /*|| Sigma >= Avg*/)
                    {
                        LabelSimpleAverage.Text = StrAvg;
                    }
                    else
                    {
                        LabelSimpleAverage.Text = StrAvg + " ± " + StrErr;
                    }
                    LabelSimpleTime.Text = Time.ToString();
                }


                //Расширенный режим
                if (point != null && !StopMonitoringFlag && Detector.Status == ConnectStatus.Connect)
                {
                    //CPS
                    // TEST point.CntPerSec = (point.CntPerSec / 10) * (uint)((double)t.Second * 0.05);
                    FilterCPS.AddValue(point);
                    float Avg = FilterCPS.GetAverage();
                    ChartMonitoring.chart.Series[0].Points.AddXY(point.Time, point.CntPerSec);
                    ChartMonitoring.chart.Series[1].Points.AddXY(point.Time, Avg);
                    if (ChartMonitoring.IsCurrentDateTime)
                    {


                        ChartMonitoring.StartDateTime = ChartMonitoring.EndDateTime.AddSeconds(-ChartMonitoring.DeltaXScaleView);
                        DataPoint? Dp = ChartMonitoring.chart.Series["CurrentCPS"].Points.FirstOrDefault();
                        if (Dp != null)
                        {
                            DateTime StartView = DateTime.FromOADate(Dp.XValue);
                            if (StartView > ChartMonitoring.StartDateTime)
                            {
                                ChartMonitoring.chart.ChartAreas[0].AxisX.Minimum = ChartMonitoring.StartDateTime.ToOADate();
                                ChartMonitoring.chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                            }
                            else
                            {
                                ChartMonitoring.chart.ChartAreas[0].AxisX.ScaleView.Zoom(ChartMonitoring.StartDateTime.ToOADate(), ChartMonitoring.EndDateTime.ToOADate());
                            }
                        }
                    }
                    ChartMonitoring.AutoScaleY();

                    MonitoringPoint? monitoringPoint = new()
                    {
                        CurrentCPS = point.CntPerSec,
                        FilteredCPS = Avg
                    };
                    AddPointToArchiveBuffer(t, Archive.ArchiveMonitoringBuffer, monitoringPoint);

//                    LabelCurrentTimeFilter.Text = FilterCPS.Count().ToString();// + "с";
                    LabelCurrentTimeFilter.Text = FilterCPS.Count().ToString();// + Localization.GetString("SecondsSuffix");
                    TextBoxCurrentCPS.Text = point.CntPerSec.ToString();
                    TextBoxAverageCPS.Text = Avg.ToString("F2");
                    TextBoxSumCPS.Text = FilterCPS.GetSum().ToString();
                    TextBoxResult1.Text = (Avg * Coeff1).ToString("F2");
                    TextBoxResult2.Text = (Avg * Coeff2).ToString("F2");

                    //Distribution
                    FilterDistr.AddValue(point);
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
//                    LabelDistributionTimeFilter.Text = FilterDistr.Count().ToString() + "с";
                    LabelDistributionTimeFilter.Text = FilterDistr.Count().ToString() + Localization.GetString("SecondsSuffix");
                    double Variance = FilterDistr.GetVariance();
                    textBoxMean.Text = FilterDistr.GetAverage().ToString("F2");
                    textBoxVariance.Text = Variance.ToString("F2");
                    textBoxDistrSum.Text = FilterDistr.GetSum().ToString();
                    textBoxSigma.Text = Math.Sqrt(Variance).ToString("F2");

                }
            }

            int TimeS = t.Second;
            if (TimeS % 10 == 0)
            {
                Archive.NeedToSave = true;
            }
        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (StopMonitoringFlag)
            {
                StopMonitoringFlag = false;
//                ButtonStartStop.Text = "СТОП";
                Localization.GetString("Stop");
            }
            else
            {
                FilterCPS.Clear();
                FilterDistr.Clear();
                StopMonitoringFlag = true;
//                ButtonStartStop.Text = "ПУСК";
                Localization.GetString("Start");
            }
        }

        private void TextBoxTimeFilter_TextChanged(object? sender, EventArgs e)
        {
            TextBoxTimeFilter.BackColor = Color.Yellow;
        }


        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }
            if (e.KeyChar == '.')
            {
                //can use .Contains, indexOf, etc.  I used count incase you want more than 1
                if(((TextBox) sender).Text.Count(s=>s=='.') == 1)
                {
                    e.Handled = true;
                }
            }
        }


        private void TextBoxTimeFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (ushort.TryParse(TextBoxTimeFilter.Text.ToString(), out ushort value) && value > 0)
                {
                    MainConfig Config = LoadConfig();
                    Config.FilterCPS = value;
                    SaveConfig(Config);
                    FilterCPS.ReSize((ushort)Config.FilterCPS);
                    TextBoxTimeFilter.BackColor = Color.White;
                }
                else
                {
                    TextBoxTimeFilter.BackColor = Color.Red;
                }
            }
        }

        private void TextBoxCoeff1_TextChanged(object? sender, EventArgs e)
        {
            TextBoxCoeff1.BackColor = Color.Yellow;
        }

        private void TextBoxCoeff2_TextChanged(object? sender, EventArgs e)
        {
            TextBoxCoeff2.BackColor = Color.Yellow;
        }

        private void TextBoxCoeff1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string FloatText = TextBoxCoeff1.Text.Replace(",", ".");
                if (float.TryParse(FloatText, NumberStyles.Float, new CultureInfo("en-US"), out float value) && value > 0)
                {
                    MainConfig Config = LoadConfig();
                    Config.Coeff1 = value;
                    SaveConfig(Config);
                    Coeff1 = Config.Coeff2;
                    TextBoxCoeff1.BackColor = Color.White;
                }
                else
                {
                    TextBoxCoeff1.BackColor = Color.Red;
                }
            }
        }

        private void TextBoxCoeff2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string FloatText = TextBoxCoeff2.Text.Replace(",", ".");
                if (float.TryParse(FloatText, NumberStyles.Float, new CultureInfo("en-US"), out float value) && value > 0)
                {
                    MainConfig Config = LoadConfig();
                    Config.Coeff2 = value;
                    SaveConfig(Config);
                    Coeff2 = Config.Coeff2;
                    TextBoxCoeff2.BackColor = Color.White;
                }
                else
                {
                    TextBoxCoeff2.BackColor = Color.Red;
                }
            }
        }

        private void TextBoxTimeDistribution_TextChanged(object? sender, EventArgs e)
        {
            TextBoxTimeDistribution.BackColor = Color.Yellow;
        }

        private void TextBoxTimeDistribution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (ushort.TryParse(TextBoxTimeDistribution.Text.ToString(), out ushort value) && value > 0)
                {
                    MainConfig Config = LoadConfig();
                    Config.FilterDistr = value;
                    SaveConfig(Config);
                    FilterDistr.ReSize((ushort)Config.FilterDistr);
                    TextBoxTimeDistribution.BackColor = Color.White;
                }
                else
                {
                    TextBoxTimeDistribution.BackColor = Color.Red;
                }
            }
        }

        private void ConnectionStatusPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int CircleBack = 20;
            int CircleFront = 12;
            int OffsetXY = (CircleBack - CircleFront) / 2;
            Brush ColorBack;
            Brush ColorFront;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (Detector.Status == ConnectStatus.Connect)
            {
                ColorBack = Brushes.LightGreen;
                ColorFront = Brushes.Green;
            }
            else if (Detector.Status == ConnectStatus.Connecting || Detector.Status == ConnectStatus.Reconnecting)
            {
                ColorBack = Brushes.Orange;
                ColorFront = Brushes.DarkOrange;
            }
            else
            {
                ColorBack = Brushes.OrangeRed;
                ColorFront = Brushes.Red;
            }
            g.FillEllipse(ColorBack, new Rectangle(0, 0, CircleBack, CircleBack));
            g.FillEllipse(ColorFront, new Rectangle(OffsetXY, OffsetXY, CircleFront, CircleFront));
        }

        private void ToggleSwitch1_CheckedChanged(object sender)
        {
            if (rToggleSwitch1.Checked)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
            FormResize();
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                e.TabPage.Controls.Add(label14);
                e.TabPage.Controls.Add(rToggleSwitch1);
                e.TabPage.Controls.Add(label33);
                e.TabPage.Controls.Add(PictureConnectionStatus);
                e.TabPage.Controls.Add(ButtonLanguage);
                CheckFormMode();
            }
        }

        private void CheckFormMode()
        {
            if (tabControl1.SelectedIndex == 1)
            {
                rToggleSwitch1.Checked = true;
                PrevWidthStandart = this.Width;
                PrevHeightStandart = this.Height;
                this.MinimumSize = new Size(MinSizeExtW, MinSizeExtH);
                this.Width = PrevWidthExt;
                this.Height = PrevHeightExt;
                this.Text = "RadLab [Расширенный режим]";
            }
            else
            {
                rToggleSwitch1.Checked = false;
                PrevWidthExt = this.Width;
                PrevHeightExt = this.Height;
                this.MinimumSize = new Size(MinSizeStdW, MinSizeStdH);
                
                this.Width = PrevWidthStandart;
                this.Height = PrevHeightStandart;
                this.Text = "RadLab [Стандартный режим]";
            }
        }


        private void SimpleCountStart(object sender, EventArgs e)
        {
            FilterCPSSimple.Clear();
            StartSimpleCounter = true;
        }

        private void SimpleCountStop(object sender, EventArgs e)
        {
            StartSimpleCounter = false;
        }

        private void ButtonDistrReset_Click(object sender, EventArgs e)
        {
            FilterDistr.Clear();
        }

        private void ZoomMinus(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Minus);
        }

        private void ZoomPlus(object sender, EventArgs e)
        {
            ChartMonitoring.DeltaXScaleViewChange(ZoomAxisAction.Plus);
        }

        private void ButtonDistrExport_Click(object sender, EventArgs e)
        {
            Queue<PointsBuferT> BuferNow = FilterDistr.GetBufer();
            SaveFileDialog saveFileDialog1 = new()
            {
                Title = "Сохранить данные в файл .csv",
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
                    MessageBox.Show("Ошибка при сохранении файла");
                }
            }
        }

        private void ButtonDistrArchive_Click(object sender, EventArgs e)
        {
            FormArchive form = new();
            form.Show();
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            Detector.NeedToConnect = false;
            Detector.Disconnect();
            DateTime dt = DateTime.Now;
            while (true)
            {
                if (Detector.Status == ConnectStatus.Disconnect || dt.AddSeconds(5) < DateTime.Now) break;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {
            if (!(this.Visible)) return;
            if (this.WindowState == FormWindowState.Minimized) return;
            if (tabControl1.SelectedIndex == 0) 
            {
                ButtonSimpleStop.Location = new Point(ButtonSimpleStop.Location.X, this.ClientSize.Height - ButtonSimpleStop.Height - 17);
                ButtonSimpleStart.Location = new Point(ButtonSimpleStart.Location.X, this.ClientSize.Height - ButtonSimpleStart.Height - 17);
                AutoScaleLabels();
                return;
            }

            int Board = 4;

            groupBox1.Width = groupBox4.Location.X - groupBox1.Location.X - Board * 2;
            groupBox2.Width = groupBox1.Width;
            groupBox1.Height = (tabControl1.Height - groupBox1.Location.Y) / 2 - Board;

            ButtonNavStart.Location = new Point(ButtonNavStart.Location.X, groupBox1.Height - ButtonNavStart.Height - Board);
            ButtonNavLeft.Location = new Point(ButtonNavLeft.Location.X, groupBox1.Height - ButtonNavLeft.Height - Board);
            ButtonNavMinus.Location = new Point(ButtonNavMinus.Location.X, groupBox1.Height - ButtonNavMinus.Height - Board);
            ButtonNavPlus.Location = new Point(ButtonNavPlus.Location.X, groupBox1.Height - ButtonNavPlus.Height - Board);
            ButtonNavRight.Location = new Point(ButtonNavRight.Location.X, groupBox1.Height - ButtonNavRight.Height - Board);
            ButtonNavEnd.Location = new Point(ButtonNavEnd.Location.X, groupBox1.Height - ButtonNavEnd.Height - Board);
            chartCPS.Height = ButtonNavStart.Location.Y - chartCPS.Location.Y + Board;

            groupBox2.Location = new Point(groupBox2.Location.X, groupBox1.Location.Y + groupBox1.Height);
            groupBox2.Height = groupBox1.Height;
        }

        private void AutoScaleLabels()
        {
            // Calculate the scaling factor based on the new size of the form
            float scaleX = this.ClientSize.Width / (float)(MinSizeStdW);  
            float scaleY = this.ClientSize.Height / (float)(MinSizeStdH); 
            if (scaleX < 1) scaleX = 1;
            if (scaleY < 1) scaleY = 1;

            // Determine the maximum scaling factor to keep the label within the form bounds
            float maxScaleFactor = Math.Min(scaleX, scaleY);

            // Apply the scaling factor to the labels' size and location
            int LSAnewWidth = (int)(LabelSimpleAverage.MinimumSize.Width * maxScaleFactor);
            int LSAnewHeight = (int)(LabelSimpleAverage.MinimumSize.Height * maxScaleFactor);

            int LSTnewWidth = (int)(LabelSimpleTime.MinimumSize.Width * maxScaleFactor);
            int LSTnewHeight = (int)(LabelSimpleTime.MinimumSize.Height * maxScaleFactor);

            LabelSimpleAverage.Size = new Size(LSAnewWidth, LSAnewHeight);
            LabelSimpleTime.Size = new Size(LSTnewWidth, LSTnewHeight);

            label1.Font = new Font(Font.FontFamily, (float)(15.0F * maxScaleFactor), Font.Style);
            label34.Font = new Font(Font.FontFamily, 15.0F * maxScaleFactor, Font.Style);
            
//            LabelSimpleAverage.Text=tabControl1.Width.ToString();
//            LabelSimpleTime.Text=ClientSize.Width.ToString();

            LabelSimpleAverage.Location = new Point((int)(LabelSimpleAverageLocationX * scaleX), (int)(LabelSimpleAverageLocationY * scaleY));
            LabelSimpleTime.Location = new Point((int)(LabelSimpleTimeLocationX * scaleX), (int)(LabelSimpleTimeLocationY * scaleY));
            label34.Location = new Point((int)(label34LocationX * scaleX), (int)(label34LocationY * scaleY));  //117
            label1.Location = new Point((int)(label1LocationX * scaleX), (int)(label1LocationY * scaleY));
        }
        /// <summary>
        /// Handles the language toggle button click.
        /// Switches language, saves to DB, and applies localization to all controls.
        /// </summary>
        private void ButtonLanguage_Click(object? sender, EventArgs e)
        {
            Localization.ToggleLanguage();

            // Save language to database
            MainConfig Config = LoadConfig();
            Config.Language = Localization.CurrentLanguage;
            SaveConfig(Config);

            ApplyLocalization();
        }
        /// <summary>
        /// Applies localization to all translatable controls on the form.
        /// </summary>
        private void ApplyLocalization()
        {
            // Update language button text
            ButtonLanguage.Text = Localization.LanguageButtonText;

            // Apply translations to FormMain controls
            groupBox1.Text = Localization.GetText("groupBox1");
            groupBox2.Text = Localization.GetText("groupBox2");
            groupBox3.Text = Localization.GetText("groupBox3");
            groupBox4.Text = Localization.GetText("groupBox4");

            label1.Text = Localization.GetText("label1");
            label2.Text = Localization.GetText("label2");
            label3.Text = Localization.GetText("label3");
            label4.Text = Localization.GetText("label4");
            label5.Text = Localization.GetText("label5");
            label6.Text = Localization.GetText("label6");
            label7.Text = Localization.GetText("label7");
            label8.Text = Localization.GetText("label8");
            label9.Text = Localization.GetText("label9");
            label10.Text = Localization.GetText("label10");
            label11.Text = Localization.GetText("label11");
            label12.Text = Localization.GetText("label12");
            label13.Text = Localization.GetText("label13");
            label14.Text = Localization.GetText("label14");
            label15.Text = Localization.GetText("label15");
            label16.Text = Localization.GetText("label16");
            label17.Text = Localization.GetText("label17");
            label18.Text = Localization.GetText("label18");
            label19.Text = Localization.GetText("label19");
            label20.Text = Localization.GetText("label20");
            label21.Text = Localization.GetText("label21");
            label22.Text = Localization.GetText("label22");
            label23.Text = Localization.GetText("label23");
            label24.Text = Localization.GetText("label24");
            label25.Text = Localization.GetText("label25");
            label26.Text = Localization.GetText("label26");
            label27.Text = Localization.GetText("label27");
            label28.Text = Localization.GetText("label28");
            label29.Text = Localization.GetText("label29");
            label30.Text = Localization.GetText("label30");
            label31.Text = Localization.GetText("label31");
            label32.Text = Localization.GetText("label32");
            label33.Text = Localization.GetText("label33");
            toolTipConnectionStatus.SetToolTip(PictureConnectionStatus, label33.Text);
            label34.Text = Localization.GetText("label34");
            label35.Text = Localization.GetText("label35");
            label36.Text = Localization.GetText("label36");
            label37.Text = Localization.GetText("label37");

            // Buttons - preserve current state (СТОП/ПУСК) based on StopMonitoringFlag
            ButtonStartStop.Text = StopMonitoringFlag
                ? Localization.GetString("Start")
                : Localization.GetString("Stop");
            ButtonDistrArchive.Text = Localization.GetText("ButtonDistrArchive");
            ButtonDistrExport.Text = Localization.GetText("ButtonDistrExport");
            ButtonDistrReset.Text = Localization.GetText("ButtonDistrReset");
            ButtonSimpleStop.Text = Localization.GetText("ButtonSimpleStop");
            ButtonSimpleStart.Text = Localization.GetText("ButtonSimpleStart");

            // Tab pages
            tabPage1.Text = Localization.GetText("tabPage1");
            tabPage2.Text = Localization.GetText("tabPage2");

            // Update form title
            CheckFormMode();

            // Update dynamic labels with suffix
            LabelDistributionTimeFilter.Text = FilterDistr.Count().ToString() + Localization.GetString("SecondsSuffix");
        }


    }
}
