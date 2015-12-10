using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Rectangle:Shape
    {
        public double Side1Value { get; set; }
        public double Side2Value { get; set; }
        public override double Area
        {
            get
            {
                return Side1Value*Side2Value;
            }
        }
    }

}
