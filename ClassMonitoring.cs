using System.Windows.Forms.DataVisualization.Charting;

namespace RadLab
{
    internal class ClassMonitoring
    {
        public class ChartMonitoring()
        {
            public Chart chart = new();
            public DateTime EndDateTime = DateTime.Now;
            public DateTime StartDateTime = DateTime.Now.AddMinutes(-10);
            public bool IsCurrentDateTime = true;
            public bool IsArchive = false;
            public int DeltaXScaleView = 60;
            public DateTime SelectionEndDateTime = DateTime.Now;
            public DateTime SelectionStartDateTime = DateTime.Now;
            public bool SelectionChanged = false;

            public void Initialize()
            {

                //ScaleXTotal = ScaleX.ElementAt(ScaleXIndex).Key;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                //chart.ChartAreas[0].AxisX.Interval = ScaleX.ElementAt(ScaleXIndex).Value;
                chart.ChartAreas[0].CursorX.AutoScroll = false;
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Seconds;
                //chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1D;

                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 1000;
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "F6";
                chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisY.ScrollBar.Enabled = false;

                chart.CursorPositionChanged += CursorPositionChanged;
                chart.CursorPositionChanging += CursorPositionChanging;
                chart.PreviewKeyDown += PreviewKeyDown;
                chart.MouseWheel += MouseWheel;
                chart.DoubleClick += DoubleClick;
                chart.AxisViewChanged += AxisViewChanged;
                chart.Paint += PostPaint;

                foreach (Series s in chart.Series)
                {
                    s.Enabled = false;
                }
            }

            public enum ZoomAxisAction
            {
                Left = 1,
                Right = 2,
                Plus = 3,
                Minus = 4,
                ToStart = 5,
                ToEnd = 6
            }

            public void SetIsCurrentDateTime(bool Val)
            {
                if (!IsArchive)
                {
                    IsCurrentDateTime = Val;
                }
            }

