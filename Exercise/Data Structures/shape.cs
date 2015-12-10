using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures
{
    public class Shape
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double X1Xvalue { get; set; }
        public double Y1Value { get; set; }
        public virtual double Area { get; set; }
    }
}
