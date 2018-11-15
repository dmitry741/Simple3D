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
        /// Метод необходим для определения видимости грани.
        /// </summary>
        /// <param name="z">Z координта векторного произведния.</param>
        /// <returns>Видимость грани.</returns>
        protected bool PredicateVisible(double z) => z >= 0;

        /// <summary>
        /// Свойство возвращает список точек.
        /// </summary>
        public List<Point3D> Points => _list;

        /// <summary>
        /// Метод возвращает список ребер для отрисовки.
        /// </summary>
        /// <returns></returns>
        public  abstract IEnumerable<Edge> Render();

        public abstract IEnumerable<Edge> Render(IPerspectiveTransform ipt, Point3D center);

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
