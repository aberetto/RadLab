namespace RadLab
{
    partial class FormArchive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArchive));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            groupBox4 = new GroupBox();
            DistributionTimeFilter = new Controls.RLabel();
            label1 = new Label();
            textBoxSigma = new Controls.RLabel();
            textBoxVariance = new Controls.RLabel();
            textBoxMean = new Controls.RLabel();
            textBoxDistrSum = new Controls.RLabel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            label16 = new Label();
            label31 = new Label();
            label18 = new Label();
            label17 = new Label();
            label15 = new Label();
            label12 = new Label();
            groupBox1 = new GroupBox();
            ButtonNavEnd = new Button();
            ButtonNavRight = new Button();
            ButtonNavLeft = new Button();
            ButtonNavStart = new Button();
            ButtonNavMinus = new Button();
            ButtonNavPlus = new Button();
            chartCPS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox2 = new GroupBox();
            chartDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            DateStartPicker = new DateTimePicker();
            Timer1 = new System.Windows.Forms.Timer(components);
            groupBox3 = new GroupBox();
            ButtonDistrExport = new Controls.RButton();
            label3 = new Label();
            ButtonDistrRefresh = new Controls.RButton();
            LabelStartTime = new Controls.RLabel();
            label2 = new Label();
            LabelEndTime = new Controls.RLabel();
            label6 = new Label();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCPS).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(DistributionTimeFilter);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(textBoxSigma);
            groupBox4.Controls.Add(textBoxVariance);
            groupBox4.Controls.Add(textBoxMean);
            groupBox4.Controls.Add(textBoxDistrSum);
            groupBox4.Controls.Add(pictureBox3);
            groupBox4.Controls.Add(pictureBox2);
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(pictureBox5);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label31);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label12);
            groupBox4.Font = new Font("Segoe UI", 12.75F);
            groupBox4.Location = new Point(742, 235);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(0);
            groupBox4.Size = new Size(447, 423);
            groupBox4.TabIndex = 44;
            groupBox4.TabStop = false;
            groupBox4.Text = "Результаты накопления и обработки";
            // 
            // DistributionTimeFilter
            // 
            DistributionTimeFilter.AutoSize = true;
            DistributionTimeFilter.BackColor = Color.FromArgb(238, 238, 238);
            DistributionTimeFilter.BorderColor = Color.Black;
            DistributionTimeFilter.BorderColorEnabled = true;
            DistributionTimeFilter.BorderColorOnHover = Color.Black;
            DistributionTimeFilter.BorderColorOnHoverEnabled = true;
            DistributionTimeFilter.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DistributionTimeFilter.ForeColor = Color.Black;
            DistributionTimeFilter.Location = new Point(203, 58);
            DistributionTimeFilter.MinimumSize = new Size(107, 39);
            DistributionTimeFilter.Name = "DistributionTimeFilter";
            DistributionTimeFilter.Rounding = 50;
            DistributionTimeFilter.RoundingEnable = true;
            DistributionTimeFilter.Size = new Size(107, 39);
            DistributionTimeFilter.TabIndex = 100;
            DistributionTimeFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.75F);
            label1.Location = new Point(3, 64);
            label1.Name = "label1";
            label1.Size = new Size(159, 23);
            label1.TabIndex = 99;
            label1.Text = "Время накопления";
            // 
            // textBoxSigma
            // 
            textBoxSigma.AutoSize = true;
            textBoxSigma.BackColor = Color.FromArgb(238, 238, 238);
            textBoxSigma.BorderColor = Color.Black;
            textBoxSigma.BorderColorEnabled = true;
            textBoxSigma.BorderColorOnHover = Color.Black;
            textBoxSigma.BorderColorOnHoverEnabled = true;
            textBoxSigma.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxSigma.ForeColor = Color.Black;
            textBoxSigma.Location = new Point(203, 338);
            textBoxSigma.MinimumSize = new Size(107, 39);
            textBoxSigma.Name = "textBoxSigma";
            textBoxSigma.Rounding = 50;
            textBoxSigma.RoundingEnable = true;
            textBoxSigma.Size = new Size(107, 39);
            textBoxSigma.TabIndex = 98;
            textBoxSigma.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxVariance
            // 
            textBoxVariance.AutoSize = true;
            textBoxVariance.BackColor = Color.FromArgb(238, 238, 238);
            textBoxVariance.BorderColor = Color.Black;
            textBoxVariance.BorderColorEnabled = true;
            textBoxVariance.BorderColorOnHover = Color.Black;
            textBoxVariance.BorderColorOnHoverEnabled = true;
            textBoxVariance.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxVariance.ForeColor = Color.Black;
            textBoxVariance.Location = new Point(203, 268);
            textBoxVariance.MinimumSize = new Size(107, 39);
            textBoxVariance.Name = "textBoxVariance";
            textBoxVariance.Rounding = 50;
            textBoxVariance.RoundingEnable = true;
            textBoxVariance.Size = new Size(107, 39);
            textBoxVariance.TabIndex = 97;
            textBoxVariance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxMean
            // 
            textBoxMean.AutoSize = true;
            textBoxMean.BackColor = Color.FromArgb(238, 238, 238);
            textBoxMean.BorderColor = Color.Black;
            textBoxMean.BorderColorEnabled = true;
            textBoxMean.BorderColorOnHover = Color.Black;
            textBoxMean.BorderColorOnHoverEnabled = true;
            textBoxMean.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxMean.ForeColor = Color.Black;
            textBoxMean.Location = new Point(203, 198);
            textBoxMean.MinimumSize = new Size(107, 39);
            textBoxMean.Name = "textBoxMean";
            textBoxMean.Rounding = 50;
            textBoxMean.RoundingEnable = true;
            textBoxMean.Size = new Size(107, 39);
            textBoxMean.TabIndex = 96;
            textBoxMean.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxDistrSum
            // 
            textBoxDistrSum.AutoSize = true;
            textBoxDistrSum.BackColor = Color.FromArgb(238, 238, 238);
            textBoxDistrSum.BorderColor = Color.Black;
            textBoxDistrSum.BorderColorEnabled = true;
            textBoxDistrSum.BorderColorOnHover = Color.Black;
            textBoxDistrSum.BorderColorOnHoverEnabled = true;
            textBoxDistrSum.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxDistrSum.ForeColor = Color.Black;
            textBoxDistrSum.Location = new Point(203, 128);
            textBoxDistrSum.MinimumSize = new Size(107, 39);
            textBoxDistrSum.Name = "textBoxDistrSum";
            textBoxDistrSum.Rounding = 50;
            textBoxDistrSum.RoundingEnable = true;
            textBoxDistrSum.Size = new Size(107, 39);
            textBoxDistrSum.TabIndex = 94;
            textBoxDistrSum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.InitialImage = null;
            pictureBox3.Location = new Point(323, 118);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(120, 65);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 72;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(323, 188);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(120, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 71;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(323, 258);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 70;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.InitialImage = null;
            pictureBox5.Location = new Point(323, 329);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(120, 65);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 69;
            pictureBox5.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12.75F);
            label16.Location = new Point(3, 333);
            label16.Name = "label16";
            label16.Size = new Size(178, 23);
            label16.TabIndex = 44;
            label16.Text = "Среднеквадратичное";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 12.75F);
            label31.Location = new Point(3, 358);
            label31.Name = "label31";
            label31.Size = new Size(102, 23);
            label31.TabIndex = 63;
            label31.Text = "отклонение";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12.75F);
            label18.Location = new Point(3, 213);
            label18.Name = "label18";
            label18.Size = new Size(90, 23);
            label18.TabIndex = 47;
            label18.Text = "ожидание";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12.75F);
            label17.Location = new Point(3, 134);
            label17.Name = "label17";
            label17.Size = new Size(174, 23);
            label17.TabIndex = 45;
            label17.Text = "Количество событий";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12.75F);
            label15.Location = new Point(3, 274);
            label15.Name = "label15";
            label15.Size = new Size(96, 23);
            label15.TabIndex = 43;
            label15.Text = "Дисперсия";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12.75F);
            label12.Location = new Point(3, 191);
            label12.Name = "label12";
            label12.Size = new Size(142, 23);
            label12.TabIndex = 42;
            label12.Text = "Математическое";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ButtonNavEnd);
            groupBox1.Controls.Add(ButtonNavRight);
            groupBox1.Controls.Add(ButtonNavLeft);
            groupBox1.Controls.Add(ButtonNavStart);
            groupBox1.Controls.Add(ButtonNavMinus);
            groupBox1.Controls.Add(ButtonNavPlus);
            groupBox1.Controls.Add(chartCPS);
            groupBox1.Font = new Font("Segoe UI", 12.75F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(710, 318);
            groupBox1.TabIndex = 42;
            groupBox1.TabStop = false;
            groupBox1.Text = "График скорости счёта";
            // 
            // ButtonNavEnd
            // 
            ButtonNavEnd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonNavEnd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavEnd.Location = new Point(593, 287);
            ButtonNavEnd.Margin = new Padding(0);
            ButtonNavEnd.Name = "ButtonNavEnd";
            ButtonNavEnd.Size = new Size(100, 28);
            ButtonNavEnd.TabIndex = 68;
            ButtonNavEnd.Text = ">>>";
            ButtonNavEnd.UseVisualStyleBackColor = true;
            ButtonNavEnd.Click += ButtonNavEnd_Click;
            // 
            // ButtonNavRight
            // 
            ButtonNavRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonNavRight.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavRight.Location = new Point(493, 287);
            ButtonNavRight.Margin = new Padding(0);
            ButtonNavRight.Name = "ButtonNavRight";
            ButtonNavRight.Size = new Size(100, 28);
            ButtonNavRight.TabIndex = 67;
            ButtonNavRight.Text = ">";
            ButtonNavRight.UseVisualStyleBackColor = true;
            ButtonNavRight.Click += ButtonNavRight_Click;
            // 
            // ButtonNavLeft
            // 
            ButtonNavLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonNavLeft.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavLeft.Location = new Point(108, 287);
            ButtonNavLeft.Margin = new Padding(0);
            ButtonNavLeft.Name = "ButtonNavLeft";
            ButtonNavLeft.Size = new Size(100, 28);
            ButtonNavLeft.TabIndex = 66;
            ButtonNavLeft.TabStop = false;
            ButtonNavLeft.Text = "<";
            ButtonNavLeft.UseVisualStyleBackColor = true;
            ButtonNavLeft.Click += ButtonNavLeft_Click;
            // 
            // ButtonNavStart
            // 
            ButtonNavStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonNavStart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavStart.Location = new Point(8, 287);
            ButtonNavStart.Margin = new Padding(0);
            ButtonNavStart.Name = "ButtonNavStart";
            ButtonNavStart.Size = new Size(100, 28);
            ButtonNavStart.TabIndex = 65;
            ButtonNavStart.TabStop = false;
            ButtonNavStart.Text = "<<<";
            ButtonNavStart.UseVisualStyleBackColor = true;
            ButtonNavStart.Click += ButtonNavStart_Click;
            // 
            // ButtonNavMinus
            // 
            ButtonNavMinus.Anchor = AnchorStyles.Bottom;
            ButtonNavMinus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavMinus.Location = new Point(252, 287);
            ButtonNavMinus.Margin = new Padding(0);
            ButtonNavMinus.Name = "ButtonNavMinus";
            ButtonNavMinus.Size = new Size(100, 28);
            ButtonNavMinus.TabIndex = 47;
            ButtonNavMinus.Text = "-";
            ButtonNavMinus.UseVisualStyleBackColor = true;
            ButtonNavMinus.Click += ButtonNavMinus_Click;
            // 
            // ButtonNavPlus
            // 
            ButtonNavPlus.Anchor = AnchorStyles.Bottom;
            ButtonNavPlus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavPlus.Location = new Point(352, 287);
            ButtonNavPlus.Margin = new Padding(0);
            ButtonNavPlus.Name = "ButtonNavPlus";
            ButtonNavPlus.Size = new Size(100, 28);
            ButtonNavPlus.TabIndex = 46;
            ButtonNavPlus.Text = "+";
            ButtonNavPlus.UseVisualStyleBackColor = true;
            ButtonNavPlus.Click += ButtonNavPlus_Click;
            // 
            // chartCPS
            // 
            chartArea3.Name = "ChartArea1";
            chartCPS.ChartAreas.Add(chartArea3);
            chartCPS.Dock = DockStyle.Top;
            chartCPS.Location = new Point(3, 26);
            chartCPS.Name = "chartCPS";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series5.Color = Color.Blue;
            series5.Name = "CurrentCPS";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = Color.Green;
            series6.Name = "FilteredCPS";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            chartCPS.Series.Add(series5);
            chartCPS.Series.Add(series6);
            chartCPS.Size = new Size(704, 259);
            chartCPS.TabIndex = 0;
            chartCPS.Text = "chart1";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(chartDistribution);
            groupBox2.Font = new Font("Segoe UI", 12.75F);
            groupBox2.Location = new Point(12, 340);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(710, 318);
            groupBox2.TabIndex = 43;
            groupBox2.TabStop = false;
            groupBox2.Text = "Распределение случайной величины";
            // 
            // chartDistribution
            // 
            chartArea4.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.Name = "ChartArea1";
            chartDistribution.ChartAreas.Add(chartArea4);
            chartDistribution.Dock = DockStyle.Fill;
            chartDistribution.Location = new Point(3, 26);
            chartDistribution.Name = "chartDistribution";
            series7.ChartArea = "ChartArea1";
            series7.CustomProperties = "PointWidth=1";
            series7.Name = "Series1";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = Color.Fuchsia;
            series8.Name = "Series2";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chartDistribution.Series.Add(series7);
            chartDistribution.Series.Add(series8);
            chartDistribution.Size = new Size(704, 289);
            chartDistribution.TabIndex = 1;
            chartDistribution.Text = "chart2";
            // 
            // DateStartPicker
            // 
            DateStartPicker.CalendarFont = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateStartPicker.CustomFormat = "";
            DateStartPicker.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateStartPicker.Format = DateTimePickerFormat.Short;
            DateStartPicker.Location = new Point(124, 40);
            DateStartPicker.Name = "DateStartPicker";
            DateStartPicker.Size = new Size(150, 32);
            DateStartPicker.TabIndex = 45;
            DateStartPicker.ValueChanged += DateStartPicker_ValueChanged;
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Tick += Timer1_Tick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(ButtonDistrExport);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(ButtonDistrRefresh);
            groupBox3.Controls.Add(LabelStartTime);
            groupBox3.Controls.Add(DateStartPicker);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(LabelEndTime);
            groupBox3.Controls.Add(label6);
            groupBox3.Font = new Font("Segoe UI", 12.75F);
            groupBox3.Location = new Point(742, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(0);
            groupBox3.Size = new Size(447, 208);
            groupBox3.TabIndex = 46;
            groupBox3.TabStop = false;
            groupBox3.Text = "Выбор интервала данных";
            // 
            // ButtonDistrExport
            // 
            ButtonDistrExport.BackColor = Color.Transparent;
            ButtonDistrExport.BorderColor = Color.Black;
            ButtonDistrExport.BorderColorEnabled = true;
            ButtonDistrExport.BorderColorOnHover = Color.Black;
            ButtonDistrExport.BorderColorOnHoverEnabled = true;
            ButtonDistrExport.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            ButtonDistrExport.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonDistrExport.Location = new Point(299, 147);
            ButtonDistrExport.Name = "ButtonDistrExport";
            ButtonDistrExport.Rounding = 50;
            ButtonDistrExport.RoundingEnable = true;
            ButtonDistrExport.Size = new Size(132, 39);
            ButtonDistrExport.TabIndex = 103;
            ButtonDistrExport.Text = "Экспорт CSV";
            ButtonDistrExport.UseVisualStyleBackColor = false;
            ButtonDistrExport.UseZoomEffectOnHover = true;
            ButtonDistrExport.Click += ButtonDistrExport_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.75F);
            label3.Location = new Point(3, 46);
            label3.Name = "label3";
            label3.Size = new Size(47, 23);
            label3.TabIndex = 102;
            label3.Text = "Дата";
            // 
            // ButtonDistrRefresh
            // 
            ButtonDistrRefresh.BackColor = Color.Transparent;
            ButtonDistrRefresh.BorderColor = Color.Black;
            ButtonDistrRefresh.BorderColorEnabled = true;
            ButtonDistrRefresh.BorderColorOnHover = Color.Black;
            ButtonDistrRefresh.BorderColorOnHoverEnabled = true;
            ButtonDistrRefresh.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            ButtonDistrRefresh.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonDistrRefresh.Location = new Point(299, 40);
            ButtonDistrRefresh.Name = "ButtonDistrRefresh";
            ButtonDistrRefresh.Rounding = 50;
            ButtonDistrRefresh.RoundingEnable = true;
            ButtonDistrRefresh.Size = new Size(132, 39);
            ButtonDistrRefresh.TabIndex = 101;
            ButtonDistrRefresh.Text = "Обновить";
            ButtonDistrRefresh.UseVisualStyleBackColor = false;
            ButtonDistrRefresh.UseZoomEffectOnHover = true;
            ButtonDistrRefresh.Click += ButtonDistrRefresh_Click;
            // 
            // LabelStartTime
            // 
            LabelStartTime.AutoSize = true;
            LabelStartTime.BackColor = Color.FromArgb(238, 238, 238);
            LabelStartTime.BorderColor = Color.Black;
            LabelStartTime.BorderColorEnabled = true;
            LabelStartTime.BorderColorOnHover = Color.Black;
            LabelStartTime.BorderColorOnHoverEnabled = true;
            LabelStartTime.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelStartTime.ForeColor = Color.Black;
            LabelStartTime.Location = new Point(124, 92);
            LabelStartTime.MinimumSize = new Size(150, 39);
            LabelStartTime.Name = "LabelStartTime";
            LabelStartTime.Rounding = 50;
            LabelStartTime.RoundingEnable = true;
            LabelStartTime.Size = new Size(150, 39);
            LabelStartTime.TabIndex = 100;
            LabelStartTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.75F);
            label2.Location = new Point(3, 101);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 99;
            label2.Text = "Начало";
            // 
            // LabelEndTime
            // 
            LabelEndTime.AutoSize = true;
            LabelEndTime.BackColor = Color.FromArgb(238, 238, 238);
            LabelEndTime.BorderColor = Color.Black;
            LabelEndTime.BorderColorEnabled = true;
            LabelEndTime.BorderColorOnHover = Color.Black;
            LabelEndTime.BorderColorOnHoverEnabled = true;
            LabelEndTime.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelEndTime.ForeColor = Color.Black;
            LabelEndTime.Location = new Point(124, 147);
            LabelEndTime.MinimumSize = new Size(150, 39);
            LabelEndTime.Name = "LabelEndTime";
            LabelEndTime.Rounding = 50;
            LabelEndTime.RoundingEnable = true;
            LabelEndTime.Size = new Size(150, 39);
            LabelEndTime.TabIndex = 94;
            LabelEndTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12.75F);
            label6.Location = new Point(3, 156);
            label6.Name = "label6";
            label6.Size = new Size(99, 23);
            label6.TabIndex = 45;
            label6.Text = "Окончание";
            // 
            // FormArchive
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1202, 665);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1134, 704);
            Name = "FormArchive";
            Text = "RadLab [Архив]";
            Load += FormArchive_Load;
            Resize += FormArchive_Resize;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCPS).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDistribution).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private Controls.RLabel textBoxSigma;
        private Controls.RLabel textBoxVariance;
        private Controls.RLabel textBoxMean;
        private Controls.RLabel textBoxDistrSum;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Label label16;
        private Label label31;
        private Label label18;
        private Label label17;
        private Label label15;
        private Label label12;
        private GroupBox groupBox1;
        private Button ButtonNavEnd;
        private Button ButtonNavRight;
        private Button ButtonNavLeft;
        private Button ButtonNavStart;
        private Button ButtonNavMinus;
        private Button ButtonNavPlus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCPS;
        private GroupBox groupBox2;
        private DateTimePicker DateStartPicker;
        private System.Windows.Forms.Timer Timer1;
        private Controls.RLabel DistributionTimeFilter;
        private Label label1;
        private GroupBox groupBox3;
        private Controls.RLabel LabelStartTime;
        private Label label2;
        private Controls.RLabel LabelEndTime;
        private Label label6;
        private Label label3;
        private Controls.RButton ButtonDistrRefresh;
        private Controls.RButton ButtonDistrExport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;
    }
}