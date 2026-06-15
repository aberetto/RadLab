using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadLab.Controls
{
    public class RLabel : Label
    {
        #region -- Свойства --

        [Description("Цвет обводки (границы)")]
        public Color BorderColor { get; set; } = Color.Tomato;

        [Description("Указывает, включено ли использование отдельного цвета обводки (границы) кнопки")]
        public bool BorderColorEnabled { get; set; } = false;

        [Description("Цвет обводки (границы) кнопки при наведении курсора")]
        public Color BorderColorOnHover { get; set; } = Color.Tomato;

        [Description("Указывает, включено ли использование отдельного цвета обводки (границы) кнопки при наведении курсора")]
        public bool BorderColorOnHoverEnabled { get; set; } = false;

        private bool roundingEnable = false;
        [Description("Вкл/Выкл закругление объекта")]
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }

        private int roundingPercent = 100;
        [DisplayName("Rounding [%]")]
        [DefaultValue(100)]
        [Description("Указывает радиус закругления объекта в процентном соотношении")]
        public int Rounding
        {
            get => roundingPercent;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    roundingPercent = value;

                    Refresh();
                }
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        #endregion

        #region -- Переменные --

        private readonly StringFormat SF = new();
        private bool MouseEntered = false;
        private bool MousePressed = false;

        #endregion

        public RLabel()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint |
                ControlStyles.Opaque |
                ControlStyles.Selectable |
                ControlStyles.UserMouse |
                ControlStyles.EnableNotifyMessage,
                true);
            DoubleBuffered = true;

            Size = new Size(100, 30);

            //Cursor = Cursors.IBeam;

            BackColor = Color.Tomato;
            BorderColor = BackColor;
            ForeColor = Color.White;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }

        float mRatio = 1.0F;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            if (Parent != null) graph.Clear(Parent.BackColor);

            Rectangle rect = new(0, 0, Width - 1, Height - 1);
            Rectangle rectBorder = new(2, 2, Width - 4, Height - 4);
            Rectangle rectText = new(0, 2, rect.Width, rect.Height - 1);

            // Закругление
            float roundingValue = 0.1F;
            if (RoundingEnable && roundingPercent > 0)
            {
                roundingValue = Height / 100F * roundingPercent;
            }
            GraphicsPath rectPath = Drawer.RoundedRectangle(rect, roundingValue);
            GraphicsPath rectBorderPath = Drawer.RoundedRectangle(rectBorder, roundingValue);
            Region = new Region(rectPath);
            if (Parent != null) graph.Clear(Parent.BackColor);


            Brush headerBrush = new SolidBrush(BackColor);
            Brush borderBrush = headerBrush;
            if (BorderColorEnabled)
            {
                borderBrush = new SolidBrush(BorderColor);

                if (MouseEntered && BorderColorOnHoverEnabled)
                    borderBrush = new SolidBrush(BorderColorOnHover);
            }

            // Основной прямоугольник (Фон)
            graph.FillPath(headerBrush, rectBorderPath);
            graph.DrawPath(new Pen(borderBrush, 2.0f), rectBorderPath);
            graph.SetClip(rectPath);

            if (MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }

            if (MousePressed)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(30, Color.Black)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
            }

            // масштабирование шрифта
            float ratio = e.ClipRectangle.Height / 100.0F;
            if (ratio < 0.1) ratio = 0.1F;
            if (ratio != mRatio)
            {
                mRatio = ratio;
                base.Font = new Font(Font.FontFamily, 48.0F * ratio, Font.Style);
            }            

            // Рисуем текст
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rectText, SF);

        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            Focus();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnParentBackColorChanged(e);
        }

    }


}
