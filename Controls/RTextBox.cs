using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;

namespace RadLab.Controls
{
    [Designer(typeof(ControlDesignerEx))] // ControlDesignerEx Добавляем для ограничения изменения размеров    
    public class RTextBox : Control
    {
        #region -- Свойства --

        [Description("Цвет обводки (границы)")]
        public Color BorderColor { get; set; } = Color.Tomato;

        [Description("Указывает, включено ли использование отдельного цвета обводки (границы) кнопки")]
        public bool BorderColorEnabled { get; set; } = false;

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

        public HorizontalAlignment TextAlign
        {
            get => tbInput.TextAlign;
            set => tbInput.TextAlign = value;
        }

        public string TextInput
        {
            get => tbInput.Text;
            set
            {
                tbInput.Text = value;
            }
        }

        public bool UseSystemPasswordChar
        {
            get => tbInput.UseSystemPasswordChar;
            set => tbInput.UseSystemPasswordChar = value;
        }

        public new string Text
        {
            get => tbInput.Text;
            set
            {
                tbInput.Text = value;
            }
        }

        public int SelectionStart
        {
            get => tbInput.SelectionStart;
            set => tbInput.SelectionStart = value;
        }

        public int TextLength
        {
            get => tbInput.TextLength;
        }

        #endregion

        #region -- События / Events --

        [Browsable(true)]
        public new event EventHandler TextChanged
        {
            add { tbInput.TextChanged += value; }
            remove { tbInput.TextChanged -= value; }
        }

        [Browsable(true)]
        public new event KeyEventHandler KeyDown
        {
            add { tbInput.KeyDown += value; }
            remove { tbInput.KeyDown -= value; }
        }

        [Browsable(true)]
        public new event KeyPressEventHandler KeyPress
        {
            add { tbInput.KeyPress += value; }
            remove { tbInput.KeyPress -= value; }
        }

        #endregion

        #region -- Переменные --

        readonly StringFormat SF = new();
        TextBox tbInput = new();

        #endregion

        public RTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(150, 40);
            Font = new Font("Arial", 11.25F, FontStyle.Regular);
            ForeColor = Color.Black;
            BackColor = Color.White;

            Cursor = Cursors.IBeam;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            AdjustTextBoxInput();
            Controls.Add(tbInput);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void AdjustTextBoxInput()
        {
            tbInput = new TextBox
            {
                Name = "InputBox",
                BorderStyle = BorderStyle.None,
                BackColor = BackColor,
                ForeColor = ForeColor,
                Font = Font,
                TextAlign = TextAlign,
                Location = new Point(10, 3),
                Size = new Size(Width - 20, tbInput.Height)
            };
        }

        #region -- Обновление свойств tbInput --
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            tbInput.BackColor = BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            tbInput.ForeColor = ForeColor;

        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            tbInput.Font = Font;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            tbInput.Size = new Size(Width - 20, tbInput.Height);
        }
        #endregion

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
            Rectangle rectBase = new(1, 1, Width - 2, Height - 2);
            Rectangle rectBorder = new(2, 2, Width - 4, Height - 4);

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
            }

            // Основной прямоугольник (Фон)
            graph.FillPath(headerBrush, rectBorderPath);
            graph.DrawPath(new Pen(borderBrush, 2.0f), rectBorderPath);
            graph.SetClip(rectBase);

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }


        /// <summary>
        /// В этом классе переопределяем SelectionRules, и даем возможность только изменять ширину и перемещать объект
        /// </summary>
        class ControlDesignerEx : ControlDesigner
        {
            public override SelectionRules SelectionRules
            {
                get
                {
                    SelectionRules sr = SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable | SelectionRules.Visible;
                    return sr;
                }
            }
        }
    }
}
