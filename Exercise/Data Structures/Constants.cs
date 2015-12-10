using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data_Structures
{
    public class Constants
    {
        #region Constants numbers
        public const double Pi = 3.14;
        #endregion
        
        #region Valid shapes
        public const string Circle = "circle";
        public const string Square = "square";
        public const string Rectangle = "rectangle";
        public const string Triangle = "triangle";
        public const string Donut = "donut";
        #endregion

        #region Messages
        public const string BackMenu = "Press enter to return to the main menu...";
        public const string FewArguments = 
            "Error: Input string is not valid, too few arguments. Check Help option to learn more";
        public const string TooArgunments =
            "Error: Input string is not valid, too many arguments. Check Help option to learn more";
        public const string GenericError = "Error procesing the shape. Error message:";
        #endregion
    }

}
