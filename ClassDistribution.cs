using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RadLab
{
    internal class ClassDistribution
    {
        public class ChartDistribution()
        {
            public Chart chart = new();

            public void Initialize()
            {
                chart.Series[0].ChartType = SeriesChartType.Column;
                chart.Series[1].BorderWidth = 2;
                chart.Series[1].Color = Color.Fuchsia;
                chart.ChartAreas[0].AxisX.IntervalOffset = 1;
                chart.ChartAreas[0].AxisX.Minimum = -1;
                chart.ChartAreas[0].AxisX.Maximum = 4095;
                chart.ChartAreas[0].AxisX.Interval = 500;

                chart.ChartAreas[0].CursorX.AutoScroll = false;
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart.ChartAreas[0].CursorX.Position = 0;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                //RefreshCursorPosition();

                chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisY.ScrollBar.Enabled = false;

                chart.MouseWheel += MouseWheel;
                chart.AxisViewChanged += AxisViewChanged;
                chart.SizeChanged += SizeChanged;
                chart.PreviewKeyDown += PreviewKeyDown;
                chart.Paint += PostPaint;
            }

            private void MouseWheel(object? sender, MouseEventArgs e)
            {
                if (sender != null)
                {
                    Chart chart = (Chart)sender;
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
                }
            }

            private void AxisViewChanged(object? sender, ViewEventArgs e)
            {
                SetXIntervalForCharts();
            }

            private void SizeChanged(object? sender, EventArgs e)
            {
                SetXIntervalForCharts();
            }

            private void PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (double.IsNaN(chart.ChartAreas[0].CursorX.Position))
                    {
                        chart.ChartAreas[0].CursorX.Position = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    }
                    else
                    {
                        if (chart.ChartAreas[0].CursorX.Position > chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum)
                        {
                            chart.ChartAreas[0].CursorX.Position -= 1;
                        }
                    }                    
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (double.IsNaN(chart.ChartAreas[0].CursorX.Position))
                    {
                        chart.ChartAreas[0].CursorX.Position = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    }
                    else
                    {
                        if (chart.ChartAreas[0].CursorX.Position < chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum)
                        {
                            chart.ChartAreas[0].CursorX.Position += 1;
                        }
                    }
                }
            }

            private void PostPaint(object? sender, PaintEventArgs e)
            {

                double SelectionStart1 = chart.ChartAreas[0].CursorX.Position;
                if (SelectionStart1 is not double.NaN)
                {
                    if (SelectionStart1 >= chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum && SelectionStart1 <= chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum)
                    {
                        DataPoint? t = chart.Series[0].Points.Where(point => point.XValue == SelectionStart1).FirstOrDefault();
                        if (t != null)
                        {
                            if ((int)t.YValues[0] > 0)
                            {
                                string StrCps = ((int)t.YValues[0]).ToString();

                                Graphics g = e.Graphics;
                                Font DrawFont = new("Arial", 11.25F, FontStyle.Bold); ;
                                Brush DrawBrush = Brushes.Black;

                                Brush BrushCps = new SolidBrush(Color.Black);
                                float StrCpsWidth = g.MeasureString(StrCps, DrawFont).Width;

                                float TxtHeight = g.MeasureString(StrCps, DrawFont).Height;
                                double xpos = chart.ChartAreas[0].AxisX.ValueToPixelPosition(SelectionStart1);
                                double ypos = chart.ChartAreas[0].AxisY.ValueToPixelPosition(0);
                                int x = (int)(xpos - StrCpsWidth / 2.0);
                                int y = (int)(ypos - TxtHeight);

                                Rectangle rect = new(x - 1, y - 1, (int)StrCpsWidth + 1, (int)TxtHeight + 2);
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                g.DrawString(StrCps, DrawFont, BrushCps, x, y);
                            }
                        }
                    }
                }
            }

            private void SetXIntervalForCharts()
            {
                int OptimalCountsOfInterval = (int)(chart.Width / 100);
                var XMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                var XMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double Interval = ClassMonitoring.AxisAutoScale(XMin, XMax, OptimalCountsOfInterval);
                if (Interval < 1) { Interval = 1; }
                //double IntervalOffset = (Interval * Math.Floor(XMin / Interval)) - XMin;
                chart.ChartAreas[0].AxisX.Interval = Interval;
                //chart.ChartAreas[0].AxisX.IntervalOffset = IntervalOffset;
                chart.ChartAreas[0].AxisX.IntervalOffset = 1;
            }
        }
    }
}
