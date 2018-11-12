using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    class TransformEngine
    {
        static public void RotateXZ(Abstract3DInstance item, double angle, double Xc, double Zc)
        {
            double si = Math.Sin(angle);
            double co = Math.Cos(angle);

            foreach (Point3D point in item.Points)
            {
                double x = co * (point.X - Xc) - si * (point.Z - Zc) + Xc;
                double z = si * (point.X - Xc) + co * (point.Z - Zc) + Zc;

                point.X = x;
                point.Z = z;
            }
        }

        static public void RotateYZ(Abstract3DInstance item, double angle, double Yc, double Zc)
        {
            double si = Math.Sin(angle);
            double co = Math.Cos(angle);

            foreach (Point3D point in item.Points)
            {
                double y = co * (point.Y - Yc) - si * (point.Z - Zc) + Yc;
                double z = si * (point.Y - Yc) + co * (point.Z - Zc) + Zc;

                point.Y = y;
                point.Z = z;
            }
        }

        static public void Scale(Abstract3DInstance item, double scaleFactor, double Xc, double Yc, double Zc)
        {
            foreach (Point3D point in item.Points)
            {
                point.X = scaleFactor * (point.X - Xc) + Xc;
                point.Y = scaleFactor * (point.Y - Yc) + Yc;
                point.Z = scaleFactor * (point.Z - Zc) + Zc;
            }
        }

        static public void Translate(Abstract3DInstance item, double X, double Y, double Z)
        {
            foreach(Point3D point in item.Points)
            {
                point.X += X;
                point.Y += Y;
                point.Z += Z;
            }
        }
    }
}
