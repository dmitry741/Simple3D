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

            _points.Add(new Point3D(- 0.5, -s / 4, Math.Sqrt(6) / 6));
            _points.Add(new Point3D(0.5, -s / 4, Math.Sqrt(6) / 6));
            _points.Add(new Point3D(0, s / 4, Math.Sqrt(6) / 6));
            _points.Add(new Point3D(0, -s / 12, -Math.Sqrt(6) / 6));

            Name = "Тетраэдр";
        }

        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(_points[0], _points[1]),
                new Edge(_points[1], _points[2]),
                new Edge(_points[2], _points[0]),
                new Edge(_points[0], _points[3]),
                new Edge(_points[1], _points[3]),
                new Edge(_points[2], _points[3])
            };

            Plane plane1, plane2;            

            for (int i = 0; i < 3; i++)
            {
                plane1 = new Plane(_points[1], _points[0], _points[2]);
                plane2 = new Plane(_points[i],_points[(i + 1) % 3], _points[3]);
                edges[i].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);

                plane1 = new Plane(_points[i], _points[3], _points[(i + 2) % 3]);
                plane2 = new Plane(_points[3], _points[i], _points[(i + 1) % 3]);
                edges[i + 3].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);
            }

            return edges;
        }
    }
}
