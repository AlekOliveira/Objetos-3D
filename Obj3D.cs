using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objetos_3D
{
    class Obj3D
    {
        public List<Vertice> Vertices = new List<Vertice>();
        public List<Face> Faces = new List<Face>();
        private int MA = new int[];


        public Obj3D(List<Vertice> vertices, List<Face> faces)
        {
            Vertices = vertices;
            Faces = faces;
        }

        public void DesenhaFaces(PictureBox pbx)
        {
            Point p1, p2;
            int dx = pbx.Width/2;
            int dy = pbx.Height/2;
            Bitmap bmp = new Bitmap(pbx.Image);

            foreach (Face f in this.Faces)
            {
                p1 = new Point(Vertices[f.Idx0].X + dx, Vertices[f.Idx0].Y + dy);
                p2 = new Point(Vertices[f.Idx1].X + dx, Vertices[f.Idx1].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                    
                    Primitivas.Bresenhan(p1, p2, bmp);
                }    

                p1 = new Point(Vertices[f.Idx1].X + dx, Vertices[f.Idx1].Y + dy);
                p2 = new Point(Vertices[f.Idx2].X + dx, Vertices[f.Idx2].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                    
                    Primitivas.Bresenhan(p1, p2, bmp);
                }

                p1 = new Point(Vertices[f.Idx2].X + dx, Vertices[f.Idx2].Y + dy);
                p2 = new Point(Vertices[f.Idx0].X + dx, Vertices[f.Idx0].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                   
                    Primitivas.Bresenhan(p1, p2, bmp);
                }

                pbx.Image = bmp;
            }            
        }

        public void Escala()
        {
            
        }
    }
}
