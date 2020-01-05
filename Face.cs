using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Objetos_3D
{
    class Face
    {
        private List<int> Faces;
        private Vetor vetNormal;
        private Vetor olho = new Vetor(0, 0 ,1);
        internal Vetor VetNormal { get => vetNormal; set => vetNormal = value; }

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

        public bool Contains(int idx)
        {
            int i = 0;
            while (i < Faces.Count && Faces[i] != idx)
                i++;

            if (i < Faces.Count)
                return true;

            return false;
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
            if (moduloVN == 0 || moduloVN.ToString().Equals("NaN"))
                VN.X = VN.Y = VN.Z = 0;
            else
            {
                VN.X /= moduloVN;
                VN.Y /= moduloVN;
                VN.Z /= moduloVN;
            }

            if (VN.X.ToString().Equals("NaN") || VN.Y.ToString().Equals("NaN") || VN.Z.ToString().Equals("NaN"))
                VN.X = 1;

            VetNormal = new Vetor(VN.X, VN.Y, VN.Z);           

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
            if (calculaNormal(verticesAtuais))
            {
                int cx = 425, cy = 375;
                Vertice max = MaxPoint(verticesAtuais), min = MinPoint(verticesAtuais);
                Vertice
                h = new Vertice(0, 0, 0),
                l_a = new Vertice(0.1, 0.1, 0.1),
                l_d = new Vertice(0.5, 0.5, 0.5),
                l_e = new Vertice(0.5, 0.5, 0.5),
                k_a = new Vertice(1.0, 0.9, 0.9),
                k_d = new Vertice(cor.R / 255, cor.G / 255, cor.B / 255),
                k_e = new Vertice(0.5, 0.5, 0.5);

                int n = 10;
                double dif, esp;

                int faixaValores = b.Height;
                List<ET>[] Et = new List<ET>[faixaValores]; // Cria o vetor da ET (Uso vetor pq achei mais facil, os indices dele são os Ymin da comparações
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

                    int idx = (int)mi.Y + cy; // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                              // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo
                    if (idx < 0) idx = 0;
                    else if (idx >= b.Height) idx = b.Height - 1;

                    if (Et[idx] == null) // Se for null eu crio uma nova lista
                        Et[idx] = new List<ET>();

                    double dx = ma.X - mi.X;
                    double dy = ma.Y - mi.Y;
                    double dz = ma.Z - mi.Z;

                    double incx; // Calculo o incremento. isso é para não dar divisão por 0
                    incx = dy == 0 ? 0 : dx / dy;

                    Et[idx].Add(new ET((int)ma.Y + cy, (int)mi.Y + cy, mi.X + cx, incx, 1, 1, 1, mi.Z, 1, 1, 1, dy == 0 ? 0 : dz / dy)); // Add na ET e repito tudo
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

                dif = luz.X * VetNormal.X + luz.Y * VetNormal.Y + luz.Z * VetNormal.Z;
                esp = Math.Pow(h.X * VetNormal.X + h.Y * VetNormal.Y + h.Z * VetNormal.Z, n);

                cor = Color.FromArgb(
                    (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                    (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                    (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));

                List<ET> AET = new List<ET>(); //Crio a AET
                i = 0;

                while (Et[i] == null)
                    i++;

                foreach (ET no in Et[i]) //Inicio ela, adicionando os nos da primeira posição
                    AET.Add(no);
                do
                {
                    for (int j = AET.Count - 1; j >= 0; j--) // Removo os ymax de tras para frente
                        if (AET[j].YMax <= i)
                            AET.RemoveAt(j);

                    if (AET.Count > 0) // SE ainda tiver gente na AET
                    {
                        AET.Sort(new XCompare()); // ordeno por X

                        for (int j = 0; j < AET.Count; j += 2) // aqui eu faço o for de 2 em 2 e desenho o bresenhan. Ta diferente por conta da luz
                        {
                            int x1 = (int)AET[j].Xmin1, x2 = (int)AET[j + 1].Xmin1, y = i;
                            double dx = x2 - x1;

                            double incZ = (AET[j + 1].Zmin1 - AET[j].Zmin1) / dx, z = AET[j].Zmin1;                            

                            while (x1++ <= x2)
                            {
                                if (y < b.Height && y >= 0 && x1 < b.Width && x1 >= 0 &&
                                     z > zbuffer[x1, y])
                                {
                                    b.SetPixel(x1, y, cor);
                                    zbuffer[x1, y] = z;
                                }

                                z += incZ;
                            }
                        }

                        foreach (ET e in AET) // Atualizo o X
                            e.Att();

                        i++; // Esse i representa aquele y que percorre a ET, incremento ele aqui

                        if (i < faixaValores && Et[i] != null) //Se tiver gente na posição do i, add na AET
                            foreach (ET no in Et[i])
                                AET.Add(no);
                    }
                } while (AET.Count > 0);
            }
        }

        public void ScanLineGourard(DirectBitmap db, Color cor, List<Vertice> verticesAtuais, double[,] zbuffer, Vetor luz)
        {
            if (calculaNormal(verticesAtuais))
            {
                int cx = 425, cy = 375;
                List<Color> cores = new List<Color>();
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

                List<ET>[] Et = new List<ET>[db.Height];
                int i;
                double mod = Math.Sqrt(Math.Pow(luz.X, 2) + Math.Pow(luz.Y, 2) + Math.Pow(luz.Z, 2));
                luz.X /= mod; luz.Y /= mod; luz.Z /= mod;

                h.X = luz.X + olho.X;
                h.Y = luz.Y + olho.Y;
                h.Z = luz.Z + olho.Z;
                mod = Math.Sqrt(Math.Pow(h.X, 2) + Math.Pow(h.Y, 2) + Math.Pow(h.Z, 2));
                h.X /= mod;
                h.Y /= mod;
                h.Z /= mod;

                for (i = 0; i < Faces.Count(); i++) //Intensidade
                {
                    dif = luz.X * verticesAtuais[this.getFace(i)].VetNormal.X + luz.Y * verticesAtuais[this.getFace(i)].VetNormal.Y + luz.Z * verticesAtuais[this.getFace(i)].VetNormal.Z;
                    esp = Math.Pow(h.X * verticesAtuais[this.getFace(i)].VetNormal.X + h.Y * verticesAtuais[this.getFace(i)].VetNormal.Y + h.Z * verticesAtuais[this.getFace(i)].VetNormal.Z, n);
                    cores.Add(
                        Color.FromArgb(
                        (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                        (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                        (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255)));
                }

                int idxMai, idxMen;

                for (i = 0; i < Faces.Count(); i++)
                {
                    Vertice ma, mi;
                    if (i == Faces.Count() - 1)
                    {
                        if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(0)].Y)
                        {
                            ma = verticesAtuais[this.getFace(i)];
                            mi = verticesAtuais[this.getFace(0)];
                            idxMen = 0;
                            idxMai = i;
                        }
                        else
                        {
                            ma = verticesAtuais[this.getFace(0)];
                            mi = verticesAtuais[this.getFace(i)];
                            idxMen = i;
                            idxMai = 0;
                        }
                    }
                    else
                    {
                        if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(i + 1)].Y)
                        {
                            ma = verticesAtuais[this.getFace(i)];
                            mi = verticesAtuais[this.getFace(i + 1)];
                            idxMen = i + 1;
                            idxMai = i;
                        }
                        else
                        {
                            ma = verticesAtuais[this.getFace(i + 1)];
                            mi = verticesAtuais[this.getFace(i)];
                            idxMen = i;
                            idxMai = i + 1;
                        }
                    }

                    int idx = (int)mi.Y + cy; // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                              // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo
                    if (idx < 0) idx = 0;
                    else if (idx >= db.Height) idx = db.Height - 1;

                    if (Et[idx] == null)
                        Et[idx] = new List<ET>();

                    double dx = ma.X - mi.X;
                    double dy = ma.Y - mi.Y;
                    double dz = ma.Z - mi.Z;

                    double incx; // Calculo o incremento. isso é para não dar divisão por 0
                    incx = dy == 0 ? 0 : dx / dy;

                    Et[idx].Add(new ET((int)ma.Y + cy, (int)mi.Y + cy, mi.X + cx, incx,
                        cores[idxMen].R, cores[idxMen].G, cores[idxMen].B, mi.Z,
                        (cores[idxMai].R - cores[idxMen].R) / dy, 
                        (cores[idxMai].G - cores[idxMen].G) / dy,
                        (cores[idxMai].B - cores[idxMen].B) / dy, 
                        dy == 0 ? 0 : dz / dy));
                }

                List<ET> AET = new List<ET>();
                i = 0;
                while (Et[i] == null)
                    i++;

                foreach (ET no in Et[i])
                    AET.Add(no);
                do
                {
                    for (int j = AET.Count - 1; j >= 0; j--)
                        if (AET[j].YMax <= i)
                            AET.RemoveAt(j);

                    if (AET.Count > 0)
                    {
                        AET.Sort(new XCompare());

                        for (int j = 0; j < AET.Count; j += 2)
                        {
                            int x1 = (int)AET[j].Xmin1, x2 = (int)AET[j + 1].Xmin1, y = i;
                            double dx = x2 - x1;

                            double incZ = (AET[j + 1].Zmin1 - AET[j].Zmin1) / dx, z = AET[j].Zmin1;
                            double r = AET[j].Rmin1; 
                            double g = AET[j].Gmin1;
                            double b = AET[j].Bmin1;

                            double incR = (AET[j + 1].Rmin1 - AET[j].Rmin1) / dx;
                            double incG = (AET[j + 1].Gmin1 - AET[j].Gmin1) / dx;
                            double incB = (AET[j + 1].Bmin1 - AET[j].Bmin1) / dx;

                            while (x1++ <= x2)
                            {
                                if (y < db.Height && y >= 0 && x1 < db.Width && x1 >= 0 &&
                                     z > zbuffer[x1, y])
                                {
                                    db.SetPixel(x1, y, Color.FromArgb((int)(r > 255 ? 255 : r < 0 ? 0 : r) , (int)(g > 255 ? 255 : g < 0 ? 0 : g), (int)(b > 255 ? 255 : b < 0 ? 0 : b)));
                                    zbuffer[x1, y] = z;
                                }
                                
                                z += incZ;
                                r += incR;
                                g += incG;
                                b += incB;
                            }
                        }

                        foreach (ET e in AET)
                            e.Att();

                        i++;

                        if (i < db.Height && Et[i] != null)
                            foreach (ET no in Et[i])
                                AET.Add(no);
                    }
                } while (AET.Count > 0);
            }
        }

        public void ScanLinePhong(DirectBitmap db, Color cor, List<Vertice> verticesAtuais, double[,] zbuffer, Vetor luz)
        {
            if (calculaNormal(verticesAtuais))
            {
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

                double faixaValores = db.Height;
                List<ET>[] Et = new List<ET>[(int)faixaValores];
                int i;
                double mod = Math.Sqrt(Math.Pow(luz.X, 2) + Math.Pow(luz.Y, 2) + Math.Pow(luz.Z, 2));
                luz.X /= mod; luz.Y /= mod; luz.Z /= mod;

                h.X = luz.X + olho.X;
                h.Y = luz.Y + olho.Y;
                h.Z = luz.Z + olho.Z;
                mod = Math.Sqrt(Math.Pow(h.X, 2) + Math.Pow(h.Y, 2) + Math.Pow(h.Z, 2));
                h.X /= mod;
                h.Y /= mod;
                h.Z /= mod;

                for (i = 0; i < Faces.Count(); i++)
                {
                    Vertice ma, mi;
                    if (i == Faces.Count() - 1)
                    {
                        if (verticesAtuais[this.getFace(i)].Y >= verticesAtuais[this.getFace(0)].Y)
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
                    else
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

                    int idx = (int)mi.Y + cy; // Descubro qual o indice da ET. Para isso, tenho o ponto minimo de todos os vertices.
                                               // Ao fazer o minimo atual - o minomo de todos eu sei a posição, ja que os pontos são negativos e não existe indice negativo
                    if (idx < 0) idx = 0;
                    else if (idx >= db.Height) idx = db.Height - 1;

                    if (Et[idx] == null)
                        Et[idx] = new List<ET>();

                    double dx = ma.X - mi.X;
                    double dy = ma.Y - mi.Y;
                    double dz = ma.Z - mi.Z;

                    double incx; // Calculo o incremento. isso é para não dar divisão por 0
                    incx = dy == 0 ? 0 : dx / dy;

                    Et[idx].Add(new ET((int)ma.Y + cy, (int)mi.Y + cy, mi.X + cx, incx,
                        mi.VetNormal.X, mi.VetNormal.Y, mi.VetNormal.Z, mi.Z,
                        (ma.VetNormal.X - mi.VetNormal.X) / dy,
                        (ma.VetNormal.Y - mi.VetNormal.Y) / dy,
                        (ma.VetNormal.Z - mi.VetNormal.Z) / dy,
                        dy == 0 ? 0 : dz / dy));
                }

                List<ET> AET = new List<ET>();
                i = 0;

                while (Et[i] == null)
                    i++;

                foreach (ET no in Et[i])
                    AET.Add(no);
                do
                {
                    for (int j = AET.Count - 1; j >= 0; j--)
                        if (AET[j].YMax <= i)
                            AET.RemoveAt(j);
                    if (AET.Count > 0)
                    {
                        AET.Sort(new XCompare());

                        for (int j = 0; j < AET.Count; j += 2)
                        {
                            int x1 = (int)AET[j].Xmin1, x2 = (int)AET[j + 1].Xmin1, y = i;
                            double dx = x2 - x1;

                            double incZ = (AET[j + 1].Zmin1 - AET[j].Zmin1) / dx, z = AET[j].Zmin1;
                            double r = AET[j].Rmin1;
                            double g = AET[j].Gmin1;
                            double b = AET[j].Bmin1;

                            double incR = (AET[j + 1].Rmin1 - AET[j].Rmin1) / dx;
                            double incG = (AET[j + 1].Gmin1 - AET[j].Gmin1) / dx;
                            double incB = (AET[j + 1].Bmin1 - AET[j].Bmin1) / dx;

                            while (x1++ <= x2)
                            {
                                if (y < db.Height && y >= 0 && x1 < db.Width && x1 >= 0 &&
                                     z > zbuffer[x1, y])
                                {

                                    dif = luz.X * r + luz.Y * g + luz.Z * b;
                                    esp = Math.Pow(h.X * r + h.Y * g + h.Z * b, n);
                                    cor = Color.FromArgb(
                                        (int)(Math.Abs(l_a.X * k_a.X + l_d.X * k_d.X * dif + l_e.X * k_e.X * esp) * 255),
                                        (int)(Math.Abs(l_a.Y * k_a.Y + l_d.Y * k_d.Y * dif + l_e.Y * k_e.Y * esp) * 255),
                                        (int)(Math.Abs(l_a.Z * k_a.Z + l_d.Z * k_d.Z * dif + l_e.Z * k_e.Z * esp) * 255));


                                    db.SetPixel(x1, y, cor);
                                    zbuffer[x1, y] = z;
                                }

                                z += incZ;
                                r += incR;
                                g += incG;
                                b += incB;
                            }
                        }

                        foreach (ET e in AET)
                            e.Att();

                        i++;

                        if (i < (int)faixaValores && Et[i] != null)
                            foreach (ET no in Et[i])
                                AET.Add(no);
                    }
                } while (AET.Count > 0);
            }
        }

        public class XCompare : IComparer<ET>
        {
            public int Compare(ET x, ET y)
            {
                return x.Xmin1.CompareTo(y.Xmin1);
            }
        }
    }
}
