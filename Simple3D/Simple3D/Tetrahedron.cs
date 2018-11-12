using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Тетраэдр
    /// </summary>
    class Tetrahedron : Abstract3DInstance
    {
        /// <summary>
        /// создаем тетраэдр с ребром равным 1 с центром в начале координат.
        /// </summary>
        public Tetrahedron()
        {
            double s = Math.Sqrt(3);

            _list.Add(new Point3D(-0.5, -s / 6, -s / 6));
            _list.Add(new Point3D(0, s / 2 - s / 6, -s / 6));
            _list.Add(new Point3D(0.5, -s / 6, - s / 6));
            _list.Add(new Point3D(0, 0, 1 / s - s / 6));
        }
    }
}
