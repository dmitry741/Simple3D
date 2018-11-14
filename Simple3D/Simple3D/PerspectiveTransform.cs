using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Класс выполяющий перспективные преобразования.
    /// </summary>
    class PerspectiveTransform
    {
        /// <summary>
        /// Метод выполняет перспективное преобразование
        /// </summary>
        /// <param name="point">Исходная точка.</param>
        /// <param name="center">Ценрт перспективы.</param>
        /// <returns>Point3D объект.</returns>
        static public Point3D Transform(Point3D point, Point3D center)
        {
            double X = center.Z / (center.Z - point.Z) * (point.X - center.X) + center.X;
            double Y = center.Z / (center.Z - point.Z) * (point.Y - center.Y) + center.Y;

            return new Point3D(X, Y, point.Z);
        }
    }
}
