using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace VSIXControls
{
    [ToolboxBitmap(@"..\..\Led16x16.bmp")]
    [ProvideToolboxControl("VSIXControls", false)]
    public partial class Led : UserControl
    {
        public Led()
        {
            InitializeComponent();
        }

        private bool isON = false;
        public enum Appearances { Round, Square }
        private Appearances appearance = Appearances.Round;
        private Color ledColorON = Color.Lime;
        private Color ledColorOFF = Color.DarkGreen;

        [Category("Comportamiento"), Description("Estado del LED encendido (IsON = true) o apagado (IsON = False).")]
        public bool IsON { get => isON; set { isON = value; Invalidate(); } }
        [Category("Apariencia"), Description("Color del diodo led encendido.")]
        public Appearances Appearance { get => appearance; set { appearance = value; Invalidate(); } }
        [Category("Apariencia"), Description("Forma del diodo led.")]
        public Color LedColorON { get => ledColorON; set { ledColorON = value; Invalidate(); } }
        [Category("Apariencia"), Description("Color del diodo led apagado (IsON = false).")]
        public Color LedColorOFF { get => ledColorOFF; set { ledColorOFF = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            Pen blackPen = new Pen(Color.Black);
            SolidBrush brush;
            if (isON)
            {
                brush = new SolidBrush(ledColorON);
            }
            else
            {
                brush = new SolidBrush(ledColorOFF);
            }
            int w = this.Width - 2;
            int h = this.Height - 2;
            if (appearance == Appearances.Round)
            {
                w -= 1;
                h -= 1;
            }
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectInt = new Rectangle(1, 1, w, h);
            if (appearance == Appearances.Round)
            {
                gr.DrawEllipse(blackPen, rect);
                gr.FillEllipse(brush, rectInt);
            }
            else
            {
                gr.DrawRectangle(blackPen, rect);
                gr.FillRectangle(brush, rectInt);
            }
        }
    }
}
