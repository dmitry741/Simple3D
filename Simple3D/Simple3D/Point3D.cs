using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D()
        {
            X = Y = X = 0;
        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
