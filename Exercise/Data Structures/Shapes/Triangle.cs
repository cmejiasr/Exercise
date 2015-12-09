using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Triangle : Shape
    {
        public double Vertice1 { get; set; }
        public double Vertice2 { get; set; }
        public double Vertice3 { get; set; }

        public double Area
        {
            get
            {
                /*formula
                * Calculate determinat with the coordinates
                * 1/2 * determinant
                 *            (x1,y1)
                 *              /\
                 *             /  \
                 *            /____\
                 *        (x2,y2) (x3,y3)
                */
                //calculate determinat of the tringle with the cordinates given
                var x1 = Xvalue;
                var y1 = Yvalue;
                var x2 = Zvalue;
                var y2 = Vertice1;
                var x3 = Vertice2;
                var y3 = Vertice3;
                var valueA = (x1*y2) + (x2*y3) + (x3*y1);
                var valueB = (x3*y2) + (x2*y1) + (x1*y3);
                var dtrm = (valueA - valueB);
                return dtrm/2;
            }
        }
    }
}
