using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures.Shapes
{
    public class Square:Shape
    {
        public double Area
        {
            get
	        {
		        return Zvalue * 2; 
	        }
        }
    }
}
