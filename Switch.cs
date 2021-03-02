using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace VSIXControls
{
    [ToolboxBitmap(@"..\..\Switch16x16.bmp")]
    [ProvideToolboxControl("VSIXControls", false)]
    public partial class Switch : UserControl
    {
        private bool colored;
        private bool showLabels = false;
        private Color backgroundOn = Color.Lime;
        private Color backgroundOff = Color.Red;
        private Color labelColor = Color.Black;
        private Color BackgroundON_Actual;
        private Color BackgroundOFF_Actual;
        private bool isON;

        public Switch()
        {
            InitializeComponent();
            Colored = true;
        }
        public EventHandler onIsOnChanged;
        [Description("Se produce cuando el Switch cambia de estado ON/OFF")]
        public event EventHandler IsONChanged
        {
            add
            {
                onIsOnChanged += value;
            }
            remove
            {
                onIsOnChanged -= value;
            }
        }

        [Category("Apariencia"), Description("Color del fondo cuando el estado es 'ON' (IsON = true) y la propiedad Colored es 'true'.")]
        public Color BackgroundON { get => backgroundOn; set { backgroundOn = value; Invalidate(); OnChangeColoredProperty(); } }
        [Category("Apariencia"), Description("Color del fondo cuando el estado es 'OFF' (IsON = false) y la propiedad Colored es 'true'.")]
        public Color BackgroundOFF { get => backgroundOff; set { backgroundOff = value; Invalidate(); OnChangeColoredProperty(); } }
        [Category("Comportamiento"), Description("Estado del interruptor ON (IsON = true) u OFF (IsON = False).")]
        public bool IsON 
        { 
            get => isON; 
            set 
            {
                isON = value;
                Invalidate();
                EventArgs e = new EventArgs();
                OnIsOnChanged(this,e);
            }
        }
        [Category("Apariencia"), Description("Determina si el control muestra los colores 'BackgroundON' y 'BackgroundOFF' o solamente un fondo gris")]
        public bool Colored { get => colored; set { colored = value; OnChangeColoredProperty(); } }
        [Category("Apariencia"), Description("Determina si el control muestra los caracteres '1' y 'o' indicando el estado del control.")]
        public bool ShowLabels { get => showLabels; set { showLabels = value; Invalidate(); } }
        [Category("Apariencia"), Description("Determina el color de las etiqueta '1' y 'o' visibles si ShowLabels es 'True'.")]
        public Color LabelColor { get => labelColor; set { labelColor = value; Invalidate(); } }

        private void OnChangeColoredProperty()
        {
            if (colored)
            {
                BackgroundON_Actual = BackgroundON;
                BackgroundOFF_Actual = BackgroundOFF;
            }
            else
            {
                BackgroundON_Actual = Color.DarkGray;
                BackgroundOFF_Actual = Color.DarkGray;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            Brush Background;
            int xMando;

            // Lápices

            Pen blackPen = new Pen(Color.Black);
            Pen whitePen = new Pen(Color.White);
            Pen grayPen = new Pen(Color.Gray);
            Pen labelPen = new Pen(labelColor);
            if (!Enabled)
            {
                Pen LightGrayPen = new Pen(Color.LightGray);
                blackPen = grayPen;
                whitePen = LightGrayPen;
                grayPen = LightGrayPen;
                labelPen = LightGrayPen;
            }

            // Borde


            Rectangle rectanguloBorde = new Rectangle(0, 0, Width - 1, Height - 1);

            gr.DrawRectangle(blackPen, rectanguloBorde);
            gr.DrawLine(blackPen, 1, Height - 2, 1, 1);
            gr.DrawLine(blackPen, 1, 1, Width - 2, 1);
            gr.DrawLine(whitePen, 2, Height - 2, Width - 2, Height - 2);
            gr.DrawLine(whitePen, Width - 2, Height - 2, Width - 2, 2);

            // Dibuja el fondo

            if (isON)
            {
                Background = new SolidBrush(BackgroundON_Actual);
                xMando = Width / 2;
            }
            else
            {
                Background = new SolidBrush(BackgroundOFF_Actual);
                xMando = 1;
            }
            if (!Enabled)
            {
                Background = new SolidBrush(Color.LightGray);
            }
            Rectangle rectanguloInterior = new Rectangle(2, 2, Width - 4, Height - 4);
            gr.FillRectangle(Background, rectanguloInterior);

            // Dibuja el Mando

            int x = xMando;
            int y0 = 1;
            int y1 = Height - 2;


            while (x <= xMando + Width / 2 - 1)
            {
                if (x <= xMando + Width / 2 - 1) gr.DrawLine(grayPen, x, y0, x++, y1);
                if (x <= xMando + Width / 2 - 1) gr.DrawLine(grayPen, x, y0, x++, y1);
                if (x <= xMando + Width / 2 - 1) gr.DrawLine(blackPen, x, y0, x++, y1);
                if (x <= xMando + Width / 2 - 1) gr.DrawLine(blackPen, x, y0, x++, y1);
            }

            // |/O

            if (showLabels)
            {
                int margen = Height / 3;
                if (isON)
                {
                    gr.DrawLine(labelPen, 1 + Width / 4, margen + 1, 1 + Width / 4, Height - 1 - margen);
                }
                else
                {
                    gr.DrawEllipse(labelPen, Width - 1 - Width / 4 - (Height / 3) / 2, margen - 1, Height / 3, Height / 3);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Enabled)
            {
                IsON = !IsON;
                this.Invalidate();
            }
        }

        private void Switch_EnabledChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected virtual void OnIsOnChanged(object sender, EventArgs e)
        {
            onIsOnChanged?.Invoke(sender, e);
        }
    }
}
