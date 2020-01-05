using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Vetor
    {
        private double x, y, z;

        public Vetor(double x, double y, double z)
        {
            this.X = x == 0 ? 0 : x;
            this.Y = y == 0 ? 0 : y;
            this.Z = z == 0 ? 0 : z;
        }

        public Vetor()
        {
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

      


    }
}
