using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{    
    /// <summary>
    /// Абстрактный класс для 3D объекта.
    /// </summary>
    abstract class Abstract3DInstance
    {
        protected List<Point3D> _list = new List<Point3D>();

        /// <summary>
        /// Свойство возвращает список точек.
        /// </summary>
        public List<Point3D> Points => _list;

        /// <summary>
        /// Метод возвращает список ребер для отрисовки.
        /// </summary>
        /// <returns></returns>
        public  abstract List<Edge> Render();

        /// <summary>
        /// Имя объекта.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}
