using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_3D
{
    class ET
    {
        private double yMax, Xmin, IncX, Rmin, Gmin, Bmin, Zmin, IncR, IncG, IncB, IncZ;

        public ET(double yMax, double xmin, double rmin, double gmin, double bmin, double zmin)
        {
            this.yMax = yMax;
            this.Xmin = xmin;
            this.Rmin = rmin;
            this.Gmin = gmin;
            this.Bmin = bmin;
            this.Zmin = zmin;
            //this.IncR = incR;
            //this.IncG = incG;
            //this.IncB = incB;
           // this.IncZ = incZ;
            //this.IncX = incX;
        }

        public ET()
        {
            
        }

        public double YMax { get => yMax; set => yMax = value; }
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
    }
}
