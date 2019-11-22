using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Face
    {
        private List<int> Faces;
        private Vetor vetNormal;
        private Vetor olho = new Vetor(0, 0 ,1);

        public Face(List<int> faces)
        {
            Faces = faces;
        }

        public int getFace(int index)
        {
            return Faces[index];
        }

        public int length()
        {
            return Faces.Count;
        }

        public bool calculaNormal(List<Vertice> Vertices)
        {
            Vetor AB = new Vetor(Vertices[getFace(1)].X - Vertices[getFace(0)].X, Vertices[getFace(1)].Y - Vertices[getFace(0)].Y, Vertices[getFace(1)].Z - Vertices[getFace(1)].Z);
            Vetor AC = new Vetor(Vertices[getFace(2)].X - Vertices[getFace(0)].X, Vertices[getFace(2)].Y - Vertices[getFace(0)].Y, Vertices[getFace(2)].Z - Vertices[getFace(0)].Z);

            Vetor VN = new Vetor();

            VN.X = AB.Y * AC.Z - AB.Z * AC.Y;
            VN.Y = AB.Z * AC.X - AB.X * AC.Z;
            VN.Z = AB.X * AC.Y - AB.Y * AC.X;


            double moduloVN = Math.Sqrt(Math.Pow(VN.X, 2) + Math.Pow(VN.Y, 2) + Math.Pow(VN.Z, 2));
            VN.X /= moduloVN;
            VN.Y /= moduloVN;
            VN.Z /= moduloVN;

            vetNormal = new Vetor(VN.X, VN.Y, VN.Z);           

            if (VN.Z >= 0)
                return true;
            return false;
        }

        public Vertice MaxPoint(List<Vertice> verticesAtuais)
        {
            Vertice aux = new Vertice(int.MinValue, int.MinValue, int.MinValue);
            foreach (Vertice v in verticesAtuais)
            {
                if (aux.X < v.X)
                    aux.X = v.X;
                if (aux.Y < v.Y)
                    aux.Y = v.Y;
                if (aux.Z < v.Z)
                    aux.Z = v.Z;                
            }
            return aux;
        }

        public Vertice MinPoint(List<Vertice> verticesAtuais)
        {
            Vertice aux = new Vertice(int.MaxValue, int.MaxValue, int.MaxValue);
            for (int i = 0; i < Faces.Count(); i++)
            {
                if (verticesAtuais[getFace(i)].Y < aux.Y)
                    aux.Y = verticesAtuais[getFace(i)].Y;
            }
            return aux;
        }       

        public void ScanLineFlat(DirectBitmap b, Color cor, List<Vertice> verticesAtuais, double [,] zbuffer, Vetor luz)
        {
            calculaNormal(verticesAtuais);
            int cx = 425, cy = 375;
            Vertice max = MaxPoint(verticesAtuais), min = MinPoint(verticesAtuais);
            Vertice 
            h = new Vertice(0, 0, 0), 
            l_a = new Vertice(0.3, 0.3, 0.3), 
            l_d = new Vertice(0.5, 0.5, 0.5),
            l_e = new Vertice(0.5, 0.5, 0.5), 
            k_a = new Vertice(0.9, 0.9, 0.9),                                                
            k_d = new Vertice(cor.R / 255, cor.G / 255, cor.B / 255), 
            k_e = new Vertice(0.5, 0.5, 0.5);

            int n = 10;
            double dif, esp;

            double dy = max.Y - min.Y + 1;
            List<ET>[] Et = new List<ET>[(int)dy]; // Cria o vetor da ET (Uso vetor pq achei mais facil, os indices dele são os Ymin da comparações
            int i;

            for (i = 0; i < Faces.Count(); i++) //Percorro a face, vendo os vertices que elas fazem ligação
            {     
                Vertice ma, mi;
                if (i == Faces.Count() - 1) //Traca o caso do ultimo com o primeiro
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(0)].Y) // Verifico qual é o maior Y, e salvo ele
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(0)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(0)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }
                else // Caso não seja o ultimo com o primeiro, pego o proximo cara
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(i + 1)].Y)
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(i + 1)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(i + 1)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }

                int idx = (int)(mi.Y - min.Y); // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                               // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo

                if (Et[idx] == null) // Se for null eu crio uma nova lista
                    Et[idx] = new List<ET>();
                double x = (ma.Y - mi.Y); // Calculo o incremento. isso é para não dar divisão por 0
                x = x == 0 ? 0 : (ma.X - mi.X) / x;

                Et[idx].Add(new ET(ma.Y, mi.Y, mi.X, x, 1, 1, 1, 1, 1, 1, 1, 1)); // Add na ET e repito tudo
            }

            double mod = Math.Sqrt(Math.Pow(luz.X, 2) + Math.Pow(luz.Y, 2) + Math.Pow(luz.Z, 2)); //modulo luz
            luz.X /= mod; luz.Y /= mod; luz.Z /= mod;// normalização luz

            h.X = luz.X + olho.X;
            h.Y = luz.Y + olho.Y;
            h.Z = luz.Z + olho.Z;
            mod = Math.Sqrt(Math.Pow(h.X, 2) + Math.Pow(h.Y, 2) + Math.Pow(h.Z, 2));
            h.X /= mod;
            h.Y /= mod;
            h.Z /= mod;

            dif = luz.X * vetNormal.X + luz.Y * vetNormal.Y + luz.Z * vetNormal.Z;
            esp = Math.Pow(h.X * vetNormal.X + h.Y * vetNormal.Y + h.Z * vetNormal.Z, n);

            cor = Color.FromArgb(
                (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));

            List<ET> AET = new List<ET>(); //Crio a AET
            i = 0;
            foreach (ET no in Et[i]) //Inicio ela, adicionando os nos da primeira posição
                AET.Add(no);
            do
            {
                for (int j = AET.Count - 1; j >= 0; j--) // Removo os ymax de tras para frente
                    if ((AET[j].YMax) >= (i + min.Y - 1) && (AET[j].YMax) <= (i + min.Y + 1))
                        AET.RemoveAt(j);
                if (AET.Count > 0) // SE ainda tiver gente na AET
                {
                    AET.Sort(new XCompare()); // ordeno por X

                    //double IncRx; //r2 - r1 / x2 - x1
                    //double IncGx; //g2 - g1 / x2 - x1
                    //double IncBx; //b2 - b1 / x2 - x1
                    //double IncZx; //z2 - z1 / x2 - x1

                    for (int j = 0; j < AET.Count; j += 2) // aqui eu faço o for de 2 em 2 e desenho o bresenhan. Ta diferente por conta da luz
                    {
                        // verificar z buffer
                        for (int k = cx + (int)AET[j].Xmin1; k <= cx + ((int)AET[j + 1].Xmin1); k++)
                        {
                            if (AET[j].Zmin1 < zbuffer[cy + i + (int)min.Y, k])
                            {
                                  b.SetPixel(k, cy + i + (int)min.Y, cor);
                                  zbuffer[cy + i + (int)min.Y, k] = AET[j].Zmin1;
                            }
                             //incrementar aqui
                            
                        }
                    }

                    foreach (ET e in AET) // Atualizo o X
                        e.Att();

                    i++; // Esse i representa aquele y que percorre a ET, incremento ele aqui

                    if (i < (int)dy && Et[i] != null) //Se tiver gente na posição do i, add na AET
                        foreach (ET no in Et[i])
                            AET.Add(no);
                }
            } while (AET.Count > 0);
        }

        public void ScanLine2(DirectBitmap b, Color cor, List<Vertice> verticesAtuais)
        {
            //int cx = b.Width / 2, cy = b.Height / 2;
            int cx = 425, cy = 375;
            Vertice max = MaxPoint(verticesAtuais), min = MinPoint(verticesAtuais);
            /*Vertice h = new Vertice(0, 0, 0), 
            l_a = new Vertice(0.3, 0.3, 0.3), 
            l_d = new Vertice(0.5, 0.5, 0.5),
            l_e = new Vertice(0.5, 0.5, 0.5), 
            k_a = new Vertice(1.0, 1.0, 1.0),                                                
            k_d = new Vertice(cor.R / 255, cor.G / 255, cor.B / 255), 
            k_e = new Vertice(0.5, 0.5, 0.6);

            int no = 10;
            double dif, esp;*/

            double dy = max.Y - min.Y + 1;
            List<ET>[] Et = new List<ET>[(int)dy]; // Cria o vetor da ET (Uso vetor pq achei mais facil, os indices dele são os Ymin da comparações
            int i;

            for (i = 0; i < Faces.Count(); i++) //Percorro a face, vendo os vertices que elas fazem ligação
            {
                Vertice ma, mi;
                if (i == Faces.Count() - 1) //Traca o caso do ultimo com o primeiro
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(0)].Y) // Verifico qual é o maior Y, e salvo ele
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(0)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(0)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }
                else // Caso não seja o ultimo com o primeiro, pego o proximo cara
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(i + 1)].Y)
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(i + 1)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(i + 1)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }

                int idx = (int)(mi.Y - min.Y); // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                               // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo

                if (Et[idx] == null) // Se for null eu crio uma nova lista
                    Et[idx] = new List<ET>();
                double x = (ma.Y - mi.Y); // Calculo o incremento. isso é para não dar divisão por 0
                x = x == 0 ? 0 : (ma.X - mi.X) / x;

                Et[idx].Add(new ET(ma.Y, mi.Y, mi.X, x, 1, 1, 1, 1, 1, 1, 1, 1)); // Add na ET e repito tudo
            }

            /*h.X = luz.X + olho.X;
            h.Y = luz.Y + olho.Y;
            h.Z = luz.Z + olho.Z;
            h = NormalizaVetor(h);

            dif = luz.X * normalFaces[faces.IndexOf(f)].X + luz.Y * normalFaces[faces.IndexOf(f)].Y + luz.Z * normalFaces[faces.IndexOf(f)].Z;
            esp = Math.Pow(h.X * normalFaces[faces.IndexOf(f)].X + h.Y * normalFaces[faces.IndexOf(f)].Y + h.Z * normalFaces[faces.IndexOf(f)].Z, no);

            cor = Color.FromArgb(
                (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));*/

            List<ET> AET = new List<ET>(); //Crio a AET
            i = 0;
            foreach (ET n in Et[i]) //Inicio ela, adicionando os nos da primeira posição
                AET.Add(n);
            do
            {
                for (int j = AET.Count - 1; j >= 0; j--) // Removo os ymax de tras para frente
                    if ((AET[j].YMax) >= (i + min.Y - 1) && (AET[j].YMax) <= (i + min.Y + 1))
                        AET.RemoveAt(j);
                if (AET.Count > 0) // SE ainda tiver gente na AET
                {
                    AET.Sort(new XCompare()); // ordeno por X

                    //double IncRx; //r2 - r1 / x2 - x1
                    //double IncGx; //g2 - g1 / x2 - x1
                    //double IncBx; //b2 - b1 / x2 - x1
                    //double IncZx; //z2 - z1 / x2 - x1

                    for (int j = 0; j < AET.Count; j += 2) // aqui eu faço o for de 2 em 2 e desenho o bresenhan. Ta diferente por conta da luz
                    {
                        // verificar z buffer
                        //for (int k = cx + (int)AET[j].Xmin1; k <= cx + ((int)AET[j + 1].Xmin1); k++)
                        //{
                        //if (AET[j].Zmin1 > zbuffer[cy + i + (int)min.Y, k])
                        //{
                        //    imagem.SetPixel(k, cy + i + (int)min.Y, cor);
                        //  zbuffer[cy + i + (int)min.Y, k] = AET[j].Zmin1;
                        //}
                        // incrementar aqui
                        Primitivas.Bresenhan(new Vertice(AET[j].Xmin1 + cx, (i + min.Y + cy), 0), new Vertice(AET[j + 1].Xmin1 + cx, (i + min.Y + cy), 0), b, cor);
                        //}
                    }

                    foreach (ET e in AET) // Atualizo o X
                        e.Att();

                    i++; // Esse i representa aquele y que percorre a ET, incremento ele aqui

                    if (i < (int)dy && Et[i] != null) //Se tiver gente na posição do i, add na AET
                        foreach (ET n in Et[i])
                            AET.Add(n);
                }
            } while (AET.Count > 0);
        }

        public void ScanLine3(DirectBitmap b, Color cor, List<Vertice> verticesAtuais)
        {
            //int cx = b.Width / 2, cy = b.Height / 2;
            int cx = 425, cy = 375;
            Vertice max = MaxPoint(verticesAtuais), min = MinPoint(verticesAtuais);
            /*Vertice h = new Vertice(0, 0, 0), 
            l_a = new Vertice(0.3, 0.3, 0.3), 
            l_d = new Vertice(0.5, 0.5, 0.5),
            l_e = new Vertice(0.5, 0.5, 0.5), 
            k_a = new Vertice(1.0, 1.0, 1.0),                                                
            k_d = new Vertice(cor.R / 255, cor.G / 255, cor.B / 255), 
            k_e = new Vertice(0.5, 0.5, 0.6);

            int no = 10;
            double dif, esp;*/

            double dy = max.Y - min.Y + 1;
            List<ET>[] Et = new List<ET>[(int)dy]; // Cria o vetor da ET (Uso vetor pq achei mais facil, os indices dele são os Ymin da comparações
            int i;

            for (i = 0; i < Faces.Count(); i++) //Percorro a face, vendo os vertices que elas fazem ligação
            {
                Vertice ma, mi;
                if (i == Faces.Count() - 1) //Traca o caso do ultimo com o primeiro
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(0)].Y) // Verifico qual é o maior Y, e salvo ele
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(0)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(0)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }
                else // Caso não seja o ultimo com o primeiro, pego o proximo cara
                {
                    if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(i + 1)].Y)
                    {
                        ma = verticesAtuais[this.getFace(i)];
                        mi = verticesAtuais[this.getFace(i + 1)];
                    }
                    else
                    {
                        ma = verticesAtuais[this.getFace(i + 1)];
                        mi = verticesAtuais[this.getFace(i)];
                    }
                }

                int idx = (int)(mi.Y - min.Y); // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                               // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo

                if (Et[idx] == null) // Se for null eu crio uma nova lista
                    Et[idx] = new List<ET>();
                double x = (ma.Y - mi.Y); // Calculo o incremento. isso é para não dar divisão por 0
                x = x == 0 ? 0 : (ma.X - mi.X) / x;

                Et[idx].Add(new ET(ma.Y, mi.Y, mi.X, x, 1, 1, 1, 1, 1, 1, 1, 1)); // Add na ET e repito tudo
            }

            /*h.X = luz.X + olho.X;
            h.Y = luz.Y + olho.Y;
            h.Z = luz.Z + olho.Z;
            h = NormalizaVetor(h);

            dif = luz.X * normalFaces[faces.IndexOf(f)].X + luz.Y * normalFaces[faces.IndexOf(f)].Y + luz.Z * normalFaces[faces.IndexOf(f)].Z;
            esp = Math.Pow(h.X * normalFaces[faces.IndexOf(f)].X + h.Y * normalFaces[faces.IndexOf(f)].Y + h.Z * normalFaces[faces.IndexOf(f)].Z, no);

            cor = Color.FromArgb(
                (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));*/

            List<ET> AET = new List<ET>(); //Crio a AET
            i = 0;
            foreach (ET n in Et[i]) //Inicio ela, adicionando os nos da primeira posição
                AET.Add(n);
            do
            {
                for (int j = AET.Count - 1; j >= 0; j--) // Removo os ymax de tras para frente
                    if ((AET[j].YMax) >= (i + min.Y - 1) && (AET[j].YMax) <= (i + min.Y + 1))
                        AET.RemoveAt(j);
                if (AET.Count > 0) // SE ainda tiver gente na AET
                {
                    AET.Sort(new XCompare()); // ordeno por X

                    //double IncRx; //r2 - r1 / x2 - x1
                    //double IncGx; //g2 - g1 / x2 - x1
                    //double IncBx; //b2 - b1 / x2 - x1
                    //double IncZx; //z2 - z1 / x2 - x1

                    for (int j = 0; j < AET.Count; j += 2) // aqui eu faço o for de 2 em 2 e desenho o bresenhan. Ta diferente por conta da luz
                    {
                        // verificar z buffer
                        //for (int k = cx + (int)AET[j].Xmin1; k <= cx + ((int)AET[j + 1].Xmin1); k++)
                        //{
                        //if (AET[j].Zmin1 > zbuffer[cy + i + (int)min.Y, k])
                        //{
                        //    imagem.SetPixel(k, cy + i + (int)min.Y, cor);
                        //  zbuffer[cy + i + (int)min.Y, k] = AET[j].Zmin1;
                        //}
                        // incrementar aqui
                        Primitivas.Bresenhan(new Vertice(AET[j].Xmin1 + cx, (i + min.Y + cy), 0), new Vertice(AET[j + 1].Xmin1 + cx, (i + min.Y + cy), 0), b, cor);
                        //}
                    }

                    foreach (ET e in AET) // Atualizo o X
                        e.Att();

                    i++; // Esse i representa aquele y que percorre a ET, incremento ele aqui

                    if (i < (int)dy && Et[i] != null) //Se tiver gente na posição do i, add na AET
                        foreach (ET n in Et[i])
                            AET.Add(n);
                }
            } while (AET.Count > 0);
        }
        public class XCompare : IComparer<ET>
        {
            public int Compare(ET x, ET y)
            {
                return x.Xmin1.CompareTo(y.Xmin1);
            }
        }



        /*public void ScanLine(DirectBitmap imagem, Color cor, Face f)
        {
            int cx = imagem.Width / 2, cy = imagem.Height / 2;
            Vertice max = MaxPoint(f), min = MinPoint(f);
            Vertice h = new Vertice(0, 0, 0), l_a = new Vertice(0.3, 0.3, 0.3), l_d = new Vertice(0.5, 0.5, 0.5),
                                                l_e = new Vertice(0.5, 0.5, 0.5), k_a = new Vertice(1.0, 1.0, 1.0),
                                                k_d = new Vertice(cor.R / 255, cor.G / 255, cor.B / 255), k_e = new Vertice(0.5, 0.5, 0.6);
            int no = 10;
            double dif, esp;

            double dy = max.Y - min.Y + 1;
            List<No>[] ET = new List<No>[(int)dy]; // Cria o vetor da ET (Uso vetor pq achei mais facil, os indices dele são os Ymin da comparações
            int i;

            for (i = 0; i < f.Count(); i++) //Percorro a face, vendo os vertices que elas fazem ligação
            {
                Vertice ma, mi;
                if (i == f.Count() - 1) //Traca o caso do ultimo com o primeiro
                {
                    if (verticesAtuais[f.GetPos(i)].Y >= verticesAtuais[f.GetPos(0)].Y) // Verifico qual é o maior Y, e salvo ele
                    {
                        ma = verticesAtuais[f.GetPos(i)];
                        mi = verticesAtuais[f.GetPos(0)];
                    }
                    else
                    {
                        ma = verticesAtuais[f.GetPos(0)];
                        mi = verticesAtuais[f.GetPos(i)];
                    }
                }
                else // Caso não seja o ultimo com o primeiro, pego o proximo cara
                {
                    if (verticesAtuais[f.GetPos(i)].Y >= verticesAtuais[f.GetPos(i + 1)].Y)
                    {
                        ma = verticesAtuais[f.GetPos(i)];
                        mi = verticesAtuais[f.GetPos(i + 1)];
                    }
                    else
                    {
                        ma = verticesAtuais[f.GetPos(i + 1)];
                        mi = verticesAtuais[f.GetPos(i)];
                    }
                }

                int idx = (int)(mi.Y - min.Y); // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                               // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo

                if (ET[idx] == null) // Se for null eu crio uma nova lista
                    ET[idx] = new List<No>();
                double x = (ma.Y - mi.Y); // Calculo o incremento. isso é para não dar divisão por 0
                x = x == 0 ? 0 : (ma.X - mi.X) / x;

                ET[idx].Add(new No(x, ma.Y, mi.X, 1, 1, 1, 1, 1, 1, mi.Z, 1)); // Add na ET e repito tudo
            }

            h.X = luz.X + olho.X;
            h.Y = luz.Y + olho.Y;
            h.Z = luz.Z + olho.Z;
            h = NormalizaVetor(h);

            dif = luz.X * normalFaces[faces.IndexOf(f)].X + luz.Y * normalFaces[faces.IndexOf(f)].Y + luz.Z * normalFaces[faces.IndexOf(f)].Z;
            esp = Math.Pow(h.X * normalFaces[faces.IndexOf(f)].X + h.Y * normalFaces[faces.IndexOf(f)].Y + h.Z * normalFaces[faces.IndexOf(f)].Z, no);

            cor = Color.FromArgb(
                (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));

            List<No> AET = new List<No>(); //Crio a AET
            i = 0;
            foreach (No n in ET[i]) //Inicio ela, adicionando os nos da primeira posição
                AET.Add(n);
            do
            {
                for (int j = AET.Count - 1; j >= 0; j--) // Removo os ymax de tras para frente
                    if ((AET[j].Ymax1) >= (i + min.Y - 1) && (AET[j].Ymax1) <= (i + min.Y + 1))
                        AET.RemoveAt(j);
                if (AET.Count > 0) // SE ainda tiver gente na AET
                {
                    AET.Sort(new XCompare()); // ordeno por X

                    double IncRx; //r2 - r1 / x2 - x1
                    double IncGx; //g2 - g1 / x2 - x1
                    double IncBx; //b2 - b1 / x2 - x1
                    double IncZx; //z2 - z1 / x2 - x1

                    for (int j = 0; j < AET.Count; j += 2) // aqui eu faço o for de 2 em 2 e desenho o bresenhan. Ta diferente por conta da luz
                    {
                        // verificar z buffer
                        for (int k = cx + (int)AET[j].Xmin1; k <= cx + ((int)AET[j + 1].Xmin1); k++)
                        {
                            if (AET[j].Zmin1 > zbuffer[cy + i + (int)min.Y, k])
                            {
                                imagem.SetPixel(k, cy + i + (int)min.Y, cor);
                                zbuffer[cy + i + (int)min.Y, k] = AET[j].Zmin1;
                            }
                            // incrementar aqui
                        }
                    }

                    foreach (No e in AET) // Atualizo o X
                        e.Att();

                    i++; // Esse i representa aquele y que percorre a ET, incremento ele aqui

                    if (i < (int)dy && ET[i] != null) //Se tiver gente na posição do i, add na AET
                        foreach (No n in ET[i])
                            AET.Add(n);
                }
            } while (AET.Count > 0);
        }
        public class XCompare : IComparer<No>
        {
            public int Compare(No x, No y)
            {
                return x.Xmin1.CompareTo(y.Xmin1);
            }
        }*/
    }
}
