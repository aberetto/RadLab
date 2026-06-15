using System.Security.Cryptography.X509Certificates;
using RadLab.Controls;

namespace RadLab
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            MainTimer = new System.Windows.Forms.Timer(components);
            ToolTipComboBoxPortName = new ToolTip(components);
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            LabelCurrentTimeFilter = new Label();
            groupBox3 = new GroupBox();
            label37 = new Label();
            TextBoxTimeDistribution = new RTextBox();
            TextBoxTimeFilter = new RTextBox();
            ButtonDistrArchive = new RButton();
            ButtonDistrExport = new RButton();
            ButtonDistrReset = new RButton();
            ButtonStartStop = new RButton();
            label32 = new Label();
            label13 = new Label();
            LabelDistributionTimeFilter = new Label();
            label8 = new Label();
            groupBox4 = new GroupBox();
            TextBoxResult1 = new RLabel();
            pictureBox2 = new PictureBox();
            textBoxSigma = new RLabel();
            label23 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            textBoxVariance = new RLabel();
            label25 = new Label();
            label22 = new Label();
            pictureBox5 = new PictureBox();
            TextBoxCoeff1 = new RTextBox();
            textBoxMean = new RLabel();
            label24 = new Label();
            label21 = new Label();
            label16 = new Label();
            TextBoxCoeff2 = new RTextBox();
            TextBoxResult2 = new RLabel();
            label4 = new Label();
            label20 = new Label();
            label12 = new Label();
            label31 = new Label();
            TextBoxCurrentCPS = new RLabel();
            label26 = new Label();
            textBoxDistrSum = new RLabel();
            label19 = new Label();
            label5 = new Label();
            label30 = new Label();
            label15 = new Label();
            TextBoxSumCPS = new RLabel();
            label29 = new Label();
            label27 = new Label();
            label17 = new Label();
            label18 = new Label();
            label28 = new Label();
            label2 = new Label();
            TextBoxAverageCPS = new RLabel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            LabelSimpleTime = new RLabel();
            LabelSimpleAverage = new RLabel();
            label34 = new Label();
            rToggleSwitch1 = new RToggleSwitch();
            ButtonSimpleStop = new RButton();
            ButtonSimpleStart = new RButton();
            PictureConnectionStatus = new PictureBox();
            label33 = new Label();
            label14 = new Label();
            tabPage2 = new TabPage();
            pictureBox4 = new PictureBox();
            label36 = new Label();
            rToggleSwitch2 = new RToggleSwitch();
            label35 = new Label();
            roundingButtonsComponent1 = new RoundingButtonsComponent(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCPS).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureConnectionStatus).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
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
            groupBox1.Location = new Point(153, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(649, 309);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "График скорости счёта";
            // 
            // ButtonNavEnd
            // 
            ButtonNavEnd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonNavEnd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavEnd.Location = new Point(543, 276);
            ButtonNavEnd.Margin = new Padding(0);
            ButtonNavEnd.Name = "ButtonNavEnd";
            ButtonNavEnd.Size = new Size(91, 29);
            ButtonNavEnd.TabIndex = 68;
            ButtonNavEnd.Text = ">>>";
            ButtonNavEnd.UseVisualStyleBackColor = true;
            ButtonNavEnd.Click += ButtonNavEnd_Click;
            // 
            // ButtonNavRight
            // 
            ButtonNavRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonNavRight.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavRight.Location = new Point(451, 276);
            ButtonNavRight.Margin = new Padding(0);
            ButtonNavRight.Name = "ButtonNavRight";
            ButtonNavRight.Size = new Size(91, 29);
            ButtonNavRight.TabIndex = 67;
            ButtonNavRight.Text = ">";
            ButtonNavRight.UseVisualStyleBackColor = true;
            ButtonNavRight.Click += ButtonNavRight_Click;
            // 
            // ButtonNavLeft
            // 
            ButtonNavLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonNavLeft.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavLeft.Location = new Point(99, 276);
            ButtonNavLeft.Margin = new Padding(0);
            ButtonNavLeft.Name = "ButtonNavLeft";
            ButtonNavLeft.Size = new Size(91, 29);
            ButtonNavLeft.TabIndex = 66;
            ButtonNavLeft.Text = "<";
            ButtonNavLeft.UseVisualStyleBackColor = true;
            ButtonNavLeft.Click += ButtonNavLeft_Click;
            // 
            // ButtonNavStart
            // 
            ButtonNavStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonNavStart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavStart.Location = new Point(7, 276);
            ButtonNavStart.Margin = new Padding(0);
            ButtonNavStart.Name = "ButtonNavStart";
            ButtonNavStart.Size = new Size(91, 29);
            ButtonNavStart.TabIndex = 65;
            ButtonNavStart.Text = "<<<";
            ButtonNavStart.UseVisualStyleBackColor = true;
            ButtonNavStart.Click += ButtonNavStart_Click;
            // 
            // ButtonNavMinus
            // 
            ButtonNavMinus.Anchor = AnchorStyles.Bottom;
            ButtonNavMinus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavMinus.Location = new Point(229, 276);
            ButtonNavMinus.Margin = new Padding(0);
            ButtonNavMinus.Name = "ButtonNavMinus";
            ButtonNavMinus.Size = new Size(91, 29);
            ButtonNavMinus.TabIndex = 47;
            ButtonNavMinus.Text = "-";
            ButtonNavMinus.UseVisualStyleBackColor = true;
            ButtonNavMinus.Click += ZoomMinus;
            // 
            // ButtonNavPlus
            // 
            ButtonNavPlus.Anchor = AnchorStyles.Bottom;
            ButtonNavPlus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonNavPlus.Location = new Point(321, 276);
            ButtonNavPlus.Margin = new Padding(0);
            ButtonNavPlus.Name = "ButtonNavPlus";
            ButtonNavPlus.Size = new Size(91, 29);
            ButtonNavPlus.TabIndex = 46;
            ButtonNavPlus.Text = "+";
            ButtonNavPlus.UseVisualStyleBackColor = true;
            ButtonNavPlus.Click += ZoomPlus;
            // 
            // chartCPS
            // 
            chartArea1.Name = "ChartArea1";
            chartCPS.ChartAreas.Add(chartArea1);
            chartCPS.Dock = DockStyle.Top;
            chartCPS.Location = new Point(3, 26);
            chartCPS.Name = "chartCPS";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Color = Color.Blue;
            series1.Name = "CurrentCPS";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.Green;
            series2.Name = "FilteredCPS";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            chartCPS.Series.Add(series1);
            chartCPS.Series.Add(series2);
            chartCPS.Size = new Size(643, 248);
            chartCPS.TabIndex = 0;
            chartCPS.Text = "chart1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chartDistribution);
            groupBox2.Font = new Font("Segoe UI", 12.75F);
            groupBox2.Location = new Point(153, 358);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(649, 309);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Распределение случайной величины";
            // 
            // chartDistribution
            // 
            chartArea2.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            chartDistribution.ChartAreas.Add(chartArea2);
            chartDistribution.Dock = DockStyle.Fill;
            chartDistribution.Location = new Point(3, 26);
            chartDistribution.Name = "chartDistribution";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "PointWidth=1";
            series3.Name = "Series1";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = Color.Fuchsia;
            series4.Name = "Series2";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chartDistribution.Series.Add(series3);
            chartDistribution.Series.Add(series4);
            chartDistribution.Size = new Size(643, 280);
            chartDistribution.TabIndex = 0;
            chartDistribution.Text = "chart2";
            // 
            // MainTimer
            // 
            MainTimer.Enabled = true;
            MainTimer.Tick += MainTimer_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.75F);
            label3.Location = new Point(3, 55);
            label3.Name = "label3";
            label3.Size = new Size(288, 23);
            label3.TabIndex = 10;
            label3.Text = "Мновенная скорость счёта, имп./с:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(3, 97);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 14;
            label6.Text = "Время фильтра:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(3, 267);
            label7.Name = "label7";
            label7.Size = new Size(86, 20);
            label7.TabIndex = 18;
            label7.Text = "статистики:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12.75F);
            label9.Location = new Point(3, 103);
            label9.Name = "label9";
            label9.Size = new Size(213, 23);
            label9.TabIndex = 23;
            label9.Text = "Общее кол-во импульсов";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 24F);
            label10.Location = new Point(243, 218);
            label10.Name = "label10";
            label10.Size = new Size(42, 45);
            label10.TabIndex = 22;
            label10.Text = "=";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.Location = new Point(101, 132);
            label11.Name = "label11";
            label11.Size = new Size(21, 25);
            label11.TabIndex = 26;
            label11.Text = "с";
            // 
            // LabelCurrentTimeFilter
            // 
            LabelCurrentTimeFilter.AutoSize = true;
            LabelCurrentTimeFilter.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelCurrentTimeFilter.Location = new Point(137, 128);
            LabelCurrentTimeFilter.Name = "LabelCurrentTimeFilter";
            LabelCurrentTimeFilter.Size = new Size(28, 32);
            LabelCurrentTimeFilter.TabIndex = 34;
            LabelCurrentTimeFilter.Text = "0";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label37);
            groupBox3.Controls.Add(TextBoxTimeDistribution);
            groupBox3.Controls.Add(TextBoxTimeFilter);
            groupBox3.Controls.Add(ButtonDistrArchive);
            groupBox3.Controls.Add(ButtonDistrExport);
            groupBox3.Controls.Add(ButtonDistrReset);
            groupBox3.Controls.Add(ButtonStartStop);
            groupBox3.Controls.Add(label32);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(LabelDistributionTimeFilter);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label11);
            groupBox3.Font = new Font("Segoe UI", 12.75F);
            groupBox3.Location = new Point(12, 87);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(135, 580);
            groupBox3.TabIndex = 40;
            groupBox3.TabStop = false;
            groupBox3.Text = "Управление";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Segoe UI", 11.25F);
            label37.Location = new Point(3, 221);
            label37.Name = "label37";
            label37.Size = new Size(54, 20);
            label37.TabIndex = 88;
            label37.Text = "Время";
            // 
            // TextBoxTimeDistribution
            // 
            TextBoxTimeDistribution.BackColor = Color.White;
            TextBoxTimeDistribution.BorderColor = Color.Black;
            TextBoxTimeDistribution.BorderColorEnabled = true;
            TextBoxTimeDistribution.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxTimeDistribution.ForeColor = Color.FromArgb(231, 69, 47);
            TextBoxTimeDistribution.Location = new Point(5, 292);
            TextBoxTimeDistribution.Name = "TextBoxTimeDistribution";
            TextBoxTimeDistribution.Rounding = 50;
            TextBoxTimeDistribution.RoundingEnable = true;
            TextBoxTimeDistribution.SelectionStart = 0;
            TextBoxTimeDistribution.Size = new Size(91, 41);
            TextBoxTimeDistribution.TabIndex = 87;
            TextBoxTimeDistribution.TextAlign = HorizontalAlignment.Left;
            TextBoxTimeDistribution.TextInput = "100";
            TextBoxTimeDistribution.UseSystemPasswordChar = false;
            TextBoxTimeDistribution.TextChanged += TextBoxTimeDistribution_TextChanged;
            TextBoxTimeDistribution.KeyDown += TextBoxTimeDistribution_KeyDown;
            TextBoxTimeDistribution.KeyPress += textBox_KeyPress;

            // 
            // TextBoxTimeFilter
            // 
            TextBoxTimeFilter.BackColor = Color.White;
            TextBoxTimeFilter.BorderColor = Color.Black;
            TextBoxTimeFilter.BorderColorEnabled = true;
            TextBoxTimeFilter.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxTimeFilter.ForeColor = Color.FromArgb(231, 69, 47);
            TextBoxTimeFilter.Location = new Point(5, 123);
            TextBoxTimeFilter.Name = "TextBoxTimeFilter";
            TextBoxTimeFilter.Rounding = 50;
            TextBoxTimeFilter.RoundingEnable = true;
            TextBoxTimeFilter.SelectionStart = 0;
            TextBoxTimeFilter.Size = new Size(91, 41);
            TextBoxTimeFilter.TabIndex = 86;
            TextBoxTimeFilter.TextAlign = HorizontalAlignment.Left;
            TextBoxTimeFilter.TextInput = "30";
            TextBoxTimeFilter.UseSystemPasswordChar = false;
            TextBoxTimeFilter.TextChanged += TextBoxTimeFilter_TextChanged;
            TextBoxTimeFilter.KeyDown += TextBoxTimeFilter_KeyDown;
            TextBoxTimeFilter.KeyPress += textBox_KeyPress;
            // 
            // ButtonDistrArchive
            // 
            ButtonDistrArchive.BackColor = Color.Transparent;
            ButtonDistrArchive.BorderColor = Color.Black;
            ButtonDistrArchive.BorderColorEnabled = true;
            ButtonDistrArchive.BorderColorOnHover = Color.Black;
            ButtonDistrArchive.BorderColorOnHoverEnabled = true;
            ButtonDistrArchive.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            ButtonDistrArchive.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonDistrArchive.Location = new Point(5, 523);
            ButtonDistrArchive.Name = "ButtonDistrArchive";
            ButtonDistrArchive.Rounding = 50;
            ButtonDistrArchive.RoundingEnable = true;
            ButtonDistrArchive.Size = new Size(121, 51);
            ButtonDistrArchive.TabIndex = 79;
            ButtonDistrArchive.Text = "Архив";
            ButtonDistrArchive.UseVisualStyleBackColor = false;
            ButtonDistrArchive.UseZoomEffectOnHover = true;
            ButtonDistrArchive.Click += ButtonDistrArchive_Click;
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
            ButtonDistrExport.Location = new Point(5, 466);
            ButtonDistrExport.Name = "ButtonDistrExport";
            ButtonDistrExport.Rounding = 50;
            ButtonDistrExport.RoundingEnable = true;
            ButtonDistrExport.Size = new Size(121, 51);
            ButtonDistrExport.TabIndex = 78;
            ButtonDistrExport.Text = "Экспорт CSV";
            ButtonDistrExport.UseVisualStyleBackColor = false;
            ButtonDistrExport.UseZoomEffectOnHover = true;
            ButtonDistrExport.Click += ButtonDistrExport_Click;
            // 
            // ButtonDistrReset
            // 
            ButtonDistrReset.BackColor = Color.Transparent;
            ButtonDistrReset.BorderColor = Color.Black;
            ButtonDistrReset.BorderColorEnabled = true;
            ButtonDistrReset.BorderColorOnHover = Color.Black;
            ButtonDistrReset.BorderColorOnHoverEnabled = true;
            ButtonDistrReset.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            ButtonDistrReset.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonDistrReset.Location = new Point(5, 410);
            ButtonDistrReset.Name = "ButtonDistrReset";
            ButtonDistrReset.Rounding = 50;
            ButtonDistrReset.RoundingEnable = true;
            ButtonDistrReset.Size = new Size(121, 51);
            ButtonDistrReset.TabIndex = 77;
            ButtonDistrReset.Text = "Сброс";
            ButtonDistrReset.UseVisualStyleBackColor = false;
            ButtonDistrReset.UseZoomEffectOnHover = true;
            ButtonDistrReset.Click += ButtonDistrReset_Click;
            // 
            // ButtonStartStop
            // 
            ButtonStartStop.BackColor = Color.Transparent;
            ButtonStartStop.BorderColor = Color.Black;
            ButtonStartStop.BorderColorEnabled = true;
            ButtonStartStop.BorderColorOnHover = Color.Black;
            ButtonStartStop.BorderColorOnHoverEnabled = true;
            ButtonStartStop.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            ButtonStartStop.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonStartStop.Location = new Point(5, 35);
            ButtonStartStop.Name = "ButtonStartStop";
            ButtonStartStop.Rounding = 50;
            ButtonStartStop.RoundingEnable = true;
            ButtonStartStop.Size = new Size(121, 51);
            ButtonStartStop.TabIndex = 76;
            ButtonStartStop.Text = "СТОП";
            ButtonStartStop.UseVisualStyleBackColor = false;
            ButtonStartStop.UseZoomEffectOnHover = true;
            ButtonStartStop.Click += ButtonStartStop_Click;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 11.25F);
            label32.Location = new Point(3, 244);
            label32.Name = "label32";
            label32.Size = new Size(93, 20);
            label32.TabIndex = 46;
            label32.Text = "накопления";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.Location = new Point(101, 302);
            label13.Name = "label13";
            label13.Size = new Size(21, 25);
            label13.TabIndex = 45;
            label13.Text = "с";
            // 
            // LabelDistributionTimeFilter
            // 
            LabelDistributionTimeFilter.AutoSize = true;
            LabelDistributionTimeFilter.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelDistributionTimeFilter.Location = new Point(5, 360);
            LabelDistributionTimeFilter.Name = "LabelDistributionTimeFilter";
            LabelDistributionTimeFilter.Size = new Size(28, 32);
            LabelDistributionTimeFilter.TabIndex = 44;
            LabelDistributionTimeFilter.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(3, 338);
            label8.Name = "label8";
            label8.Size = new Size(121, 20);
            label8.TabIndex = 43;
            label8.Text = "Таймер отсчёта:";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(TextBoxResult1);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(pictureBox2);
            groupBox4.Controls.Add(textBoxSigma);
            groupBox4.Controls.Add(LabelCurrentTimeFilter);
            groupBox4.Controls.Add(label23);
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(pictureBox3);
            groupBox4.Controls.Add(textBoxVariance);
            groupBox4.Controls.Add(label25);
            groupBox4.Controls.Add(label22);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(pictureBox5);
            groupBox4.Controls.Add(TextBoxCoeff1);
            groupBox4.Controls.Add(textBoxMean);
            groupBox4.Controls.Add(label24);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(TextBoxCoeff2);
            groupBox4.Controls.Add(TextBoxResult2);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label20);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label31);
            groupBox4.Controls.Add(TextBoxCurrentCPS);
            groupBox4.Controls.Add(label26);
            groupBox4.Controls.Add(textBoxDistrSum);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label30);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(TextBoxSumCPS);
            groupBox4.Controls.Add(label29);
            groupBox4.Controls.Add(label27);
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(label28);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(TextBoxAverageCPS);
            groupBox4.Font = new Font("Segoe UI", 12.75F);
            groupBox4.Location = new Point(807, 7);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(0);
            groupBox4.Size = new Size(409, 660);
            groupBox4.TabIndex = 41;
            groupBox4.TabStop = false;
            groupBox4.Text = "Результаты накопления и обработки";
            // 
            // TextBoxResult1
            // 
            TextBoxResult1.AutoSize = true;
            TextBoxResult1.BackColor = Color.FromArgb(238, 238, 238);
            TextBoxResult1.BorderColor = Color.Black;
            TextBoxResult1.BorderColorEnabled = true;
            TextBoxResult1.BorderColorOnHover = Color.Black;
            TextBoxResult1.BorderColorOnHoverEnabled = true;
            TextBoxResult1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxResult1.ForeColor = Color.Black;
            TextBoxResult1.Location = new Point(275, 226);
            TextBoxResult1.MinimumSize = new Size(121, 41);
            TextBoxResult1.Name = "TextBoxResult1";
            TextBoxResult1.Rounding = 50;
            TextBoxResult1.RoundingEnable = true;
            TextBoxResult1.Size = new Size(121, 41);
            TextBoxResult1.TabIndex = 93;
            TextBoxResult1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(293, 439);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(109, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 71;
            pictureBox2.TabStop = false;
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
            textBoxSigma.Location = new Point(185, 602);
            textBoxSigma.MinimumSize = new Size(97, 41);
            textBoxSigma.Name = "textBoxSigma";
            textBoxSigma.Rounding = 50;
            textBoxSigma.RoundingEnable = true;
            textBoxSigma.Size = new Size(97, 41);
            textBoxSigma.TabIndex = 98;
            textBoxSigma.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Symbol", 12.75F);
            label23.Location = new Point(197, 196);
            label23.Name = "label23";
            label23.Size = new Size(20, 21);
            label23.TabIndex = 52;
            label23.Text = "b";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(293, 513);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 70;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.InitialImage = null;
            pictureBox3.Location = new Point(293, 365);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(109, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 72;
            pictureBox3.TabStop = false;
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
            textBoxVariance.Location = new Point(185, 527);
            textBoxVariance.MinimumSize = new Size(97, 41);
            textBoxVariance.Name = "textBoxVariance";
            textBoxVariance.Rounding = 50;
            textBoxVariance.RoundingEnable = true;
            textBoxVariance.Size = new Size(97, 41);
            textBoxVariance.TabIndex = 97;
            textBoxVariance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12.75F);
            label25.Location = new Point(140, 272);
            label25.Name = "label25";
            label25.Size = new Size(54, 23);
            label25.TabIndex = 53;
            label25.Text = "Коэф.";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12.75F);
            label22.Location = new Point(140, 196);
            label22.Name = "label22";
            label22.Size = new Size(54, 23);
            label22.TabIndex = 51;
            label22.Text = "Коэф.";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.InitialImage = null;
            pictureBox5.Location = new Point(293, 589);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(109, 69);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 69;
            pictureBox5.TabStop = false;
            // 
            // TextBoxCoeff1
            // 
            TextBoxCoeff1.BackColor = Color.White;
            TextBoxCoeff1.BorderColor = Color.Black;
            TextBoxCoeff1.BorderColorEnabled = true;
            TextBoxCoeff1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxCoeff1.ForeColor = Color.FromArgb(231, 69, 47);
            TextBoxCoeff1.Location = new Point(147, 226);
            TextBoxCoeff1.Name = "TextBoxCoeff1";
            TextBoxCoeff1.Rounding = 50;
            TextBoxCoeff1.RoundingEnable = true;
            TextBoxCoeff1.SelectionStart = 0;
            TextBoxCoeff1.Size = new Size(97, 41);
            TextBoxCoeff1.TabIndex = 87;
            TextBoxCoeff1.TextAlign = HorizontalAlignment.Center;
            TextBoxCoeff1.TextInput = "0.25";
            TextBoxCoeff1.UseSystemPasswordChar = false;
            TextBoxCoeff1.TextChanged += TextBoxCoeff1_TextChanged;
            TextBoxCoeff1.KeyDown += TextBoxCoeff1_KeyDown;
            TextBoxCoeff1.KeyPress += textBox_KeyPress;

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
            textBoxMean.Location = new Point(185, 453);
            textBoxMean.MinimumSize = new Size(97, 41);
            textBoxMean.Name = "textBoxMean";
            textBoxMean.Rounding = 50;
            textBoxMean.RoundingEnable = true;
            textBoxMean.Size = new Size(97, 41);
            textBoxMean.TabIndex = 96;
            textBoxMean.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Symbol", 12.75F);
            label24.Location = new Point(197, 272);
            label24.Name = "label24";
            label24.Size = new Size(17, 21);
            label24.TabIndex = 54;
            label24.Text = "g";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12.75F);
            label21.Location = new Point(271, 196);
            label21.Name = "label21";
            label21.Size = new Size(111, 23);
            label21.TabIndex = 50;
            label21.Text = "1/(мин см2)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12.75F);
            label16.Location = new Point(3, 597);
            label16.Name = "label16";
            label16.Size = new Size(178, 23);
            label16.TabIndex = 44;
            label16.Text = "Среднеквадратичное";
            // 
            // TextBoxCoeff2
            // 
            TextBoxCoeff2.BackColor = Color.White;
            TextBoxCoeff2.BorderColor = Color.Black;
            TextBoxCoeff2.BorderColorEnabled = true;
            TextBoxCoeff2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxCoeff2.ForeColor = Color.FromArgb(231, 69, 47);
            TextBoxCoeff2.Location = new Point(147, 301);
            TextBoxCoeff2.Name = "TextBoxCoeff2";
            TextBoxCoeff2.Rounding = 50;
            TextBoxCoeff2.RoundingEnable = true;
            TextBoxCoeff2.SelectionStart = 0;
            TextBoxCoeff2.Size = new Size(97, 41);
            TextBoxCoeff2.TabIndex = 88;
            TextBoxCoeff2.TextAlign = HorizontalAlignment.Center;
            TextBoxCoeff2.TextInput = "2.55";
            TextBoxCoeff2.UseSystemPasswordChar = false;
            TextBoxCoeff2.TextChanged += TextBoxCoeff2_TextChanged;
            TextBoxCoeff2.KeyDown += TextBoxCoeff2_KeyDown;
            TextBoxCoeff2.KeyPress += textBox_KeyPress;
            
            // 
            // TextBoxResult2
            // 
            TextBoxResult2.AutoSize = true;
            TextBoxResult2.BackColor = Color.FromArgb(238, 238, 238);
            TextBoxResult2.BorderColor = Color.Black;
            TextBoxResult2.BorderColorEnabled = true;
            TextBoxResult2.BorderColorOnHover = Color.Black;
            TextBoxResult2.BorderColorOnHoverEnabled = true;
            TextBoxResult2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxResult2.ForeColor = Color.Black;
            TextBoxResult2.Location = new Point(275, 301);
            TextBoxResult2.MinimumSize = new Size(121, 41);
            TextBoxResult2.Name = "TextBoxResult2";
            TextBoxResult2.Rounding = 50;
            TextBoxResult2.RoundingEnable = true;
            TextBoxResult2.Size = new Size(121, 41);
            TextBoxResult2.TabIndex = 95;
            TextBoxResult2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(3, 308);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 55;
            label4.Text = "имп/с";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12.75F);
            label20.Location = new Point(271, 272);
            label20.Name = "label20";
            label20.Size = new Size(122, 23);
            label20.TabIndex = 49;
            label20.Text = "МАЭД, мкЗв/ч";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12.75F);
            label12.Location = new Point(3, 445);
            label12.Name = "label12";
            label12.Size = new Size(142, 23);
            label12.TabIndex = 42;
            label12.Text = "Математическое";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 12.75F);
            label31.Location = new Point(3, 623);
            label31.Name = "label31";
            label31.Size = new Size(102, 23);
            label31.TabIndex = 63;
            label31.Text = "отклонение";
            // 
            // TextBoxCurrentCPS
            // 
            TextBoxCurrentCPS.AutoSize = true;
            TextBoxCurrentCPS.BackColor = Color.FromArgb(238, 238, 238);
            TextBoxCurrentCPS.BorderColor = Color.Black;
            TextBoxCurrentCPS.BorderColorEnabled = true;
            TextBoxCurrentCPS.BorderColorOnHover = Color.Black;
            TextBoxCurrentCPS.BorderColorOnHoverEnabled = true;
            TextBoxCurrentCPS.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxCurrentCPS.ForeColor = Color.Black;
            TextBoxCurrentCPS.Location = new Point(299, 49);
            TextBoxCurrentCPS.MinimumSize = new Size(100, 41);
            TextBoxCurrentCPS.Name = "TextBoxCurrentCPS";
            TextBoxCurrentCPS.Rounding = 50;
            TextBoxCurrentCPS.RoundingEnable = true;
            TextBoxCurrentCPS.Size = new Size(100, 41);
            TextBoxCurrentCPS.TabIndex = 89;
            TextBoxCurrentCPS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 12.75F);
            label26.Location = new Point(3, 176);
            label26.Name = "label26";
            label26.Size = new Size(77, 23);
            label26.TabIndex = 56;
            label26.Text = "Средняя";
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
            textBoxDistrSum.Location = new Point(185, 378);
            textBoxDistrSum.MinimumSize = new Size(97, 41);
            textBoxDistrSum.Name = "textBoxDistrSum";
            textBoxDistrSum.Rounding = 50;
            textBoxDistrSum.RoundingEnable = true;
            textBoxDistrSum.Size = new Size(97, 41);
            textBoxDistrSum.TabIndex = 94;
            textBoxDistrSum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12.75F);
            label19.Location = new Point(245, 172);
            label19.Margin = new Padding(0);
            label19.Name = "label19";
            label19.Size = new Size(151, 23);
            label19.TabIndex = 48;
            label19.Text = "Плотность потока";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 24F);
            label5.Location = new Point(243, 294);
            label5.Name = "label5";
            label5.Size = new Size(42, 45);
            label5.TabIndex = 59;
            label5.Text = "=";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label30.Location = new Point(199, 131);
            label30.Name = "label30";
            label30.Size = new Size(25, 25);
            label30.TabIndex = 62;
            label30.Text = "c:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12.75F);
            label15.Location = new Point(3, 534);
            label15.Name = "label15";
            label15.Size = new Size(96, 23);
            label15.TabIndex = 43;
            label15.Text = "Дисперсия";
            // 
            // TextBoxSumCPS
            // 
            TextBoxSumCPS.AutoSize = true;
            TextBoxSumCPS.BackColor = Color.FromArgb(238, 238, 238);
            TextBoxSumCPS.BorderColor = Color.Black;
            TextBoxSumCPS.BorderColorEnabled = true;
            TextBoxSumCPS.BorderColorOnHover = Color.Black;
            TextBoxSumCPS.BorderColorOnHoverEnabled = true;
            TextBoxSumCPS.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxSumCPS.ForeColor = Color.Black;
            TextBoxSumCPS.Location = new Point(263, 115);
            TextBoxSumCPS.MinimumSize = new Size(135, 41);
            TextBoxSumCPS.Name = "TextBoxSumCPS";
            TextBoxSumCPS.Rounding = 50;
            TextBoxSumCPS.RoundingEnable = true;
            TextBoxSumCPS.Size = new Size(135, 41);
            TextBoxSumCPS.TabIndex = 90;
            TextBoxSumCPS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Symbol", 24F, FontStyle.Bold, GraphicsUnit.Point, 2);
            label29.Location = new Point(107, 257);
            label29.Name = "label29";
            label29.Size = new Size(36, 39);
            label29.TabIndex = 60;
            label29.Text = "";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12.75F);
            label27.Location = new Point(3, 202);
            label27.Name = "label27";
            label27.Size = new Size(80, 23);
            label27.TabIndex = 57;
            label27.Text = "скорость";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12.75F);
            label17.Location = new Point(3, 385);
            label17.Name = "label17";
            label17.Size = new Size(174, 23);
            label17.TabIndex = 45;
            label17.Text = "Количество событий";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12.75F);
            label18.Location = new Point(3, 469);
            label18.Name = "label18";
            label18.Size = new Size(90, 23);
            label18.TabIndex = 47;
            label18.Text = "ожидание";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 12.75F);
            label28.Location = new Point(3, 228);
            label28.Name = "label28";
            label28.Size = new Size(53, 23);
            label28.TabIndex = 58;
            label28.Text = "счёта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(104, 131);
            label2.Name = "label2";
            label2.Size = new Size(30, 25);
            label2.TabIndex = 61;
            label2.Text = "за";
            // 
            // TextBoxAverageCPS
            // 
            TextBoxAverageCPS.AutoSize = true;
            TextBoxAverageCPS.BackColor = Color.FromArgb(238, 238, 238);
            TextBoxAverageCPS.BorderColor = Color.Black;
            TextBoxAverageCPS.BorderColorEnabled = true;
            TextBoxAverageCPS.BorderColorOnHover = Color.Black;
            TextBoxAverageCPS.BorderColorOnHoverEnabled = true;
            TextBoxAverageCPS.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TextBoxAverageCPS.ForeColor = Color.Black;
            TextBoxAverageCPS.Location = new Point(5, 262);
            TextBoxAverageCPS.MinimumSize = new Size(97, 41);
            TextBoxAverageCPS.Name = "TextBoxAverageCPS";
            TextBoxAverageCPS.Rounding = 50;
            TextBoxAverageCPS.RoundingEnable = true;
            TextBoxAverageCPS.Size = new Size(97, 41);
            TextBoxAverageCPS.TabIndex = 91;
            TextBoxAverageCPS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.TabIndex = 42;
            tabControl1.Selected += TabControl1_Selected;

            // убираем кнопки управления панелями
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;            

            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(LabelSimpleTime);
            tabPage1.Controls.Add(LabelSimpleAverage);
            tabPage1.Controls.Add(label34);
            tabPage1.Controls.Add(rToggleSwitch1);
            tabPage1.Controls.Add(ButtonSimpleStop);
            tabPage1.Controls.Add(ButtonSimpleStart);
            tabPage1.Controls.Add(PictureConnectionStatus);
            tabPage1.Controls.Add(label33);
            tabPage1.Controls.Add(label14);
            tabPage1.Location = new Point(4, 5);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1227, 670);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Simple";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(320, 110);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 83;
            label1.Text = "Время счёта, с";
          
            // 
            // LabelSimpleTime
            // 
            LabelSimpleTime.AutoSize = false;
            LabelSimpleTime.BackColor = Color.Transparent;
            LabelSimpleTime.BorderColor = Color.Black;
            LabelSimpleTime.BorderColorEnabled = true;
            LabelSimpleTime.BorderColorOnHover = Color.Black;
            LabelSimpleTime.BorderColorOnHoverEnabled = true;
            LabelSimpleTime.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelSimpleTime.ForeColor = Color.Black;
            LabelSimpleTime.Location = new Point(345, 150);
            LabelSimpleTime.MinimumSize = new Size(91, 51);
            LabelSimpleTime.Name = "LabelSimpleTime";
            LabelSimpleTime.Rounding = 50;
            LabelSimpleTime.RoundingEnable = true;
            LabelSimpleTime.Size = new Size(91, 51);
            LabelSimpleTime.TabIndex = 82;
            LabelSimpleTime.Text = "000";
            LabelSimpleTime.TextAlign = ContentAlignment.MiddleCenter;
          
            // 
            // LabelSimpleAverage
            // 
            LabelSimpleAverage.AutoSize = false;
            LabelSimpleAverage.BackColor = Color.Transparent;
            LabelSimpleAverage.BorderColor = Color.Black;
            LabelSimpleAverage.BorderColorEnabled = true;
            LabelSimpleAverage.BorderColorOnHover = Color.Black;
            LabelSimpleAverage.BorderColorOnHoverEnabled = true;
            LabelSimpleAverage.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelSimpleAverage.ForeColor = Color.Black;
            LabelSimpleAverage.Location = new Point(13, 150);
            LabelSimpleAverage.MinimumSize = new Size(247, 51);
            LabelSimpleAverage.Name = "LabelSimpleAverage";
            LabelSimpleAverage.Rounding = 50;
            LabelSimpleAverage.RoundingEnable = true;
            LabelSimpleAverage.Size = new Size(247, 51);
            LabelSimpleAverage.TabIndex = 81;
            LabelSimpleAverage.Text = "000";
            LabelSimpleAverage.TextAlign = ContentAlignment.MiddleCenter;
          
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label34.Location = new Point(10, 110);
            label34.Name = "label34";
            label34.Size = new Size(210, 25);
            label34.TabIndex = 78;
            label34.Text = "Скорость счёта, имп./с";

            // 
            // rToggleSwitch1
            // 
            rToggleSwitch1.BackColor = Color.White;
            rToggleSwitch1.BackColorOFF = Color.FromArgb(231, 69, 47);
            rToggleSwitch1.BackColorON = Color.FromArgb(39, 174, 96);
            rToggleSwitch1.Checked = false;
            rToggleSwitch1.Font = new Font("Verdana", 9F);
            rToggleSwitch1.Location = new Point(17, 41);
            rToggleSwitch1.Name = "rToggleSwitch1";
            rToggleSwitch1.Size = new Size(73, 43);
            rToggleSwitch1.TabIndex = 77;
            rToggleSwitch1.TextOnChecked = "";
            rToggleSwitch1.ToogleSwitchWidth = 70;
            rToggleSwitch1.CheckedChanged += ToggleSwitch1_CheckedChanged;
            // 
            // ButtonSimpleStop
            // 
            ButtonSimpleStop.BackColor = Color.Transparent;
            ButtonSimpleStop.BorderColor = Color.Black;
            ButtonSimpleStop.BorderColorEnabled = true;
            ButtonSimpleStop.BorderColorOnHover = Color.Black;
            ButtonSimpleStop.BorderColorOnHoverEnabled = true;
            ButtonSimpleStop.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            ButtonSimpleStop.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonSimpleStop.Location = new Point(143, 263);
            ButtonSimpleStop.Name = "ButtonSimpleStop";
            ButtonSimpleStop.Rounding = 50;
            ButtonSimpleStop.RoundingEnable = true;
            ButtonSimpleStop.Size = new Size(121, 51);
            ButtonSimpleStop.TabIndex = 76;
            ButtonSimpleStop.Text = "СТОП";
            ButtonSimpleStop.UseVisualStyleBackColor = false;
            ButtonSimpleStop.UseZoomEffectOnHover = true;
            ButtonSimpleStop.Click += SimpleCountStop;
            // 
            // ButtonSimpleStart
            // 
            ButtonSimpleStart.BackColor = Color.Transparent;
            ButtonSimpleStart.BorderColor = Color.Black;
            ButtonSimpleStart.BorderColorEnabled = true;
            ButtonSimpleStart.BorderColorOnHover = Color.Black;
            ButtonSimpleStart.BorderColorOnHoverEnabled = true;
            ButtonSimpleStart.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            ButtonSimpleStart.ForeColor = Color.FromArgb(231, 69, 47);
            ButtonSimpleStart.Location = new Point(17, 263);
            ButtonSimpleStart.Name = "ButtonSimpleStart";
            ButtonSimpleStart.Rounding = 50;
            ButtonSimpleStart.RoundingEnable = true;
            ButtonSimpleStart.Size = new Size(121, 51);
            ButtonSimpleStart.TabIndex = 75;
            ButtonSimpleStart.Text = "ПУСК";
            ButtonSimpleStart.UseVisualStyleBackColor = false;
            ButtonSimpleStart.UseZoomEffectOnHover = true;
            ButtonSimpleStart.Click += SimpleCountStart;
            // 
            // PictureConnectionStatus
            // 
            PictureConnectionStatus.Location = new Point(463, 12);
            PictureConnectionStatus.Name = "PictureConnectionStatus";
            PictureConnectionStatus.Size = new Size(23, 23);
            PictureConnectionStatus.TabIndex = 74;
            PictureConnectionStatus.TabStop = false;
            PictureConnectionStatus.Paint += ConnectionStatusPaint;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label33.Location = new Point(338, 7);
            label33.Name = "label33";
            label33.Size = new Size(119, 25);
            label33.TabIndex = 72;
            label33.Text = "Соединение";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label14.Location = new Point(13, 7);
            label14.Name = "label14";
            label14.Size = new Size(199, 25);
            label14.TabIndex = 71;
            label14.Text = "Расширенный режим";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(pictureBox4);
            tabPage2.Controls.Add(label36);
            tabPage2.Controls.Add(rToggleSwitch2);
            tabPage2.Controls.Add(label35);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new Point(4, 5);
            tabPage2.Margin = new Padding(0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1227, 670);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advance";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(463, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(20, 23);
            pictureBox4.TabIndex = 80;
            pictureBox4.TabStop = false;
            pictureBox4.Visible = false;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Segoe UI", 12.75F);
            label36.Location = new Point(338, 7);
            label36.Name = "label36";
            label36.Size = new Size(107, 23);
            label36.TabIndex = 79;
            label36.Text = "Соединение";
            label36.Visible = false;
            // 
            // rToggleSwitch2
            // 
            rToggleSwitch2.BackColor = Color.White;
            rToggleSwitch2.BackColorOFF = Color.FromArgb(231, 69, 47);
            rToggleSwitch2.BackColorON = Color.FromArgb(39, 174, 96);
            rToggleSwitch2.Checked = true;
            rToggleSwitch2.Font = new Font("Verdana", 9F);
            rToggleSwitch2.Location = new Point(13, 37);
            rToggleSwitch2.Name = "rToggleSwitch2";
            rToggleSwitch2.Size = new Size(73, 43);
            rToggleSwitch2.TabIndex = 78;
            rToggleSwitch2.TextOnChecked = "";
            rToggleSwitch2.ToogleSwitchWidth = 70;
            rToggleSwitch2.Visible = false;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Segoe UI", 12.75F);
            label35.Location = new Point(13, 7);
            label35.Name = "label35";
            label35.Size = new Size(181, 23);
            label35.TabIndex = 72;
            label35.Text = "Расширенный режим";
            label35.Visible = false;
            // 
            // roundingButtonsComponent1
            // 
            roundingButtonsComponent1.Rounding = 50;
            roundingButtonsComponent1.RoundingEnable = true;
            roundingButtonsComponent1.TargetForm = this;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            MinimumSize = new Size(520, 390);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.White;
            Size = new Size(520, 390);
            //ClientSize = new Size(520, 390);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "RadLab";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            Resize += FormMain_Resize;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCPS).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDistribution).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureConnectionStatus).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCPS;
        private System.Windows.Forms.Timer MainTimer;
        private ToolTip ToolTipComboBoxPortName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;        
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label14;
        private Label LabelCurrentTimeFilter;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label15;
        private Label label12;
        private Label label17;
        private Label label16;
        private Label label8;
        private Label label13;
        private Label LabelDistributionTimeFilter;
        private Label label18;
        private Label label20;
        private Label label19;
        private Label label22;
        private Label label21;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label24;
        private Label label25;
        private Label label23;
        private Label label29;
        private Label label31;
        private Label label30;
        private Button ButtonNavMinus;
        private Button ButtonNavPlus;
        private Label label32;
        private Button ButtonNavEnd;
        private Button ButtonNavRight;
        private Button ButtonNavLeft;
        private Button ButtonNavStart;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label33;
        private PictureBox PictureConnectionStatus;
        private RButton ButtonSimpleStart;
        private RButton ButtonSimpleStop;
        private RoundingButtonsComponent roundingButtonsComponent1;
        private RToggleSwitch rToggleSwitch1;
        private Label label34;
        private RLabel LabelSimpleAverage;
        private RLabel LabelSimpleTime;
        private Label label1;
        private Label label35;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private RButton ButtonStartStop;
        private RButton ButtonDistrExport;
        private RButton ButtonDistrReset;
        private RButton ButtonDistrArchive;
        private PictureBox pictureBox4;
        private Label label36;
        private RToggleSwitch rToggleSwitch2;
        private RTextBox TextBoxTimeFilter;
        private RTextBox TextBoxTimeDistribution;
        private RTextBox TextBoxCoeff1;
        private RTextBox TextBoxCoeff2;
        private RLabel TextBoxCurrentCPS;
        private RLabel TextBoxSumCPS;
        private RLabel TextBoxResult2;
        private RLabel textBoxDistrSum;
        private RLabel TextBoxResult1;
        private RLabel TextBoxAverageCPS;
        private RLabel textBoxSigma;
        private RLabel textBoxVariance;
        private RLabel textBoxMean;
        private Label label37;
    }
}
