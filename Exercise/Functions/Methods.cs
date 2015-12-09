using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Exercise.Data_Structures;
using Exercise.Data_Structures.Shapes;

namespace Exercise.Functions
{
    class Methods
    {

        public List<Shape> Shapes;
        public List<Circle> Circles;
        public List<Square> Squares;
        public List<Triangle> Triangles;
        public List<Rectangle> Rectangles;
        public List<Donut> Donuts; 


        static bool IsDouble(string number)
        {
            double value;
            return (double.TryParse(number, out value));
        }

        static string ValidateParams(string[] paramsStrings, int numberOfParams) //NUmber of params + name of the shape
        {
            var result="";

            if (paramsStrings.Length == numberOfParams)
            {
                for (var i = 1; i < numberOfParams; i++)
                {
                    if (IsDouble(paramsStrings[i])) continue;
                    result = string.Format("Problems with the arguments. Argument in position:{1} is not a valid number",
                        paramsStrings[0], i.ToString());
                    break;
                }
            }
            else if (paramsStrings.Length > numberOfParams)
            {
                result = "Error: Input string is not valid, too many arguments. Check Help option to learn more";
            }
            else
            {
                result = "There is a problem with the arguments, Check Help to learn the valid shapes and its valid values";
            }
            return result;
        }

        public string ValidateShape(string parameters)
        {
            var paramList = parameters.Split(' ');
            if (paramList.Length <= 3) 
                return "Error: Input string is not valid, too few arguments. Check Help option to learn more";
            string operationResult;
            var type = paramList[0].ToLower();
            switch (type)
            {
                case Constants.Circle:
                case Constants.Square:
                    operationResult = ValidateParams(paramList, 4);
                    break;
                case Constants.Rectangle:
                case Constants.Donut:
                    operationResult = ValidateParams(paramList, 5);
                    break;
             
                case Constants.Triangle:
                    operationResult = ValidateParams(paramList, 7);
                    break;
                default:
                    operationResult = string.Format( "{0} is not valid shape",paramList[0]);
                    break;
            }
            if (operationResult == "")
            {
                operationResult = InsertShape(paramList);
            }
            return operationResult;
        }

        public string InsertShape(string[] data)
        {
            try
            {

                var count = Shapes.Count + 1;
                var insertResult = "";
                switch (data[0].ToLower())
                {
                    case Constants.Circle:
                        var circle = new Circle()
                        {
                            Id = count,
                            Name = data[0],
                            Xvalue = double.Parse(data[1]),
                            Yvalue = double.Parse(data[2]),
                            Zvalue = double.Parse(data[3])
                        };

                        if(Circles==null)
                            Circles = new List<Circle>();
                        Circles.Add(circle);
                        insertResult = string.Format("=> shape {0}: Circle with centre at ({1},{2}) and radius {3}", count.ToString(),
                        data[1], data[2], data[3]);
                        break;

                    case Constants.Square:
                        var square = new Square()
                        {
                            Id = count,
                            Name = data[0],
                            Xvalue = double.Parse(data[1]),
                            Yvalue = double.Parse(data[2]),
                            Zvalue = double.Parse(data[3])
                        };

                        if(Squares == null)
                            Squares = new List<Square>();
                        Squares.Add(square);
                        insertResult = string.Format("=> shape {0}: Square with corner at ({1},{2}) and side's length {3}", count.ToString(),
                        data[1], data[2], data[3]);
                        break;

                    case Constants.Rectangle:
                        var rectangle = new Rectangle()
                        {
                            Id = count,
                            Name = data[0],
                            Xvalue = double.Parse(data[1]),
                            Yvalue = double.Parse(data[2]),
                            Zvalue = double.Parse(data[3]),
                            SideValue = double.Parse(data[4])
                        };

                        if(Rectangles == null)
                            Rectangles = new List<Rectangle>();
                        Rectangles.Add(rectangle);
                        insertResult = string.Format("=> shape {0}: Rectangle with corner at ({1},{2}), side 1 length {3} and side 2 length {4} ", count.ToString(),
                        data[1], data[2], data[3], data[4]);
                        break;

                    case Constants.Triangle:
                        var triangle = new Triangle()
                        {
                            Id = count,
                            Name = data[0],
                            Xvalue = double.Parse(data[1]),
                            Yvalue = double.Parse(data[2]),
                            Zvalue = double.Parse(data[3]),
                            Vertice1 = double.Parse(data[4]),
                            Vertice2 = double.Parse(data[5]),
                            Vertice3 = double.Parse(data[6]),

                        };

                        if(Triangles ==null)
                            Triangles = new List<Triangle>();
                        Triangles.Add(triangle);
                        insertResult = string.Format("=> shape {0}: triangle with vertices at ({1},{2})({3},{4})({5},{6})", count.ToString(),
                        data[1], data[2], data[3], data[4], data[5], data[6]);
                        break;

                    case Constants.Donut:
                        var donut = new Donut()
                        {
                            Id = count,
                            Name = data[0],
                            Xvalue = double.Parse(data[1]),
                            Yvalue = double.Parse(data[2]),
                            Zvalue = double.Parse(data[3]),
                            SecondRadius = double.Parse(data[4])
                        };

                        if(Donuts == null)
                            Donuts = new List<Donut>();
                        Donuts.Add(donut);
                        insertResult = string.Format("=> shape {0}: Donut with centre at ({1},{2}) and two radiuse: radio 1={3}, radio 2={4}", count.ToString(),
                        data[1], data[2], data[3], data[4]);
                        break;
                }
                return insertResult;
            }
            catch (Exception ex)
            {
                
                return string.Format("The shape could be saved. Error message {0}", ex.Message);
            }
        }


        #region Check if a given (x,y) is part of the inserted shapes

        public List<Circle> PointInCircle(double x, double y)
        {
            return (from circle in Circles 
                    let isValidPoint = Math.Sqrt(Math.Pow((circle.Xvalue - x), 2) + Math.Pow((circle.Yvalue - y), 2)) 
                    where isValidPoint <= circle.Zvalue 
                    select circle).ToList();
        }

        #endregion


    }
}
