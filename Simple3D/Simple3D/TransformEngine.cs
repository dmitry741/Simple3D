using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    class TransformEngine : ITransformEngine
    {
        List<Abstract3DInstance> _list = new List<Abstract3DInstance>();

        public void Add(Abstract3DInstance item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public void RotateXZ(double angle, double Xc, double Zc)
        {
            double si = Math.Sin(angle);
            double co = Math.Cos(angle);

            foreach (Abstract3DInstance items in _list)
            {
                foreach (Point3D point in items.Points)
                {
                    double x = co * (point.X - Xc) - si * (point.Z - Zc) + Xc;
                    double z = si * (point.X - Xc) + co * (point.Z - Zc) + Zc;

                    point.X = x;
                    point.Z = z;
                }
            }
        }

        public void RotateYZ(double angle, double Yc, double Zc)
        {
            double si = Math.Sin(angle);
            double co = Math.Cos(angle);

            foreach (Abstract3DInstance items in _list)
            {
                foreach (Point3D point in items.Points)
                {
                    double y = co * (point.Y - Yc) - si * (point.Z - Zc) + Yc;
                    double z = si * (point.Y - Yc) + co * (point.Z - Zc) + Zc;

                    point.X = y;
                    point.Z = z;
                }
            }
        }

        public void Scale(double scaleFactor, double Xc, double Yc, double Zc)
        {
            foreach (Abstract3DInstance items in _list)
            {
                foreach (Point3D point in items.Points)
                {
                    point.X = scaleFactor * (point.X - Xc) + Xc;
                    point.Y = scaleFactor * (point.Y - Yc) + Yc;
                    point.Z = scaleFactor * (point.Z - Zc) + Zc;
                }
            }
        }

        public void Translate(double X, double Y, double Z)
        {
            foreach(Abstract3DInstance items in _list)
            {
                foreach(Point3D point in items.Points)
                {
                    point.X += X;
                    point.Y += Y;
                    point.Z += Z;
                }
            }
        }
    }
}
