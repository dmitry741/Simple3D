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

        public override List<Edge> Render()
        {
            List<Edge> list = new List<Edge>
            {
                new Edge(_list[0], _list[1]),
                new Edge(_list[1], _list[2]),
                new Edge(_list[2], _list[3]),
                new Edge(_list[3], _list[0]),

                new Edge(_list[4], _list[5]),
                new Edge(_list[5], _list[6]),
                new Edge(_list[6], _list[7]),
                new Edge(_list[7], _list[4]),

                new Edge(_list[0], _list[4]),
                new Edge(_list[1], _list[5]),
                new Edge(_list[2], _list[6]),
                new Edge(_list[3], _list[7])
            };

            return list;
        }
    }
}