            public void DeltaXScaleViewChange(ZoomAxisAction action)
            {
                try
                {
                    int PreDeltaXScaleView = DeltaXScaleView;
                    if (action == ZoomAxisAction.Minus)
                    {
                        if (DeltaXScaleView < 10) DeltaXScaleView = 10;
                        else if (DeltaXScaleView < 30) DeltaXScaleView = 30;
                        else if (DeltaXScaleView < 60) DeltaXScaleView = 60;
                        else if (DeltaXScaleView < 120) DeltaXScaleView = 120;
                        else if (DeltaXScaleView < 180) DeltaXScaleView = 180;
                        else if (DeltaXScaleView < 300) DeltaXScaleView = 300;
                        else if (DeltaXScaleView < 600) DeltaXScaleView = 600;
                        else if (DeltaXScaleView < 1200) DeltaXScaleView = 1200;
                        else if (DeltaXScaleView < 1800) DeltaXScaleView = 1800;
                        else if (DeltaXScaleView < 3600) DeltaXScaleView = 3600;
                        else if (DeltaXScaleView < 7200) DeltaXScaleView = 7200;
                        else if (DeltaXScaleView < 10800) DeltaXScaleView = 10800;
                        else if (DeltaXScaleView < 14400) DeltaXScaleView = 14400;
                        else if (DeltaXScaleView < 21600) DeltaXScaleView = 21600;
                        else if (DeltaXScaleView < 43200) DeltaXScaleView = 43200;
                        else DeltaXScaleView = 86400;
                    }
                    if (action == ZoomAxisAction.Plus)
                    {
                        if (DeltaXScaleView > 43200) DeltaXScaleView = 43200;
                        else if (DeltaXScaleView > 21600) DeltaXScaleView = 21600;
                        else if (DeltaXScaleView > 14400) DeltaXScaleView = 14400;
                        else if (DeltaXScaleView > 10800) DeltaXScaleView = 10800;
                        else if (DeltaXScaleView > 7200) DeltaXScaleView = 7200;
                        else if (DeltaXScaleView > 3600) DeltaXScaleView = 3600;
                        else if (DeltaXScaleView > 1800) DeltaXScaleView = 1800;
                        else if (DeltaXScaleView > 1200) DeltaXScaleView = 1200;
                        else if (DeltaXScaleView > 600) DeltaXScaleView = 600;
                        else if (DeltaXScaleView > 300) DeltaXScaleView = 300;
                        else if (DeltaXScaleView > 180) DeltaXScaleView = 180;
                        else if (DeltaXScaleView > 120) DeltaXScaleView = 120;
                        else if (DeltaXScaleView > 60) DeltaXScaleView = 60;
                        else if (DeltaXScaleView > 30) DeltaXScaleView = 30;
                        else DeltaXScaleView = 10;
                    }

                    if (action == ZoomAxisAction.Plus || action == ZoomAxisAction.Minus)
                    {
                        DataPoint? Dp = chart.Series["CurrentCPS"].Points.LastOrDefault();
                        DataPoint? Sp = chart.Series["CurrentCPS"].Points.FirstOrDefault();
                        if (Dp != null && Sp != null)
                        {
                            double pos = chart.ChartAreas[0].CursorX.Position;
                            double ViewMinimum = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                            double ViewMaximum = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                            DateTime MiddleView = DateTime.FromOADate((ViewMaximum + ViewMinimum) / 2);
                            DateTime StartPoint = DateTime.FromOADate(Sp.XValue);
                            DateTime EndPoint = DateTime.FromOADate(Dp.XValue);
                            if (IsArchive && action == ZoomAxisAction.Minus && (EndPoint - StartPoint).TotalSeconds <= PreDeltaXScaleView) { DeltaXScaleView = PreDeltaXScaleView; }
                            if (pos is not double.NaN)
                            {
                                //if (pos >= ViewMinimum && pos <= ViewMaximum)
                                //{
                                MiddleView = DateTime.FromOADate(pos);
                                DateTime StartView = MiddleView.AddSeconds(-DeltaXScaleView / 2);
                                DateTime EndView = MiddleView.AddSeconds(DeltaXScaleView / 2);
                                if (EndPoint < EndView)
                                {
                                    SetIsCurrentDateTime(true);
                                    EndDateTime = EndPoint;
                                    StartDateTime = EndDateTime.AddSeconds(-DeltaXScaleView);
                                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartDateTime.ToOADate(), EndDateTime.ToOADate());
                                }
                                else
                                {
                                    SetIsCurrentDateTime(false);
                                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                                }
                                //}
                            }
                            else
                            {
                                if (IsCurrentDateTime)
                                {
                                    EndDateTime = EndPoint;
                                    StartDateTime = EndDateTime.AddSeconds(-DeltaXScaleView);
                                    DateTime StartView = DateTime.FromOADate(Sp.XValue);
                                    if (StartView > StartDateTime)
                                    {
                                        chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                                    }
                                    else
                                    {
                                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartDateTime.ToOADate(), EndDateTime.ToOADate());
                                    }
                                }
                                else
                                {
                                    DateTime StartView = MiddleView.AddSeconds(-DeltaXScaleView / 2);
                                    DateTime EndView = MiddleView.AddSeconds(DeltaXScaleView / 2);
                                    if (EndPoint < EndView)
                                    {
                                        SetIsCurrentDateTime(true);
                                        EndDateTime = EndPoint;
                                        StartDateTime = EndDateTime.AddSeconds(-DeltaXScaleView);
                                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartDateTime.ToOADate(), EndDateTime.ToOADate());
                                    }
                                    else
                                    {
                                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                                    }
                                }
                            }
                        }
                    }

                    if (action == ZoomAxisAction.ToStart)
                    {
                        DataPoint? Dp = chart.Series["CurrentCPS"].Points.LastOrDefault();
                        DataPoint? Sp = chart.Series["CurrentCPS"].Points.FirstOrDefault();
                        if (Dp != null && Sp != null)
                        {

                            DateTime StartView = DateTime.FromOADate(Sp.XValue);
                            DateTime EndView = StartView.AddSeconds(DeltaXScaleView);
                            DateTime EndPoint = DateTime.FromOADate(Dp.XValue);
                            if (EndView > EndPoint) { EndView = EndPoint; }
                            SetIsCurrentDateTime(false);
                            chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                        }
                    }

                    if (action == ZoomAxisAction.ToEnd)
                    {
                        DataPoint? Dp = chart.Series["CurrentCPS"].Points.LastOrDefault();
                        if (Dp != null)
                        {
                            DateTime EndView = DateTime.FromOADate(Dp.XValue);
                            DateTime StartView = EndView.AddSeconds(-DeltaXScaleView);
                            SetIsCurrentDateTime(true);
                            chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                        }
                    }

