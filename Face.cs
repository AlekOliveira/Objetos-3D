using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Face
    {
        private int[] Faces = new int[3];       

        public Face(int a, int b, int c)
        {
            Faces[0] = a;
            Faces[1] = b;
            Faces[2] = c;
        }

        public int Idx0 { get => Faces[0] -1; set => Faces[0] = value; }
        public int Idx1 { get => Faces[1] -1; set => Faces[1] = value; }
        public int Idx2 { get => Faces[2] -1; set => Faces[2] = value; }  


        public bool calculaNormal(List<Vertice> Vertices)
        {
            Vetor AB = new Vetor(Vertices[Idx1].X - Vertices[this.Idx0].X, Vertices[Idx1].Y - Vertices[this.Idx0].Y, Vertices[Idx1].Z - Vertices[this.Idx0].Z);
            Vetor AC = new Vetor(Vertices[Idx2].X - Vertices[this.Idx0].X, Vertices[Idx2].Y - Vertices[this.Idx0].Y, Vertices[Idx2].Z - Vertices[this.Idx0].Z);
            Vetor VN = new Vetor();

            VN.X = AB.Y * AC.Z - AB.Z * AC.Y;
            VN.Y = AB.Z * AC.X - AB.X * AC.Z;
            VN.Z = AB.X * AC.Y - AB.Y * AC.X;

            double moduloVN = (Math.Pow(VN.X, 2) + Math.Pow(VN.Y, 2) + Math.Pow(VN.Z, 2));
            VN.X /= moduloVN;
            VN.Y /= moduloVN;
            VN.Z /= moduloVN;

            if (VN.Z >= 0)
                return true;
            return false;
        }
    }
}
