using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Donut :Shape
    {
        public double InnerRadius { get; set; }
        public double OutterRadius { get; set; }
        public override double Area
        {
            get
            {
                //Get the area of the outer circle
                var outerCircle = (Constants.Pi * OutterRadius * OutterRadius);
                //Get the are of the inner circle
                var innerCircle = (Constants.Pi * InnerRadius * InnerRadius);
                //Substrac the area of the inner circle to the ourter circle to get the Donut area
                return outerCircle - innerCircle;
            }
        }
    }
}