                    if (action == ZoomAxisAction.Left)
                    {
                        DataPoint? Sp = chart.Series["CurrentCPS"].Points.FirstOrDefault();
                        if (Sp != null)
                        {
                            DateTime StartView = DateTime.FromOADate(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
                            DateTime StartPoint = DateTime.FromOADate(Sp.XValue);
                            if (StartView > StartPoint)
                            {
                                StartView = StartView.AddSeconds(-DeltaXScaleView * 0.25);
                                DateTime EndView = StartView.AddSeconds(DeltaXScaleView);
                                SetIsCurrentDateTime(false);
                                chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                            }
                        }
                    }

                    if (action == ZoomAxisAction.Right)
                    {
                        DataPoint? Dp = chart.Series["CurrentCPS"].Points.LastOrDefault();
                        if (Dp != null)
                        {
                            DateTime EndView = DateTime.FromOADate(chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);
                            DateTime EndPoint = DateTime.FromOADate(Dp.XValue);
                            if (EndView < EndPoint)
                            {
                                EndView = EndView.AddSeconds(DeltaXScaleView * 0.25);
                                if (EndView > DateTime.Now.AddSeconds(-1))
                                {
                                    SetIsCurrentDateTime(true);
                                }
                                DateTime StartView = EndView.AddSeconds(-DeltaXScaleView);
                                chart.ChartAreas[0].AxisX.ScaleView.Zoom(StartView.ToOADate(), EndView.ToOADate());
                            }
                        }
                    }
                }
                catch { }
            }

            private void AxisViewChanged(object? sender, ViewEventArgs e)
            {
                if (chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum > DateTime.Now.AddSeconds(-1).ToOADate())
                {
                    SetIsCurrentDateTime(true);
                }
                else
                {
                    SetIsCurrentDateTime(false);
                }
            }

            private void PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
            {
                try
                {
                    double pos = chart.ChartAreas[0].CursorX.Position;
                    double min = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double max = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    if (e.KeyCode == Keys.Left)
                    {
                        if (double.IsNaN(pos))
                        {
                            pos = max;
                        }
                        else
                        {
                            if (pos > min)
                            {
                                pos = DateTime.FromOADate(pos).AddSeconds(-1).ToOADate();
                            }
                        }
                        chart.Focus();
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        if (double.IsNaN(pos))
                        {
                            pos = min;
                        }
                        else
                        {
                            if (pos < max)
                            {
                                pos = DateTime.FromOADate(pos).AddSeconds(1).ToOADate();
                            }
                        }
                        chart.Focus();
                    }
                    chart.ChartAreas[0].CursorX.Position = pos;
                    DateTime StartTime = DateTime.FromOADate(pos);
                    SelectionStart1 = pos;
                    SelectionEnd1 = pos;
                }
                catch { }
            }

            private void DoubleClick(object? sender, EventArgs e)
            {
                chart.ChartAreas[0].CursorX.Position = double.NaN;
                DeltaXScaleViewChange(ZoomAxisAction.ToEnd);
            }

            private void MouseWheel(object? sender, MouseEventArgs e)
            {
                if (sender != null)
                {
                    Chart chart = (Chart)sender;
                    if (Control.ModifierKeys.Equals(Keys.Control))
                    {
                        if (e.Delta < 0)
                        {
                            DeltaXScaleViewChange(ZoomAxisAction.Minus);
                        }
                        else if (e.Delta > 0)
                        {
                            DeltaXScaleViewChange(ZoomAxisAction.Plus);
                        }
                    }
                    else if (Control.ModifierKeys.Equals(Keys.Shift))
                    {
                        if (e.Delta < 0)
                        {
                            DeltaXScaleViewChange(ZoomAxisAction.Left);
                        }
                        else if (e.Delta > 0)
                        {
                            DeltaXScaleViewChange(ZoomAxisAction.Right);
                        }
                    }
                    else
                    {
                        Axis AxisY = chart.ChartAreas[0].AxisY;
                        double MaxY = AxisY.Maximum;
                        double SizeY = AxisY.ScaleView.Size;
                        if (double.IsNaN(SizeY))
                        {
                            SizeY = MaxY;
                        }
                        if (e.Delta < 0)
                        {
                            SizeY *= 1.25;
                            if (SizeY > MaxY)
                            {
                                AxisY.ScaleView.ZoomReset();
                            }
                            else
                            {
                                AxisY.ScaleView.Zoom(0, SizeY);
                            }
                        }
                        else if (e.Delta > 0)
                        {
                            SizeY /= 1.25;
                            AxisY.ScaleView.Zoom(0, SizeY);
                        }
                        Axis axis = chart.ChartAreas[0].AxisY;
                        axis.Interval = AxisAutoScale(0, SizeY, chart.Height / 50);
                        if (SizeY <= 0.00012) { axis.LabelStyle.Format = "F6"; }
                        else if (SizeY <= 0.0012) { axis.LabelStyle.Format = "F5"; }
                        else if (SizeY <= 0.012) { axis.LabelStyle.Format = "F4"; }
                        else if (SizeY <= 0.12) { axis.LabelStyle.Format = "F3"; }
                        else if (SizeY <= 1.2) { axis.LabelStyle.Format = "F2"; }
                        else { axis.LabelStyle.Format = "F0"; }
                    }
                }
            }

