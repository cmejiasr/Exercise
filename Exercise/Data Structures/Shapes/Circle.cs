using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Circle : Shape
    {
        public double Area
        {
            get 
            {
                return (Constants.Pi * Zvalue * Zvalue); //this is the equation for the area of a circle
            }
        }
    }
}
