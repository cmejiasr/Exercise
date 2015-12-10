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
        public List<Shape> Shapes { get; set; }
        public string ErrorMessage { get; set; }
    }
}