            public void AutoScaleX()
            {
                int OptimalCountsOfInterval = (int)(chart.Width / 100);
                TimeSpan Diff = EndDateTime - StartDateTime;
                double OptimalInterval = Diff.TotalSeconds / OptimalCountsOfInterval;
                double Interval = 1;
                if (OptimalInterval < 1) { Interval = 1; }
                else if (OptimalInterval < 2) { Interval = 2; }
                else if (OptimalInterval < 5) { Interval = 5; }
                else if (OptimalInterval < 10) { Interval = 10; }
                else if (OptimalInterval < 20) { Interval = 20; }
                else if (OptimalInterval < 30) { Interval = 30; }
                else if (OptimalInterval < 60) { Interval = 60; }
                else if (OptimalInterval < 120) { Interval = 120; }
                else if (OptimalInterval < 300) { Interval = 300; }
                else if (OptimalInterval < 600) { Interval = 600; }
                else if (OptimalInterval < 1200) { Interval = 1200; }
                else if (OptimalInterval < 1800) { Interval = 1800; }
                else if (OptimalInterval < 3600) { Interval = 3600; }
                else if (OptimalInterval < 7200) { Interval = 7200; }
                else if (OptimalInterval < 14400) { Interval = 14400; }
                else if (OptimalInterval < 21600) { Interval = 21600; }
                else if (OptimalInterval < 43200) { Interval = 43200; }
                else if (OptimalInterval < 86400) { Interval = 86400; }

                //ScaleXTotal = ScaleX.ElementAt(ScaleXIndex).Key;
                //chart.ChartAreas[0].AxisX.Minimum = StartDateTime.ToOADate();
                DataPoint? Dp = chart.Series["CurrentCPS"].Points.FirstOrDefault();
                if (Dp != null)
                {
                    chart.ChartAreas[0].AxisX.Minimum = Dp.XValue;
                    chart.ChartAreas[0].AxisX.Maximum = EndDateTime.ToOADate();
                    //chart.ChartAreas[0].AxisX.Interval = ScaleX.ElementAt(ScaleXIndex).Value;
                    chart.ChartAreas[0].AxisX.Interval = Interval;
                }
            }

            public void AutoScaleY()
            {
                List<double> maxYd = [];
                try
                {
                    foreach (Series s in chart.Series)
                    {
                        if (s.Enabled)
                        {
                            maxYd.Add(1.1 * s.Points.Where(point => point.XValue >= chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum && point.XValue <= chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum).Select(point => point.YValues[0]).Max());
                        }
                    }
                    double maxY = maxYd.Max();

                    Axis axis = chart.ChartAreas[0].AxisY;
                    if (maxY < 1) maxY = 1;
                    axis.Maximum = maxY;
                    //chart.ChartAreas[0].AxisY.Interval = AxisAutoScale(0, maxY, chart.Height / 50);
                    double SizeY = axis.ScaleView.Size;
                    if (double.IsNaN(SizeY))
                    {
                        SizeY = maxY;
                    }
                    double Interval = AxisAutoScale(0, SizeY, chart.Height / 50);
                    if (Interval < 1) { Interval = 1; }
                    axis.Interval = Interval;
                    if (SizeY <= 0.0001) { axis.LabelStyle.Format = "F6"; }
                    else if (SizeY <= 0.001) { axis.LabelStyle.Format = "F5"; }
                    else if (SizeY <= 0.01) { axis.LabelStyle.Format = "F4"; }
                    else if (SizeY <= 0.1) { axis.LabelStyle.Format = "F3"; }
                    else if (SizeY <= 1.0) { axis.LabelStyle.Format = "F2"; }
                    else { axis.LabelStyle.Format = "F0"; }
                }
                catch { }
            }

