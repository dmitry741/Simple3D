using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Куб
    /// </summary>
    class Cube : Abstract3DInstance
    {
        /// <summary>
        /// создаем куб с ребром равным 1 с центром в начале координат.
        /// </summary>
        public Cube()
        {
            double s = Math.Sqrt(2) / 2;

            _list.Add(new Point3D(0, s, s / 2));
            _list.Add(new Point3D(s, 0, s / 2));
            _list.Add(new Point3D(0, -s, s / 2));
            _list.Add(new Point3D(-s, 0, s / 2));

            _list.Add(new Point3D(0, s, -s / 2));
            _list.Add(new Point3D(s, 0, -s / 2));
            _list.Add(new Point3D(0, -s, -s / 2));
            _list.Add(new Point3D(-s, 0, -s / 2));
        }
    }
}
