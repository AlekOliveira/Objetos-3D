using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objetos_3D
{
    class Primitivas
    {
        
        public static void Bresenhan(Vertice p1, Vertice p2, DirectBitmap b, Color c)
        {
            int declive = 1;
            int dx, dy, incNE, incE, d, x, y;
            dx = (int)(p2.X - p1.X);
            dy = (int)(p2.Y - p1.Y);
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (p1.X > p2.X)
                {
                    Bresenhan(p2, p1, b, c);
                    return;
                }
                if (p1.Y > p2.Y)
                {
                    declive = -1;
                    dy = -dy;
                }
                incE = 2 * dy;
                incNE = 2 * (dy - dx);
                d = incNE;
                y = (int)p1.Y;                
                for (x = (int)p1.X; x <= p2.X; ++x)
                {
                    if(x >= 0 && x < b.Width && y >= 0 && y < b.Height)
                        b.SetPixel(x, y, c);
                    if (d < 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        y += declive;
                    }
                }
            }
            else
            {
                if (p1.Y > p2.Y)
                {
                    Bresenhan(p2, p1, b, c);
                    return;
                }

                if (p1.X > p2.X)
                {
                    declive = -1;
                    dx = -dx;
                }

                incE = 2 * dx;
                incNE = 2 * (dx - dy);
                d = incNE;
                x = (int)p1.X;
                for (y = (int)p1.Y; y <= p2.Y; ++y)
                {
                    if (x >= 0 && x < b.Width && y >= 0 && y < b.Height)
                        b.SetPixel(x, y, c);
                    if (d < 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
        }






        public static bool TamanhoBmp(Bitmap bmp, Vertice v)
        {
            return v.X >= 0 && v.X < bmp.Width && v.Y >= 0 && v.Y < bmp.Height;
        }

        public static bool TamanhoPbx(PictureBox pbx, Vertice v)
        {
            return v.X >= 0 && v.X < pbx.Width && v.Y >= 0 && v.Y < pbx.Height;
        }

        public static bool TamanhoDirectBmp(DirectBitmap bmp, Vertice v)
        {
            return v.X >= 0 && v.X < bmp.Width && v.Y >= 0 && v.Y < bmp.Height;
        }

        
    }
}