            public void AutoScale()
            {
                AutoScaleX();
                AutoScaleY();
            }

            double SelectionStart1 = 0;
            double SelectionEnd1 = 0;

            private void CursorPositionChanging(object? sender, CursorEventArgs e)
            {
                SelectionStart1 = chart.ChartAreas[0].CursorX.SelectionStart;
                SelectionEnd1 = chart.ChartAreas[0].CursorX.SelectionEnd;
                if (SelectionStart1 is double.NaN || SelectionEnd1 is double.NaN)
                {
                    SelectionStart1 = chart.ChartAreas[0].CursorX.Position;
                    SelectionEnd1 = SelectionStart1;
                }
            }

            private void CursorPositionChanged(object? sender, CursorEventArgs e)
            {
                double SelectionStart = chart.ChartAreas[0].CursorX.SelectionStart;
                double SelectionEnd = chart.ChartAreas[0].CursorX.SelectionEnd;
                if (SelectionStart is double.NaN || SelectionEnd is double.NaN)
                {
                    SelectionStart = SelectionStart1;
                    SelectionEnd = SelectionEnd1;
                }
                if (SelectionEnd < SelectionStart)
                {
                    (SelectionStart, SelectionEnd) = (SelectionEnd, SelectionStart);
                }
                DateTime StartTime = DateTime.FromOADate(SelectionStart);
                DateTime EndTime = DateTime.FromOADate(SelectionEnd);
                SelectionStartDateTime = StartTime;
                SelectionEndDateTime = EndTime;
                SelectionChanged = true;
            }

