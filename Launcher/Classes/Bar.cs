using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DPRENALauncher.Classes
{
    public partial class Bar : Control
    {
        int _value = 0;
        int _max = 100;
        public Bar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public int Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
                Invalidate();
            }
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = (value < _max) ? value : _max;
                Invalidate();
            }
        }
        public float Percent
        {
            get
            {
                return (float)(((float)Value / (float)Max));
            }
        }
        protected override void Dispose(bool disposing)
        {
            Barr.Dispose();
            BarBG.Dispose();
            base.Dispose(disposing);
        }
        Bitmap Barr;
        Bitmap BarBG;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            try
            {
                DoDraw(G);
            }
            catch(Exception E)
            {
                G.DrawImage(Buffer, new Point(0, 0));
                string s = E.Message;
            }


        }
        Bitmap Buffer;
        void DoDraw(Graphics G)
        {

            Rectangle Src = new Rectangle();
            Rectangle Dst = new Rectangle();

            int wid = (int)((Width) * Percent);
            Src.X = 0;
            Src.Y = 0;


            Src.Height = Height - 2;
            Src.Width = wid;//(wid - 2 <= 0) ? wid : wid-2 ;

            Dst.X = 4;
            Dst.Y = 2;

            Dst.Width = Src.Width;// (Src.Width-4 > 0) ? Src.Width-4:Src.Width; //(Src.Width+4 < Width) ? Src.Width+4 : Src.Width;
            Dst.Height = Src.Height;



            if (Barr == null || BarBG == null)
            {
                Barr = Properties.Resources.Bar;
                BarBG = Properties.Resources.barbg;
                if (Barr == null || BarBG == null)
                {
                    throw new Exception("Resource not loaded error");
                }
            }
            //Dst = Src;


            using (Bitmap BMP = new Bitmap(Width, Height))
            {
                using (Graphics G2 = Graphics.FromImage(BMP))
                {
                    //Draw background
                    G2.DrawImage(BarBG, 0, 0, Width, Height);


                    //Draw bar
                    G2.DrawImage(Barr, Dst, Src, GraphicsUnit.Pixel);
                    Buffer = (Bitmap)BMP.Clone();
                }
                G.DrawImage(BMP, new Point(0, 0));
            }

        }
        

    }
}
