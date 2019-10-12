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
    }
}
