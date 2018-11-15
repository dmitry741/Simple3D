using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Тетраэдр.
    /// </summary>
    class Tetrahedron : Abstract3DInstance
    {
        /// <summary>
        /// создаем тетраэдр с ребром равным 1 с центром в начале координат.
        /// </summary>
        public Tetrahedron()
        {
            double s = Math.Sqrt(3);

            _list.Add(new Point3D(- 0.5, -s / 4, Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0.5, -s / 4, Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0, s / 4, Math.Sqrt(6) / 6));
            _list.Add(new Point3D(0, -s / 12, -Math.Sqrt(6) / 6));

            Name = "Тетраэдр";
        }

        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(_list[0], _list[1]),
                new Edge(_list[1], _list[2]),
                new Edge(_list[2], _list[0]),
                new Edge(_list[0], _list[3]),
                new Edge(_list[1], _list[3]),
                new Edge(_list[2], _list[3])
            };

            Plane plane1, plane2;            

            for (int i = 0; i < 3; i++)
            {
                plane1 = new Plane(_list[1], _list[0], _list[2]);
                plane2 = new Plane(_list[i],_list[(i + 1) % 3], _list[3]);
                edges[i].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);

                plane1 = new Plane(_list[i], _list[3], _list[(i + 2) % 3]);
                plane2 = new Plane(_list[3], _list[i], _list[(i + 1) % 3]);
                edges[i + 3].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);
            }

            return edges;
        }
    }
}
