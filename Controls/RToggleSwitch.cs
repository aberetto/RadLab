using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace RadLab.Controls
{
    [Designer(typeof(ControlDesignerEx))] // ControlDesignerEx Добавляем для ограничения изменения размеров
    [DefaultEvent("CheckedChanged")]
    public class RToggleSwitch : Control
    {
        #region -- Свойства --

        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;

                SwitchToggle();

                UpdateSize();
                UpdateStructures();
            }
        }
        private bool _checked = false;

        public Color BackColorON { get; set; } = FlatColors.GreenDark;
        public Color BackColorOFF { get; set; } = FlatColors.Red;

        public override string Text
        {
            get => text;
            set
            {
                text = value;
                UpdateSize();
                UpdateStructures();
            }
        }
        private string text = string.Empty;

        public string TextOnChecked
        {
            get => _textOnChecked;
            set
            {
                _textOnChecked = value;
                UpdateSize();
                UpdateStructures();
            }
        }
        private string _textOnChecked = string.Empty;

        public int ToogleSwitchWidth
        {
            get => _toogleSwitchWidth;
            set
            {
                _toogleSwitchWidth = value;
                UpdateSize();
                UpdateStructures();
            }
        }
        private int _toogleSwitchWidth = 40;

        #endregion

        #region -- Переменные --

        private Rectangle rectToggleHolder;
        //private int ToogleSwitchWidth = 80;

        private Rectangle rectText;

        private int TogglePosX_ON;
        private int TogglePosX_OFF;

        private Animation ToggleAnim = new();

        private readonly StringFormat SF = new();

        #endregion

        #region -- События --

        [Description("Возникает при каждом изменении свойства Checked")]
        public event OnCheckedChangedHandler CheckedChanged;
        public delegate void OnCheckedChangedHandler(object sender);

        #endregion

        public RToggleSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;

            Font = new Font("Verdana", 9F, FontStyle.Regular);
            BackColor = Color.White;

            Cursor = Cursors.Hand;

            Size = new Size(ToogleSwitchWidth, 15);
            UpdateSize();
            UpdateStructures();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            UpdateStructures();

            ToggleAnim.Value = Checked == true ? TogglePosX_ON : TogglePosX_OFF;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            if (Parent != null) graph.Clear(Parent.BackColor);

            Pen penToggleHolder = new(FlatColors.GrayDark, 1.55f);
            Pen penToggle = new(FlatColors.GrayDark, 3);

            GraphicsPath gpathToggle = Drawer.RoundedRectangle(rectToggleHolder, rectToggleHolder.Height);
            Rectangle rectToggle = new((int)ToggleAnim.Value, rectToggleHolder.Y, rectToggleHolder.Height, rectToggleHolder.Height);

            graph.DrawPath(penToggleHolder, gpathToggle);

            if (Checked == true)
            {
                if (Animator.IsWork == false)
                    rectToggle.Location = new Point(TogglePosX_ON, rectToggleHolder.Y);

                graph.FillPath(new SolidBrush(BackColorON), gpathToggle);
            }
            else
            {
                if (Animator.IsWork == false)
                    rectToggle.Location = new Point(TogglePosX_OFF, rectToggleHolder.Y);

                graph.FillPath(new SolidBrush(BackColorOFF), gpathToggle);
            }

            graph.DrawEllipse(penToggle, rectToggle);
            graph.FillEllipse(new SolidBrush(BackColor), rectToggle);

            string drawText = Text;
            if (!string.IsNullOrEmpty(TextOnChecked) && Checked)
                drawText = TextOnChecked;

            graph.DrawString(drawText, Font, new SolidBrush(ForeColor), rectText, SF);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Checked = !Checked;
        }

        private void SwitchToggle()
        {
            if (Checked == true)
            {
                ToggleAnim = new Animation("Toggle_" + Handle, Invalidate, ToggleAnim.Value, TogglePosX_ON);
            }
            else
            {
                ToggleAnim = new Animation("Toggle_" + Handle, Invalidate, ToggleAnim.Value, TogglePosX_OFF);
            }

            ToggleAnim.StepDivider = 8;
            Animator.Request(ToggleAnim, true);

            CheckedChanged?.Invoke(this);
        }

        private void UpdateSize()
        {
            string drawText = Text;
            if (!string.IsNullOrEmpty(TextOnChecked) && Checked) drawText = TextOnChecked;

            Size size = TextRenderer.MeasureText(drawText, Font);
            Width = ToogleSwitchWidth + size.Width + 3;
        }

        private void UpdateStructures()
        {
            rectToggleHolder = new Rectangle(1, 1, ToogleSwitchWidth - 3, Height - 3);

            int rectTextWidth = Width - ToogleSwitchWidth - 3;
            int rectTextX = rectToggleHolder.Right + 6;
            rectText = new Rectangle(rectTextX, rectToggleHolder.Y, rectTextWidth, rectToggleHolder.Height);

            TogglePosX_OFF = rectToggleHolder.X;
            TogglePosX_ON = rectToggleHolder.Right - rectToggleHolder.Height;
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
                    SelectionRules sr = SelectionRules.Moveable | SelectionRules.Visible;
                    return sr;
                }
            }
        }
    }
}
