using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace VSIXControls
{

    [ProvideToolboxControl("VSIXControls", false)]
    public partial class Switch : UserControl
    {
        private bool state = false;
        private bool colored;
        private bool show10Characters = false;
        private Color fondoCheked = Color.Lime;
        private Color fondoUnchecked = Color.Red;
        private Color show10Color = Color.Gray;
        private Color fondoChekedActual;
        private Color fondoUncheckedActual;
        private int Angle = 0;

        public Switch()
        {
            InitializeComponent();
            Colored = true;
        }

        public Color FondoCheked { get => fondoCheked; set { fondoCheked = value; Invalidate(); } }
        public Color FondoUnchecked { get => fondoUnchecked; set { fondoUnchecked = value; Invalidate(); } }
        public bool State { get => state; set { state = value; Invalidate(); } }

        public bool Colored { get => colored; set { colored = value; OnChangeColoredProperty(); } }

        public bool Show10Characters { get => show10Characters; set { show10Characters = value; Invalidate(); } }

        public Color Show10Color { get => show10Color; set { show10Color = value; Invalidate(); } }

        private void OnChangeColoredProperty()
        {
            if (colored)
            {
                fondoChekedActual = FondoCheked;
                fondoUncheckedActual = FondoUnchecked;
            }
            else
            {
                fondoChekedActual = Color.DarkGray;
                fondoUncheckedActual = Color.DarkGray;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            Brush fondo;
            int mandoX;

            // Borde

            Pen lapizNegro = new Pen(Color.Black);
            Pen lapizBlanco = new Pen(Color.White);
            Rectangle rectanguloBorde = new Rectangle(0, 0, Width - 1, Height - 1);
            gr.DrawRectangle(lapizNegro, rectanguloBorde);
            gr.DrawLine(lapizBlanco, 1, Height - 2, Width - 2, Height - 2);
            gr.DrawLine(lapizBlanco, Width - 2, Height - 2, Width - 2, 1);
            gr.DrawLine(lapizNegro, 1, Height - 2, 1, 1);
            gr.DrawLine(lapizNegro, 1, 1, Width - 2, 1);

            // Dibuja el fondo

            if (this.state)
            {
                fondo = new SolidBrush(fondoChekedActual);
                mandoX = Width - Height;
            }
            else
            {
                fondo = new SolidBrush(fondoUncheckedActual);
                mandoX = 2;
            }
            Rectangle rectanguloInterior = new Rectangle(2, 2, Width - 4, Height - 4);
            gr.FillRectangle(fondo, rectanguloInterior);

            // Dibuja el Mando
            
            int x = mandoX;
            int y0 = 2;
            int y1 = Height - 3;
            Pen lapizGris = new Pen(Color.Gray);
            while (x <= mandoX + Height - 3)
            {
                if (x <= mandoX + Height - 3) gr.DrawLine(lapizGris, x, y0, x++, y1);
                if (x <= mandoX + Height - 3) gr.DrawLine(lapizGris, x, y0, x++, y1);
                if (x <= mandoX + Height - 3) gr.DrawLine(lapizNegro, x, y0, x++, y1);
                if (x <= mandoX + Height - 3) gr.DrawLine(lapizNegro, x, y0, x++, y1);
            }

            // 10
            if (show10Characters)
            {
                Pen lapiz10 = new Pen(show10Color, 2F);
                const int margen = 15;
                if (state)
                {
                    gr.DrawLine(lapiz10, Height / 2, margen, Height / 2, Height - margen);
                }
                else
                {
                    gr.DrawEllipse(lapiz10, Width - Height + margen, margen, Height - margen*2, Height - margen*2);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            state = !state;
            this.Invalidate();
        }
    }
}
