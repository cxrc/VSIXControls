using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace VSIXControls
{

    [ProvideToolboxControl("VSIXControls", false)]
    public partial class Switch : UserControl
    {
        private bool coloreado;
        private bool showLabels = false;
        private Color fondoOn = Color.Lime;
        private Color fondoOff = Color.Red;
        private Color labelColor = Color.Black;
        private Color fondoChekedActual;
        private Color fondoUncheckedActual;
        public enum Estados { OFF, ON }
        private Estados estado;

        public Switch()
        {
            InitializeComponent();
            Coloreado = true;
        }

        [Category("Apariencia"), Description("Color del fondo cuando el estado es 'ON' y la propiedad Coloreado es 'true'")]
        public Color FondoOn { get => fondoOn; set { fondoOn = value; Invalidate(); } }
        [Category("Apariencia"), Description("Color del fondo cuando el estado es 'OFF' y la propiedad Coloreado es 'true'")]
        public Color FondoOff { get => fondoOff; set { fondoOff = value; Invalidate(); } }
        [Category("Comportamiento"), Description("Estado del interruptor ON u OFF")]
        public Estados Estado { get => estado; set { estado = value; Invalidate(); } }
        [Category("Apariencia"), Description("Determina si el control muestra los colores 'FondoOn' y 'FondoOff' o siempre un fondo gris")]
        public bool Coloreado { get => coloreado; set { coloreado = value; OnChangeColoredProperty(); } }
        [Category("Apariencia"), Description("Determina si el control muestra los caracteres '1' y 'o' indicando el estado del control.")]
        public bool ShowLabels { get => showLabels; set { showLabels = value; Invalidate(); } }
        [Category("Apariencia"), Description("Determina el color de las etiqueta '1' y 'o' visibles si ShowLabels es 'True'.")]
        public Color LabelColor { get => labelColor; set { labelColor = value; Invalidate(); } }

        private void OnChangeColoredProperty()
        {
            if (coloreado)
            {
                fondoChekedActual = FondoOn;
                fondoUncheckedActual = FondoOff;
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
            gr.DrawLine(lapizNegro, 1, Height - 2, 1, 1);
            gr.DrawLine(lapizNegro, 1, 1, Width - 2, 1);
            gr.DrawLine(lapizBlanco, 2, Height - 2, Width - 2, Height - 2);
            gr.DrawLine(lapizBlanco, Width - 2, Height - 2, Width - 2, 2);

            // Dibuja el fondo

            if (Estado == Estados.ON)
            {
                fondo = new SolidBrush(fondoChekedActual);
                mandoX = Width / 2;
            }
            else
            {
                fondo = new SolidBrush(fondoUncheckedActual);
                mandoX = 1;
            }
            Rectangle rectanguloInterior = new Rectangle(2, 2, Width - 4, Height - 4);
            gr.FillRectangle(fondo, rectanguloInterior);

            // Dibuja el Mando

            int x = mandoX;
            int y0 = 1;
            int y1 = Height - 2;
            Pen lapizGris = new Pen(Color.Gray);

            while (x <= mandoX + Width / 2 - 1)
            {
                if (x <= mandoX + Width / 2 - 1) gr.DrawLine(lapizGris, x, y0, x++, y1);
                if (x <= mandoX + Width / 2 - 1) gr.DrawLine(lapizGris, x, y0, x++, y1);
                if (x <= mandoX + Width / 2 - 1) gr.DrawLine(lapizNegro, x, y0, x++, y1);
                if (x <= mandoX + Width / 2 - 1) gr.DrawLine(lapizNegro, x, y0, x++, y1);
            }

            // |/O

            if (showLabels)
            {
                Pen lapiz10 = new Pen(labelColor);
                int margen = Height / 3;
                if (estado == Estados.ON)
                {
                    gr.DrawLine(lapiz10, 1 + Width / 4, margen + 1, 1 + Width / 4, Height - 1 - margen);
                }
                else
                {
                    gr.DrawEllipse(lapiz10, Width - 1 - Width / 4 - (Height / 3) / 2, margen - 1, Height / 3, Height / 3);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (estado == Estados.ON) estado = Estados.OFF;
            else estado = Estados.ON;
            this.Invalidate();
        }
    }
}
