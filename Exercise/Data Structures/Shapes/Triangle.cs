using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Triangle : Shape
    {
        public double X2Value { get; set; }
        public double Y2Value { get; set; }
        public double X3Value { get; set; }
        public double Y3Value { get; set; }
        

        public override double Area
        {
            get
            {
                // formula
                // Calculate determinat with the coordinates
                // 1/2 * determinant
                // calculate determinat of the tringle with the cordinates given
                var valueA = (X1Xvalue * Y2Value) + (X2Value * Y3Value) + (X3Value * Y1Value);
                var valueB = (X3Value * Y2Value) + (X2Value * Y1Value) + (X1Xvalue * Y3Value);
                var dtrm = (valueA - valueB);
                return dtrm/2;
            }
        }
    }
}
