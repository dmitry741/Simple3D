using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Октаэдр.
    /// </summary>
    class Octahedron : Abstract3DInstance
    {
        /// <summary>
        /// Создаем октаэдр в центре с началом координат и ребром равным 1.
        /// </summary>
        public Octahedron()
        {
            double s = Math.Sqrt(2) / 2;

            _list.Add(new Point3D(s, 0, 0));
            _list.Add(new Point3D(0, s, 0));
            _list.Add(new Point3D(-s, 0, 0));
            _list.Add(new Point3D(0, -s, 0));

            _list.Add(new Point3D(0, 0, s));
            _list.Add(new Point3D(0, 0, -s));

            Name = "Октаэдр";
        }

        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(_list[0], _list[1]),
                new Edge(_list[1], _list[2]),
                new Edge(_list[2], _list[3]),
                new Edge(_list[3], _list[0]),

                new Edge(_list[4], _list[0]),
                new Edge(_list[4], _list[1]),
                new Edge(_list[4], _list[2]),
                new Edge(_list[4], _list[3]),

                new Edge(_list[5], _list[0]),
                new Edge(_list[5], _list[1]),
                new Edge(_list[5], _list[2]),
                new Edge(_list[5], _list[3])
            };

            Plane plane1, plane2;

            for (int i = 0; i < 4; i++)
            {
                plane1 = new Plane(_list[(i + 1) % 4], _list[i], _list[4]);
                plane2 = new Plane(_list[i], _list[(i + 1) % 4], _list[5]);
                edges[i].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);

                plane1 = new Plane(_list[i], _list[4], _list[(i + 1) % 4]);
                plane2 = new Plane(_list[4], _list[i], _list[(i + 3) % 4]);
                edges[i + 4].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);

                plane1 = new Plane(_list[5], _list[i], _list[(i + 1) % 4]);
                plane2 = new Plane(_list[i], _list[5], _list[(i + 3) % 4]);
                edges[i + 8].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);
            }

            return edges;
        }
    }
}
