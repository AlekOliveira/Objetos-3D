using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class ET
    {
        private double incX, yMax, xMin;

        public ET(double incX, double yMax, double xMin)
        {
            this.incX = incX;
            this.yMax = yMax;
            this.xMin = xMin;
        }

        public double IncX { get => incX; set => incX = value; }
        public double YMax { get => yMax; set => yMax = value; }
        public double XMin { get => xMin; set => xMin = value; }

    }
}