            private void PostPaint(object? sender, PaintEventArgs e)
            {
                double SizeY = chart.ChartAreas[0].AxisY.ScaleView.Size;
                if (double.IsNaN(SizeY))
                {
                    Graphics g = e.Graphics;
                    Font DrawFont = new("Arial", 11.25F, FontStyle.Bold); ;
                    //Brush DrawBrush = Brushes.Black;
                    Brush DrawBrush = Brushes.LightGray;
                    string Txt = Localization.GetString("Auto");

                    float StrWidth = g.MeasureString(Txt, DrawFont).Width;
                    float Width = StrWidth;
                    float TxtHeight = g.MeasureString(Txt, DrawFont).Height;
                    double xpos = chart.ChartAreas[0].AxisX.ValueToPixelPosition(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum)+10; //50;
                    double ypos = 25;
                    int x = (int)(xpos - Width / 2.0);
                    int y = (int)(ypos - TxtHeight);

                    Rectangle rect = new(x - 1, y - 1, (int)Width + 1, (int)TxtHeight + 2);
                    g.FillRectangle(Brushes.White, rect);
                    g.DrawRectangle(Pens.LightGray, rect);
                    g.DrawString(Txt, DrawFont, DrawBrush, x, y);
                }

                SelectionStart1 = chart.ChartAreas[0].CursorX.Position;
                if (SelectionStart1 is not double.NaN)
                {
                    DateTime CursorTime = DateTime.FromOADate(SelectionStart1);
                    DateTime StartView = DateTime.FromOADate(chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
                    DateTime EndView = DateTime.FromOADate(chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum);

                    if (SelectionStart1 > chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum && SelectionStart1 < chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum)
                    {
                        DataPoint? t = null;
                        DataPoint? t1 = chart.Series[0].Points.Where(point => point.XValue >= CursorTime.ToOADate() && point.XValue <= CursorTime.AddSeconds(1).ToOADate()).FirstOrDefault();
                        DataPoint? t2 = chart.Series[0].Points.Where(point => point.XValue <= CursorTime.ToOADate() && point.XValue >= CursorTime.AddSeconds(-1).ToOADate()).LastOrDefault();
                        if (t1 != null && t2 == null) { t = t1; }
                        if (t1 == null && t2 != null) { t = t2; }
                        if (t1 != null && t2 != null) { t = t2; }
                        if (t != null)
                        {
                            DataPoint? t3 = chart.Series[1].Points.Where(point => point.XValue == t.XValue).FirstOrDefault();

                            if (t3 != null)
                            {
                                double Avg = t3.YValues[0];
                                string StrTime = DateTime.FromOADate(t3.XValue).ToString("HH:mm:ss");
                                string StrCps = ((int)t.YValues[0]).ToString() + ", ";
                                string StrAvg = "";
                                if (Avg >= 1000)
                                {
                                    StrAvg = Avg.ToString("f0");
                                }
                                else if (Avg >= 100)
                                {
                                    StrAvg = Avg.ToString("##0.#");
                                }
                                else if (Avg >= 10)
                                {
                                    StrAvg = Avg.ToString("#0.##");
                                }
                                else if (Avg >= 1)
                                {
                                    StrAvg = Avg.ToString("0.###");
                                }
                                else
                                {
                                    StrAvg = Avg.ToString("0.####");
                                }

                                Graphics g = e.Graphics;
                                Font DrawFont = new("Arial", 11F, FontStyle.Bold);
                                Font DrawTimeFont = new("Arial", 11F, FontStyle.Regular);
                                Brush DrawBrush = Brushes.Black;

                                Brush BrushCps = new SolidBrush(chart.Series[0].Color);
                                Brush BrushAvg = new SolidBrush(chart.Series[1].Color);

                                float StrCpsWidth = g.MeasureString(StrCps, DrawFont).Width;
                                float StrAvgWidth = g.MeasureString(StrAvg, DrawFont).Width;
                                float TimeWidth = g.MeasureString(StrTime, DrawTimeFont).Width;
                                float Width = StrCpsWidth + StrAvgWidth;
                                float MaxWidth = Width;
                                if (TimeWidth > Width) { MaxWidth = TimeWidth; }
                                float TxtHeight0 = g.MeasureString(StrTime, DrawTimeFont).Height;
                                float TxtHeight = g.MeasureString(StrCps, DrawFont).Height;
                                double xpos = chart.ChartAreas[0].AxisX.ValueToPixelPosition(SelectionStart1);
                                double ypos = chart.ChartAreas[0].AxisY.ValueToPixelPosition(0);
                                int x0 = (int)(xpos - TimeWidth / 2.0);
                                int y0 = (int)(ypos - TxtHeight - 15);
                                int x1 = (int)(xpos - Width / 2.0);
                                int y1 = (int)(ypos - TxtHeight);
                                int x = (int)(xpos - MaxWidth / 2.0);
                                int y = (int)(ypos - TxtHeight - 15);

                                Rectangle rect = new(x - 1, y - 1, (int)MaxWidth + 1, (int)TxtHeight + 2 + 15);
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                g.DrawString(StrTime, DrawTimeFont, DrawBrush, x0, y0);
                                g.DrawString(StrCps, DrawFont, BrushCps, x1, y1);
                                g.DrawString(StrAvg, DrawFont, BrushAvg, x1 + (int)StrCpsWidth, y1);
                            }
                        }
                    }
                }
            }
        }

        public static double AxisAutoScale(double Xmin, double Xmax, double MaximumCount)
        {
            double[] StepVector = [0, 0, 0, 0];
            int[] StepCount = [0, 0, 0, 0];
            double Delta = (Xmax - Xmin) / 2;
            double Middle = (Xmax + Xmin) / 2;
            Xmax = Middle + 1.01f * Delta;
            Xmin = Middle - 1.01f * Delta;

            double Pwr = Math.Log(Xmax - Xmin) / Math.Log(10);
            double Scl = Math.Pow(10, Pwr - Math.Floor(Pwr));
            if (Scl > 0 && Scl <= 1.25)
            {
                StepVector = [0.02d, 0.05d, 0.1d, 0.2d];
            }
            else if (Scl > 1.25 && Scl <= 2.5)
            {
                StepVector = [0.05d, 0.1d, 0.2d, 0.5d];
            }
            else if (Scl > 2.5 && Scl <= 5.0)
            {
                StepVector = [0.1d, 0.2d, 0.5d, 1.0d];
            }
            else
            {
                StepVector = [0.2d, 0.5d, 1.0d, 2.0d];
            }
            for (int i = 0; i < StepVector.Length; i++)
            {
                StepVector[i] = Math.Pow(10, Math.Floor(Pwr)) * StepVector[i];
                StepCount[i] = (int)Math.Ceiling((Xmax - Xmin) / StepVector[i]);
            }
            double Step = StepVector[3];
            for (int i = StepVector.Length - 2; i > 0; i--)
            {
                if (StepCount[i] <= MaximumCount)
                {
                    Step = StepVector[i];
                }
            }
            return Step;
        }
    }
}
