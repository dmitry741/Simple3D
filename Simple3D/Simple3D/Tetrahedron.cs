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

            _list.Add(new Point3D(- 0.5, -s / 4, -Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0.5, -s / 4, -Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0, s / 4, -Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0, -s / 12, Math.Sqrt(6) / 6));

            Name = "Тетраэдр";
        }

        public override List<Edge> Render()
        {
            List<Edge> list = new List<Edge>
            {
                new Edge(_list[0], _list[1]),
                new Edge(_list[1], _list[2]),
                new Edge(_list[2], _list[0]),
                new Edge(_list[0], _list[3]),
                new Edge(_list[1], _list[3]),
                new Edge(_list[2], _list[3])
            };

            return list;
        }
    }
}
