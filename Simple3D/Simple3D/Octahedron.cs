using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Октаэдр
    /// </summary>
    class Octahedron : Abstract3DInstance
    {
        public Octahedron()
        {
            double s = Math.Sqrt(2) / 2;

            _list.Add(new Point3D(s, 0, 0));
            _list.Add(new Point3D(0, s, 0));
            _list.Add(new Point3D(-s, 0, 0));
            _list.Add(new Point3D(0, -s, 0));

            _list.Add(new Point3D(0, 0, s));
            _list.Add(new Point3D(0, 0, -s));
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

            return edges;
        }
    }
}
