using System;
using System.Collections.Generic;
using System.Drawing;

namespace Objetos_3D
{
    class Obj3D
    {
        public List<Vertice> Vertices = new List<Vertice>();
        public List<Vertice> VerticesAtuais = new List<Vertice>();
        public List<Face> Faces = new List<Face>();
        public List<Vetor> NormaisFaces = new List<Vetor>();
        private Vetor luz = new Vetor(10, 10, 10);
        public double[,] zbuffer;
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
        public void DesenhaXY(DirectBitmap bmp, Color cor, bool visivel)
        {
            zBuffer(bmp.Width, bmp.Height);
            Vertice v1, v2;
            foreach (Face f in this.Faces)
            {

                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].X + dx, VerticesAtuais[f.getFace(i)].Y + dy, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].X + dx, VerticesAtuais[f.getFace(0)].Y + dy, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].X + dx, VerticesAtuais[f.getFace(i + 1)].Y + dy, VerticesAtuais[f.getFace(i + 1)].Z);

                    if (visivel)
                    {
                        if(f.calculaNormal(VerticesAtuais))
                        {
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                        }
                            
                    }
                    else
                    {
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }

                }
            }
        }

        public void DesenhaXZ(DirectBitmap bmp, Color cor, bool visivel)
        {
            zBuffer(bmp.Width, bmp.Height);
            Vertice v1, v2;
            foreach (Face f in this.Faces)
            {

                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].X + dx, VerticesAtuais[f.getFace(i)].Z+ dy, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].X + dx, VerticesAtuais[f.getFace(0)].Z + dy, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].X + dx, VerticesAtuais[f.getFace(i + 1)].Z + dy, VerticesAtuais[f.getFace(i + 1)].Z);

                    if (visivel)
                    {
                        f.calculaNormal(VerticesAtuais);
                        if (f.VetNormal.Y >= 0)
                        {
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                        }
                    }
                    else
                    {
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }
                }
            }
        }

        public void DesenhaYZ(DirectBitmap bmp, Color cor, bool visivel)
        {
            zBuffer(bmp.Width, bmp.Height);
            Vertice v1, v2;
            foreach (Face f in this.Faces)
            {

                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].Y + dx, VerticesAtuais[f.getFace(i)].Z + dy, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].Y + dx, VerticesAtuais[f.getFace(0)].Z + dy, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].Y + dx, VerticesAtuais[f.getFace(i + 1)].Z + dy, VerticesAtuais[f.getFace(i + 1)].Z);

                    if (visivel)
                    {
                        f.calculaNormal(VerticesAtuais);
                        if (f.VetNormal.X >= 0)
                        {
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                        }

                    }
                    else
                    {
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }

                }
            }
        }

        public void FlatShading(DirectBitmap bmp, Color cor)
        {
            zBuffer(bmp.Width, bmp.Height);
            foreach (Face f in Faces)
            {
                f.calculaNormal(VerticesAtuais);
                f.ScanLineFlat(bmp, cor, VerticesAtuais, zbuffer, luz);
            }
        }

        public void PhongShading(DirectBitmap bmp, Color cor)
        {
            GeraNormalVertice();
            zBuffer(bmp.Width, bmp.Height);
            foreach (Face f in Faces)
                f.ScanLinePhong(bmp, cor, VerticesAtuais, zbuffer, luz);
        }

        public void GouraudtShading(DirectBitmap bmp, Color cor)
        {
            GeraNormalVertice();
            zBuffer(bmp.Width, bmp.Height);
            foreach (Face f in Faces)
                f.ScanLineGourard(bmp, cor, VerticesAtuais, zbuffer, luz);
        }
        
        public void DesenhaCabinet(DirectBitmap bmp, Color cor, bool visivel)
        {

            double alfa = (Math.PI * 63.4) /180;
            Vertice v1, v2;

            foreach (Face f in this.Faces)
            {
                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].X + dx, VerticesAtuais[f.getFace(i)].Y + dy, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].X + dx, VerticesAtuais[f.getFace(0)].Y + dy, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].X + dx, VerticesAtuais[f.getFace(i + 1)].Y + dy, VerticesAtuais[f.getFace(i + 1)].Z);


                    v1.X = v1.X + (v1.Z * (Math.Cos(alfa)) * 0.5);
                    v1.Y = v1.Y + (v1.Z * (Math.Sin(alfa))* 0.5) ;

                    v2.X = v2.X + (v2.Z * (Math.Cos(alfa))* 0.5) ;
                    v2.Y = v2.Y + (v2.Z * (Math.Sin(alfa))* 0.5) ;


                    /*if (visivel)
                    {
                        if (f.calculaNormal(VerticesAtuais, NormaisFaces))
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }
                    else*/
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                }
            }
        }

        public void DesenhaCavaleira(DirectBitmap bmp, Color cor, bool visivel)
        {

            double alfa = (Math.PI * 45) / 180;
            Vertice v1, v2;

            foreach (Face f in this.Faces)
            {
                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].X + dx, VerticesAtuais[f.getFace(i)].Y + dy, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].X + dx, VerticesAtuais[f.getFace(0)].Y + dy, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].X + dx, VerticesAtuais[f.getFace(i + 1)].Y + dy, VerticesAtuais[f.getFace(i + 1)].Z);


                    v1.X = v1.X + (v1.Z * (Math.Cos(alfa)));
                    v1.Y = v1.Y + (v1.Z * (Math.Sin(alfa)));

                    v2.X = v2.X + (v2.Z * (Math.Cos(alfa)));
                    v2.Y = v2.Y + (v2.Z * (Math.Sin(alfa)));


                    /*if (visivel)
                    {
                        if (f.calculaNormal(VerticesAtuais, NormaisFaces))
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }
                    else*/
                        Primitivas.Bresenhan(v1, v2, bmp, cor);
                }
            }
        }

        public void DesenhaPtfuga(DirectBitmap bmp, Color cor, bool visivel)
        {
            int d = -400;
            Vertice v1, v2;

            foreach (Face f in this.Faces)
            {
                for (int i = 0; i < f.length(); i++)
                {
                    v1 = new Vertice(VerticesAtuais[f.getFace(i)].X, VerticesAtuais[f.getFace(i)].Y, VerticesAtuais[f.getFace(i)].Z);
                    if (i == f.length() - 1)
                        v2 = new Vertice(VerticesAtuais[f.getFace(0)].X, VerticesAtuais[f.getFace(0)].Y, VerticesAtuais[f.getFace(0)].Z);
                    else
                        v2 = new Vertice(VerticesAtuais[f.getFace(i + 1)].X, VerticesAtuais[f.getFace(i + 1)].Y, VerticesAtuais[f.getFace(i + 1)].Z);
                    

                    v1.X = v1.X * d/ (v1.Z += d);
                    v1.Y = v1.Y * d / v1.Z;
                    v2.X = v2.X * d / (v2.Z += d);
                    v2.Y = v2.Y * d / v2.Z;

                    v1.X += dx;
                    v1.Y += dy;
                    v2.X += dx;
                    v2.Y += dy;


                    /*if (visivel)
                    {
                        if (f.calculaNormal(VerticesAtuais, NormaisFaces))
                            Primitivas.Bresenhan(v1, v2, bmp, cor);
                    }
                    else*/
                    Primitivas.Bresenhan(v1, v2, bmp, cor);
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

        public void RotacionaY(double R)
        {
            R = (R * Math.PI) / 180;

            double[,] M = NovaMatriz();
            M[0, 0] = Math.Cos(R);
            M[2, 0] = -Math.Sin(R);
            M[0, 2] = Math.Sin(R);
            M[2, 2] = Math.Cos(R);

            double mx = 0, my = 0, mz = 0;
            for (int i = 0; i < VerticesAtuais.Count; i++)
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

            double mx = 0, my = 0, mz = 0;
            for (int i = 0; i < VerticesAtuais.Count; i++)
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

        public void setLuz(int x, int y, int z)
        {
            luz.X = x -dx;
            luz.Y = y -dy;
            luz.Z += z;
        }

        public void Escala(double Sx, double Sy, double Sz)
        {                       
            double[,] M = NovaMatriz(); M[0, 0] = Sx; M[1, 1] = Sy; M[2, 2] = Sy;
            double mx = 0, my = 0, mz = 0;

            for (int i = 0; i < VerticesAtuais.Count; i++)
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

        //METODOS PRIVADOS
        private double[,] NovaMatriz()
        {
            double[,] M = new double[4, 4];
            M[0, 0] = M[1, 1] = M[2, 2] = M[3,3] = 1;
            return M;
        }
               
        private void MultMat(double[,] M)
        {
            double soma;
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

        private void zBuffer(int width, int heigh)
        {
            zbuffer = new double[width, heigh];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigh; j++)
                    zbuffer[i, j] = int.MinValue;
        }

        private void GeraNormalVertice()
        {
            foreach (Face f in Faces)
                f.calculaNormal(VerticesAtuais);

            Vertice v = new Vertice(0, 0, 0);
            for (int i = 0; i < VerticesAtuais.Count; i++)
            {
                v.X = v.Y = v.Z = 0;
                foreach (Face f in Faces)
                    if (f.Contains(i))
                    {
                        v.X += f.VetNormal.X;
                        v.Y += f.VetNormal.Y;
                        v.Z += f.VetNormal.Z;
                    }
                double som = Math.Sqrt(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2));
                if (som.ToString().Equals("NaN") || som == 0)
                    VerticesAtuais[i].VetNormal = new Vetor(0, 0, 0);
                else
                    VerticesAtuais[i].VetNormal = new Vetor(v.X / som, v.Y / som, v.Z / som);
            } 
        }
    }
}
