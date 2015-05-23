using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardControl.Info
{
    class Lcd
    {
        public static readonly Lcd Instance = new Lcd();
        const int X_SIZE = 20;
        const int Y_SIZE = 3;
        const char INIT_CHAR = '_';
        Form Surface;

        char[][] LcdMatrix;

        private Lcd()
        {
            LcdMatrix = new char[Y_SIZE][];
            for (int i = 0; i < Y_SIZE ; i++)
            {
                LcdMatrix[i] = new char[X_SIZE];
                for (int j = 0; j < X_SIZE; j++)
                    LcdMatrix[i][j] = INIT_CHAR;
            }
        }

        public void SetSurface(Form p)
        {
            Surface = p;
        }

        public void Update()
        {
            string info = InfoController.Instance.GetInfo();
            for (int i = 0; i < Y_SIZE; i++)
                for (int j = 0; j < X_SIZE; j++)
                    LcdMatrix[i][j] = info[i * X_SIZE + j];
            Surface.Invalidate();
        }


        public void onPaint(Graphics g)
        {
            g.Clear(Color.Gold);
            var font = SystemFonts.CaptionFont;
            for (int i = 0; i < Y_SIZE; i++)
                for (int j = 0; j < X_SIZE; j++)
                    g.DrawString(LcdMatrix[i][j].ToString(), font, Brushes.Black, (float)(j * 10), (float)(i * 14),StringFormat.GenericDefault);
        }


        internal void Update(object sender, System.Timers.ElapsedEventArgs e)
        {
            Update();
        }
    }
}
