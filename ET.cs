using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class ET
    {
        private double yMax, yMin, Xmin, IncX, Rmin, Gmin, Bmin, Zmin, IncR, IncG, IncB, IncZ;

        public ET(double yMax, double yMin, double xmin, double incX, double rmin, double gmin, double bmin, double zmin, double incR, double incG, double incB, double incZ)
        {
            this.YMax = yMax;
            this.YMin = yMin;
            Xmin1 = xmin;
            IncX1 = incX;
            Rmin1 = rmin;
            Gmin1 = gmin;
            Bmin1 = bmin;
            Zmin1 = zmin;
            IncR1 = incR;
            IncG1 = incG;
            IncB1 = incB;
            IncZ1 = incZ;
        }

        public double YMax { get => yMax; set => yMax = value; }
        public double YMin { get => yMin; set => yMin = value; }
        public double Xmin1 { get => Xmin; set => Xmin = value; }
        public double IncX1 { get => IncX; set => IncX = value; }
        public double Rmin1 { get => Rmin; set => Rmin = value; }
        public double Gmin1 { get => Gmin; set => Gmin = value; }
        public double Bmin1 { get => Bmin; set => Bmin = value; }
        public double Zmin1 { get => Zmin; set => Zmin = value; }
        public double IncR1 { get => IncR; set => IncR = value; }
        public double IncG1 { get => IncG; set => IncG = value; }
        public double IncB1 { get => IncB; set => IncB = value; }
        public double IncZ1 { get => IncZ; set => IncZ = value; }

        public void Att()
        {
            Xmin += IncX;
            Zmin += IncZ;
            Rmin += IncR;
            Gmin += IncG;
            Bmin += IncB;
        }
    }
}
