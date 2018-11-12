using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    interface ITransformEngine
    {
        void Add(Abstract3DInstance item);
        void Clear();
        void Translate(double X, double Y, double Z);
        void RotateXZ(double angle, double Xc, double Zc);
        void RotateYZ(double angle, double Yc, double Zc);
        void Scale(double scaleFactor, double Xc, double Yc, double Zc);
    }
}
