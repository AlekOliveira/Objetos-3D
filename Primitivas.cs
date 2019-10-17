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
        //public static void Bresenhan(Vertice p1, Vertice p2, Bitmap b)
        public static void Bresenhan(Vertice p1, Vertice p2, DirectBitmap b)
        {
            //Bitmap b = new Bitmap(pbx.Image);
            int declive = 1;
            int dx, dy, incNE, incE, d, x, y;
            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (p1.X > p2.X)
                {
                    Bresenhan(p2, p1, b);
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
                y = p1.Y;
                for (x = p1.X; x <= p2.X; ++x)
                {
                    b.SetPixel(x, y, Color.Purple);
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
                    Bresenhan(p2, p1, b);
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
                x = p1.X;
                for (y = p1.Y; y <= p2.Y; ++y)
                {
                    b.SetPixel(x, y, Color.Purple);
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


        /*public static void Bresenhan(Point p1, Point p2, PictureBox pbx)
        {
            Bitmap b = new Bitmap(pbx.Image);
            int declive = 1;
            int dx, dy, incNE, incE, d, x, y;
            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (p1.X > p2.X)
                {
                    Bresenhan(p2, p1, pbx);
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
                y = p1.Y;
                for (x = p1.X; x <= p2.X; ++x)
                {
                    b.SetPixel(x, y, Color.Purple);
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
                    Bresenhan(p2, p1, pbx);
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
                x = p1.X;
                for (y = p1.Y; y <= p2.Y; ++y)
                {
                    b.SetPixel(x, y, Color.Purple);
                    if (d < 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
            pbx.Image = b;
        }
         
             */

        public static void EQgeral(Point p1, Point p2, PictureBox pbx)
        {
            Bitmap b = new Bitmap(pbx.Image);

            double dy = p2.Y - p1.Y;
            double dx = p2.X - p1.X;
            dy = Math.Abs(dy); //Valor modular
            dx = Math.Abs(dx); //Valor modular
            double m = dy / dx;


            if (p2.X > p1.X && p2.Y > p1.Y) //1º Quadrante
            {
                if (dx > dy) //1º Octante
                {
                    double y;
                    for (int x = p1.X; x <= p2.X; x++)
                    {
                        y = (double)(p1.Y + m * (x - p1.X));
                        y = Math.Round(y);
                        b.SetPixel(x, (int)y, Color.CadetBlue);
                    }
                }
                else //2º Octante
                {
                    double x;
                    for (int y = p1.Y; y <= p2.Y; y++)
                    {
                        x = p1.X + (y - p1.Y) / m;
                        x = Math.Round(x);
                        b.SetPixel((int)x, y, Color.CadetBlue);
                    }
                }
            }
            else if (p1.X > p2.X && p2.Y > p1.Y) //2º Quadrante
            {
                if (dx > dy) //4º Octante
                {
                    double y;
                    for (int x = p1.X; x >= p2.X; x--)
                    {
                        y = (double)(p1.Y - m * (x - p1.X));
                        y = Math.Round(y);
                        b.SetPixel(x, (int)y, Color.CadetBlue);
                    }

                }
                else //3º Octante
                {
                    double x;
                    for (int y = p1.Y; y <= p2.Y; y++)
                    {
                        x = p1.X - (y - p1.Y) / m;
                        x = Math.Round(x);
                        b.SetPixel((int)x, y, Color.CadetBlue);
                    }
                }
            }
            else if (p1.X > p2.X && p1.Y > p2.Y) //3º Quadrante
            {
                if (dx > dy) //5º Octante
                {
                    double y;
                    for (int x = p1.X; x >= p2.X; x--)
                    {
                        y = (double)(p1.Y + m * (x - p1.X));
                        y = Math.Round(y);
                        b.SetPixel(x, (int)y, Color.CadetBlue);
                    }
                }
                else //6º Octante
                {
                    double x;
                    for (int y = p1.Y; y >= p2.Y; y--)
                    {
                        x = p1.X + (y - p1.Y) / m;
                        x = Math.Round(x);
                        b.SetPixel((int)x, y, Color.CadetBlue);
                    }
                }
            }
            else if (p2.X > p1.X && p1.Y > p2.Y)
            {
                if (dx > dy) //8º Octante
                {
                    double y;
                    for (int x = p1.X; x <= p2.X; x++)
                    {
                        y = (double)(p1.Y - m * (x - p1.X));
                        y = Math.Round(y);
                        b.SetPixel(x, (int)y, Color.CadetBlue);
                    }
                }
                else //7º Octante
                {
                    double x;
                    for (int y = p1.Y; y >= p2.Y; y--)
                    {
                        x = p1.X - (y - p1.Y) / m;
                        x = Math.Round(x);
                        b.SetPixel((int)x, y, Color.CadetBlue);
                    }
                }
            }
            else
            {
                if (p1.X == p2.X) // corre X
                {
                    for (int Y = p1.Y; Y <= p2.Y; Y++)
                        b.SetPixel((int)p1.X, (int)Y, Color.CadetBlue);
                    for (int Y = p1.Y; Y >= p2.Y; Y--)
                        b.SetPixel((int)p1.X, (int)Y, Color.CadetBlue);
                }
                else
                {
                    if (p1.Y == p2.Y) // Corre Y
                    {
                        for (int Y = p1.Y; Y <= p2.Y; Y++)
                            b.SetPixel((int)p1.X, (int)Y, Color.CadetBlue);
                        for (int Y = p1.Y; Y >= p2.Y; Y--)
                            b.SetPixel((int)p1.X, (int)Y, Color.CadetBlue);
                    }
                }

            }
            pbx.Image = b;
        }

        public static void DecliveDDA(Point p1, Point p2, PictureBox pbx)
        {
            Bitmap b = new Bitmap(pbx.Image);
            if (p1.X > p2.X)
            {
                Point aux = p1;
                p1 = p2;
                p2 = aux;
            }
            int Length; 
            double X, Y, Xinc, Yinc;

            //Guardando a maior largura
            Length = Math.Max((Math.Abs(p2.X - p1.X)), (Math.Abs(p2.Y - p1.Y)));

            if (p1.X == p2.X)
            {
                for (Y = p1.Y; Y <= p2.Y; Y++)
                {
                    if ((int)p1.X >= 0 && (int)p1.X < pbx.Width && (int)Y >= 0 && (int)Y < pbx.Height)
                        b.SetPixel((int)p1.X, (int)Y, Color.Black);
                }

                for (Y = p1.Y; Y >= p2.Y; Y--)
                {
                    if ((int)p1.X >= 0 && (int)p1.X < pbx.Width && (int)Y >= 0 && (int)Y < pbx.Height)
                        b.SetPixel((int)p1.X, (int)Y, Color.Black);
                }

            }
            else
            {
                Xinc = (double)(p2.X - p1.X) / Length;
                Yinc = (double)(p2.Y - p1.Y) / Length;
                X = p1.X; Y = p1.Y;
                while (X < p2.X)
                {
                    if (Math.Round(X) >= 0 && Math.Round(X) < pbx.Width && Math.Round(Y) >= 0 && Math.Round(Y) < pbx.Height)
                        b.SetPixel((int)Math.Round(X), (int)Math.Round(Y), Color.Black);
                    X = X + Xinc;
                    Y = Y + Yinc;
                }
            }
            pbx.Image = b;
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
