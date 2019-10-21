using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class Vertice 
    {
        /* private int x, y, z;

         public Vertice(int x, int y, int z)
         {
             this.X = x;
             this.Y = y;
             this.Z = z;
         }

         public Vertice(){}

         public int X { get => x; set => x = value; }
         public int Y { get => y; set => y = value; }
         public int Z { get => z; set => z = value; }*/

        private double x, y, z;

        public Vertice(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vertice() { }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
    }
}
