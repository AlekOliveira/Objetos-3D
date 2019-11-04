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
        public List<Face> Faces = new List<Face>();
        public List<Vetor> NormaisFaces = new List<Vetor>();
        //Lista de normais das faces
        //Lista de normais dos vértices


        private double[,] MA = new double[4,4];
        public int dx = 425, dy = 375;

        

        public Obj3D(List<Vertice> vertices, List<Face> faces)
        {
            this.Faces = faces;
            this.Vertices = vertices;
            this.MA = NovaMatriz();
            AtualizaVertices();
        }

        //METODOS PUBLICOS
        public void DesenhaFaces(DirectBitmap bmp, Color cor, bool visivel)
        {
            Vertice v1, v2, v3;
            foreach (Face f in this.Faces)
            {
                v1 = new Vertice(VerticesAtuais[f.Idx0].X + dx, VerticesAtuais[f.Idx0].Y + dy, 0);
                v2 = new Vertice(VerticesAtuais[f.Idx1].X + dx, VerticesAtuais[f.Idx1].Y + dy, 0);
                v3 = new Vertice(VerticesAtuais[f.Idx2].X + dx, VerticesAtuais[f.Idx2].Y + dy, 0);
                if (visivel)
                {
                    if (f.calculaNormal(VerticesAtuais, NormaisFaces))
                    {
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                        Primitivas.Bresenhan(v2, v3, bmp, cor);
                        Primitivas.Bresenhan(v3, v1, bmp, cor);
                    }
                }
                else
                {
                    Primitivas.Bresenhan(v1, v2, bmp, cor);
                    Primitivas.Bresenhan(v2, v3, bmp, cor);
                    Primitivas.Bresenhan(v3, v1, bmp, cor);
                }
            }
        }

        public void Translada(double Tx, double Ty, double Tz)
        {
            double[,] M = NovaMatriz(); M[0, 3] = Tx; M[1, 3] = Ty; M[2,3] = Tz;

            MultMat(M);
            AtualizaVertices();
        }

        public void RotacionaX(double R)
        {
            R = (R * Math.PI) / 180;
           
            double[,] M = NovaMatriz();
            M[1, 1] = Math.Cos(R);
            M[1, 2] = -Math.Sin(R);
            M[2, 1] = Math.Sin(R);
            M[2, 2] = Math.Cos(R);

            double mx = 0, my = 0, mz = 0;
            for (int i = 0; i < VerticesAtuais.Count; i ++)
            {
                mx += VerticesAtuais[i].X;
                my += VerticesAtuais[i].Y;
                mz += VerticesAtuais[i].Z;
            }
            mx /= VerticesAtuais.Count;
            my /= VerticesAtuais.Count;
            mz /= VerticesAtuais.Count;


            Translada(-mx, -my, 0);
            MultMat(M);
            Translada(mx, my, 0);
            AtualizaVertices();
        }

        public void RotacionaZ(double R)
        {
            R = (R * Math.PI) / 180;

            double[,] M = NovaMatriz();
            M[0, 0] = Math.Cos(R);
            M[0, 1] = -Math.Sin(R);
            M[1, 0] = Math.Sin(R);
            M[1, 1] = Math.Cos(R);

            MultMat(M);
            AtualizaVertices();
        }

        public void RotacionaY(double R)
        {
            R = (R * Math.PI) / 180;

            double[,] M = NovaMatriz();
            M[0, 0] = Math.Cos(R);
            M[2, 0] = -Math.Sin(R);
            M[0, 2] = Math.Sin(R);
            M[2, 2] = Math.Cos(R);

            MultMat(M);
            AtualizaVertices();
        }

        public void Escala(double Sx, double Sy, double Sz)
        {                       
            double[,] M = NovaMatriz(); M[0, 0] = Sx; M[1, 1] = Sy; M[2, 2] = Sy;
            MultMat(M);
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
            double[,] aux = NovaMatriz();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    soma = 0;
                    for (int k = 0; k < 4; k++)
                        soma += M[i, k] * MA[k, j]; 

                    aux[i, j] = soma;
                }
            }
            this.MA = aux;
        }
        

        private void AtualizaVertices()
        {
            Vertice V, newV;
            VerticesAtuais.Clear();

            for (int i = 0; i < Vertices.Count; i++)
            {
                newV = new Vertice();
                V = Vertices[i];
                newV.X = ((V.X * MA[0, 0]) + (V.Y * MA[0, 1]) + (V.Z * MA[0, 2]) + MA[0, 3]);
                newV.Y = ((V.X * MA[1, 0]) + (V.Y * MA[1, 1]) + (V.Z * MA[1, 2]) + MA[1, 3]);
                newV.Z = ((V.X * MA[2, 0]) + (V.Y * MA[2, 1]) + (V.Z * MA[2, 2]) + MA[2, 3]);
                this.VerticesAtuais.Add(newV);
            }
        }

        
    }
}
