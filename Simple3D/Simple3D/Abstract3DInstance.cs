using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{    
    abstract class Abstract3DInstance
    {
        protected List<Point3D> _list = new List<Point3D>();

        public List<Point3D> Points => _list;

        public  abstract List<Edge> Render();

        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}
