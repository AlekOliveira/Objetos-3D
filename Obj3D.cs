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
        public List<Point> VerticesAtuais = new List<Point>();
        public List<Face> Faces = new List<Face>();
        private double[,] MA = new double[3,3];

        

        public Obj3D(List<Vertice> vertices, List<Face> faces)
        {
            this.Faces = faces;
            this.Vertices = vertices;
            this.MA = NovaMatriz();
            AtualizaVertices();
        }

        //METODOS PUBLICOS
        public void DesenhaFaces(PictureBox pbx)
        {
            Point p1, p2;
            int dx = pbx.Width/2;
            int dy = pbx.Height/2;
            Bitmap bmp = new Bitmap(pbx.Image);

            foreach (Face f in this.Faces)
            {
                p1 = new Point(VerticesAtuais[f.Idx0].X + dx, VerticesAtuais[f.Idx0].Y + dy);
                p2 = new Point(VerticesAtuais[f.Idx1].X + dx, VerticesAtuais[f.Idx1].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                    
                    Primitivas.Bresenhan(p1, p2, bmp);
                }    

                p1 = new Point(VerticesAtuais[f.Idx1].X + dx, VerticesAtuais[f.Idx1].Y + dy);
                p2 = new Point(VerticesAtuais[f.Idx2].X + dx, VerticesAtuais[f.Idx2].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                    
                    Primitivas.Bresenhan(p1, p2, bmp);
                }

                p1 = new Point(VerticesAtuais[f.Idx2].X + dx, VerticesAtuais[f.Idx2].Y + dy);
                p2 = new Point(VerticesAtuais[f.Idx0].X + dx, VerticesAtuais[f.Idx0].Y + dy);
                if (Primitivas.TamanhoPbx(pbx, p1) && Primitivas.TamanhoPbx(pbx, p2))
                {
                   
                    Primitivas.Bresenhan(p1, p2, bmp);
                }

                pbx.Image = bmp;
            }            
        }
        public void Translada(double Tx, double Ty)
        {
            double[,] M = NovaMatriz(); M[0, 2] = Tx; M[1, 2] = Ty;

            MultMat(M);
            AtualizaVertices();
        }
        public void Escala(double Sx, double Sy)
        {
            double[,] M = NovaMatriz(); M[0, 0] = Sx; M[1, 1] = Sy;

            //X e Y médio
            double Mx = 0, My = 0;
            for (int i = 0; i < Vertices.Count; i++)
            {
                Mx += Vertices[i].X;
                My += Vertices[i].Y;
            }
            Mx = Mx / Vertices.Count;
            My = My / Vertices.Count;

            Translada(Mx, My);
            MultMat(M);
            Translada(-Mx, -My);
            AtualizaVertices();
        }



        //METODOS PRIVADOS
        private double[,] NovaMatriz()
        {
            double[,] M = new double[3, 3];
            M[0, 0] = M[1, 1] = M[2, 2] = 1;
            return M;
        }
        private void MultMat(double[,] M)
        {
            double soma = 0;
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    soma = 0;
                    for (int k = 0; k < 3; k++)
                        soma += MA[l, k] * M[k, c];
                    this.MA[l, c] = soma;
                }
            }
        }        
        private void AtualizaVertices()
        {
            Vertice V;
            Point newV = new Point();
            VerticesAtuais.Clear();

            for (int i = 0; i < Vertices.Count; i++)
            {
                V = Vertices[i];
                newV.X = (int)((V.X * MA[0, 0]) + (V.Y * MA[0, 1]) + MA[0, 2]);
                newV.Y = (int)((V.X * MA[1, 0]) + (V.Y * MA[1, 1]) + MA[1, 2]);
                this.VerticesAtuais.Add(newV);
            }
        }

    }
}
