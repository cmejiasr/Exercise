using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data_Structures.Shapes;

namespace Exercise.Data_Structures
{
    public class ShapeStorage
    {
        public List<Circle> Circles { get; set; }
        public List<Square> Squares { get; set; }
        public List<Rectangle> Rectangles { get; set; }
        public List<Triangle> Triangles { get; set; }
        public List<Donut> Donuts { get; set; }
    }
}
