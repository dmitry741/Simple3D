using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Куб.
    /// </summary>
    class Cube : Abstract3DInstance
    {
        /// <summary>
        /// создаем куб с ребром равным 1 с центром в начале координат.
        /// </summary>
        public Cube()
        {
            double s = Math.Sqrt(2) / 2;

            _list.Add(new Point3D(0, s, 0.5));
            _list.Add(new Point3D(s, 0, 0.5));
            _list.Add(new Point3D(0, -s, 0.5));
            _list.Add(new Point3D(-s, 0, 0.5));

            _list.Add(new Point3D(0, s, -0.5));
            _list.Add(new Point3D(s, 0, -0.5));
            _list.Add(new Point3D(0, -s, -0.5));
            _list.Add(new Point3D(-s, 0, -0.5));

            Name = "Куб";
        }

        /// <summary>
        /// Метод возвращает список ребер для отображения.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
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

            Plane plane1, plane2;

            for (int i = 0; i < 4; i++)
            {
                plane1 = new Plane(_list[i], _list[(i + 1) % 4], _list[(i + 2) % 4]);
                plane2 = new Plane(_list[(i + 1) % 4], _list[i], _list[(i + 5) % 4 + 4]);
                edges[i].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);

                plane1 = new Plane(_list[(i + 5) % 4 + 4], _list[(i + 4) % 4 + 4], _list[(i + 6) % 4 + 4]);
                plane2 = new Plane(_list[(i + 4) % 4 + 4], _list[(i + 5) % 4 + 4], _list[i]);
                edges[i + 4].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);

                plane1 = new Plane(_list[i], _list[i + 4], _list[(i + 5) % 8]);
                plane2 = new Plane(_list[i + 4], _list[i], _list[(i + 7) % 8]);
                edges[i + 8].Visible = PredicateVisible(plane1.Z) || PredicateVisible(plane2.Z);
            }

            return edges;
        }        
    }
}
