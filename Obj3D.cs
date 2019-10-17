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
        public List<Vertice> VerticesAtuais = new List<Vertice>();

        //public List<Point> VerticesAtuais = new List<Point>();
        public List<Face> Faces = new List<Face>();
        private double[,] MA = new double[4,4];

        

        public Obj3D(List<Vertice> vertices, List<Face> faces)
        {
            this.Faces = faces;
            this.Vertices = vertices;
            this.MA = NovaMatriz();
            AtualizaVertices();
        }

        //METODOS PUBLICOS
        public void DesenhaFaces(DirectBitmap bmp)
        {
            Vertice v1, v2, v3;
            int dx = bmp.Width/2;
            int dy = bmp.Height/2;
            foreach (Face f in this.Faces)
            {
                v1 = new Vertice(VerticesAtuais[f.Idx0].X + dx, VerticesAtuais[f.Idx0].Y + dy, VerticesAtuais[f.Idx0].Z);
                v2 = new Vertice(VerticesAtuais[f.Idx1].X + dx, VerticesAtuais[f.Idx1].Y + dy, VerticesAtuais[f.Idx1].Z);
                v3 = new Vertice(VerticesAtuais[f.Idx2].X + dx, VerticesAtuais[f.Idx2].Y + dy, VerticesAtuais[f.Idx2].Z);               
                Primitivas.Bresenhan(v1, v2, bmp);               
                Primitivas.Bresenhan(v2, v3, bmp);               
                Primitivas.Bresenhan(v3, v1, bmp);
            }

        }

        public void Translada(double Tx, double Ty, double Tz)
        {
            double[,] M = NovaMatriz(); M[0, 3] = Tx; M[1, 3] = Ty; M[2,3] = Tz;

            MultMat(M);
            AtualizaVertices();
        }
        public void Escala(double Sx, double Sy, double Sz)
        {
            double[,] M = NovaMatriz(); M[0, 0] = Sx; M[1, 1] = Sy;

            //X e Y médio
            /*double Mx = 0, My = 0;
            for (int i = 0; i < Vertices.Count; i++)
            {
                Mx += Vertices[i].X;
                My += Vertices[i].Y;
            }
            Mx = Mx / Vertices.Count;
            My = My / Vertices.Count;*/

            // Translada(Mx, My);
            MultMat(M);
            //Translada(-Mx, -My);
            AtualizaVertices();
        }

        //METODOS PRIVADOS
        private double[,] NovaMatriz()
        {
            double[,] M = new double[4, 4];
            M[0, 0] = M[1, 1] = M[2, 2] = M[3,3] = 1;
            return M;
        }
        private void MultMat(double[,] M)
        {
            double soma = 0;
            for (int l = 0; l < 4; l++)
            {
                for (int c = 0; c < 4; c++)
                {
                    soma = 0;
                    for (int k = 0; k < 4; k++)
                        soma += MA[l, k] * M[k, c];
                    this.MA[l, c] = soma;
                }
            }
        }        
        private void AtualizaVertices()
        {
            Vertice V, newV;
            VerticesAtuais.Clear();

            for (int i = 0; i < Vertices.Count; i++)
            {
                newV = new Vertice();
                V = Vertices[i];
                newV.X = (int)((V.X * MA[0, 0]) + (V.Y * MA[0, 1]) + (V.Z * MA[0, 2]) + MA[0, 3]);
                newV.Y = (int)((V.X * MA[1, 0]) + (V.Y * MA[1, 1]) + (V.Z * MA[1, 2]) + MA[1, 3]);
                newV.Z = (int)((V.X * MA[2, 0]) + (V.Y * MA[2, 1]) + (V.Z * MA[2, 2]) + MA[2, 3]);
                this.VerticesAtuais.Add(newV);
            }
        }

    }
}
