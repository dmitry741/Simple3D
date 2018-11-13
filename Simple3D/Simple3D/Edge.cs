using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Класс ребра 3D объекта.
    /// </summary>
    class Edge
    {
        Point3D _point1 = null;
        Point3D _point2 = null;

        public Edge(Point3D point1, Point3D point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public Point3D point1 => _point1;
        public Point3D point2 => _point2;

        public bool Visible => true;
    }
}
