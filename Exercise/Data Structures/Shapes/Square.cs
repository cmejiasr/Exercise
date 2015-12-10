using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Square:Shape
    {
        public double SideValue { get; set; }
        public double Area
        {
            get
	        {
		        return SideValue * 2; 
	        }
        }
    }
}
