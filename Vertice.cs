namespace Objetos_3D
{
    class Vertice 
    {

        private Vetor vetNormal;
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

        internal Vetor VetNormal { get => vetNormal; set => vetNormal = value; }
    }
}
