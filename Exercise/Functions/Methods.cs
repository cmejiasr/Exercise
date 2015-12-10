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
    internal class Methods
    {
        List<Circle> _circles;
        List<Square> _squares;
        List<Triangle> _triangles;
        List<Rectangle> _rectangles;
        List<Donut> _donuts;


        private static bool IsDouble(string number)
        {
            double value;
            return (double.TryParse(number, out value));
        }

        private static string ValidateParams(string[] paramsStrings, int numberOfParams)//NUmber of params + name of the shape
        {
            try
            {
                var result = "";

                if (paramsStrings.Length == numberOfParams)
                {
                    for (var i = 1; i < numberOfParams; i++)
                    {
                        if (IsDouble(paramsStrings[i])) continue;
                        result = string.Format(
                            "Problems inserting Shape {0}. Argument in position {1} is not a valid number",
                            paramsStrings[0], i.ToString());
                        break;
                    }
                }
                else if (paramsStrings.Length > numberOfParams)
                {
                    result = Constants.TooArgunments;
                }
                else
                {
                    result =
                        "There is a problem with the arguments, Check Help to learn the valid shapes and its valid values";
                }
                return result;
            }
            catch (Exception)
            {
                
                return "";
            }
        }

        public string ValidateShape(string parameters)
        {

            try
            {
                var paramList = parameters.Split(' ');
                if (paramList.Length <= 3)
                    return Constants.FewArguments;
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
                        operationResult = string.Format("{0} is not valid shape", paramList[0]);
                        break;
                }
                if (operationResult == "")
                {
                    operationResult = InsertShape(paramList);
                }
                return operationResult;
            }
            catch (Exception exception)
            {

                return string.Format("{0}{1}",Constants.GenericError, exception.Message);
            }
        }

        public string InsertShape(string[] data)
        {
            try
            {
                var insertResult = "";
                string id;
                switch (data[0].ToLower())
                {
                    case Constants.Circle:
                        if (_circles == null)
                            _circles = new List<Circle>();
                        id = Constants.Circle+"-" + (_circles.Count+1);
                       
                        var circle = new Circle()
                        {
                            Id = id,
                            Name = data[0],
                            X1Xvalue = double.Parse(data[1]),
                            Y1Value = double.Parse(data[2]),
                            Radius = double.Parse(data[3])
                        };

                        
                        _circles.Add(circle);
                        insertResult = string.Format("=> shape {0}: Circle with centre at ({1},{2}) and radius {3}",
                            id,
                            data[1], data[2], data[3]);
                        break;

                    case Constants.Square:
                        if (_squares == null)
                            _squares = new List<Square>();
                        id = Constants.Square + "-" + (_squares.Count + 1);
                        var square = new Square()
                        {
                            Id = id,
                            Name = data[0],
                            X1Xvalue = double.Parse(data[1]),
                            Y1Value = double.Parse(data[2]),
                            SideValue = double.Parse(data[3])
                        };

                        
                        _squares.Add(square);
                        insertResult =
                            string.Format("=> shape {0}: Square with corner at ({1},{2}) and side's length {3}",
                                id,
                                data[1], data[2], data[3]);
                        break;

                    case Constants.Rectangle:
                        if (_rectangles == null)
                            _rectangles = new List<Rectangle>();
                        id = Constants.Rectangle + (_rectangles.Count + 1);
                        var rectangle = new Rectangle()
                        {
                            Id = id,
                            Name = data[0],
                            X1Xvalue = double.Parse(data[1]),
                            Y1Value = double.Parse(data[2]),
                            Side1Value = double.Parse(data[3]),
                            Side2Value = double.Parse(data[4])
                        };

                        
                        _rectangles.Add(rectangle);
                        insertResult =
                            string.Format(
                                "=> shape {0}: Rectangle with corner at ({1},{2}), side 1 length {3} and side 2 length {4} ",
                                id,
                                data[1], data[2], data[3], data[4]);
                        break;

                    case Constants.Triangle:
                        if (_triangles == null)
                            _triangles = new List<Triangle>();
                        id = Constants.Triangle + (_triangles.Count + 1);
                        var triangle = new Triangle()
                        {
                            Id = id,
                            Name = data[0],
                            X1Xvalue = double.Parse(data[1]),
                            Y1Value = double.Parse(data[2]),
                            X2Value = double.Parse(data[3]),
                            Y2Value = double.Parse(data[4]),
                            X3Value = double.Parse(data[5]),
                            Y3Value = double.Parse(data[6]),

                        };

                        _triangles.Add(triangle);
                        insertResult =
                            string.Format("=> shape {0}: triangle with vertices at ({1},{2})({3},{4})({5},{6})",
                                id,
                                data[1], data[2], data[3], data[4], data[5], data[6]);
                        break;

                    case Constants.Donut:
                        if (_donuts == null)
                            _donuts = new List<Donut>();
                        id = Constants.Donut + (_donuts.Count + 1);
                        var donut = new Donut()
                        {
                            Id = id,
                            Name = data[0],
                            X1Xvalue = double.Parse(data[1]),
                            Y1Value = double.Parse(data[2]),
                            InnerRadius = double.Parse(data[3]),
                            OutterRadius = double.Parse(data[4])
                        };

                        
                        _donuts.Add(donut);
                        insertResult =
                            string.Format(
                                "=> shape {0}: Donut with centre at ({1},{2}) and two radiuse: radio 1={3}, radio 2={4}",
                                id,
                                data[1], data[2], data[3], data[4]);
                        break;
                }
                return insertResult;
            }
            catch (Exception ex)
            {

                return string.Format("The shape couldn't be saved. Error message {0}", ex.Message);
            }
        }


        #region Check if a given (x,y) is part of the inserted shapes

        public ShapeStorage ShapesList(string point)
        {
            var storage = new ShapeStorage();
            try
            {
                var splitPoint = point.Split(' ');
                double x = 0;
                double y = 0;
                var validParameters = false;
                if (splitPoint.Length > 2)
                {
                    storage.ErrorMessage += string.Format("{0}\n", Constants.TooArgunments);
                }
                else if (splitPoint.Length < 1)
                {
                    storage.ErrorMessage += string.Format("{0}\n", Constants.FewArguments);
                }
                else
                {
                    if (splitPoint[0] == "" || splitPoint[1] == "")
                    {
                        storage.ErrorMessage += "Please check the arguments and try again\n";
                    }
                    else
                    {
                        if (!IsDouble(splitPoint[0]))
                        {
                            storage.ErrorMessage +=
                                string.Format("Argument '{0}' is not valid, Please check it and try again\n",
                                    splitPoint[0]);
                        }
                        if (!IsDouble(splitPoint[1]))
                        {
                            storage.ErrorMessage +=
                                string.Format("Argument '{0}' is not valid, Please check it and try again\n",
                                    splitPoint[1]);
                        }
                        else
                        {
                            x = double.Parse(splitPoint[0]);
                            y = double.Parse(splitPoint[1]);
                            validParameters = true;
                        }

                    }
                }

                if (validParameters)
                {

                    storage.Shapes = new List<Shape>();
                    var crcls = PointInCircle(x, y);
                    var sqrs = PointInSquares(x, y);
                    var trngls = PointInTriangles(x, y);
                    var dnts = PointInDonuts(x, y);
                    if (crcls != null)
                    {
                        storage.Shapes.AddRange(crcls);
                    }

                    if (sqrs != null)
                    {
                        storage.Shapes.AddRange(sqrs);
                    }

                    if (trngls != null)
                    {
                        storage.Shapes.AddRange(trngls);
                    }
                    if (dnts != null)
                    {
                        storage.Shapes.AddRange(dnts);
                    }
                }


            }
            catch (Exception exception)
            {

                storage.ErrorMessage = exception.Message;
            }
            
            return storage;
            
        }

        public List<Circle> PointInCircle(double x, double y)
        {
            if (_circles != null)
            {
                return (from circle in _circles
                    let isValidPoint = Math.Sqrt(Math.Pow((circle.X1Xvalue - x), 2) + Math.Pow((circle.Y1Value - y), 2))
                    where isValidPoint <= circle.Radius
                    select circle).ToList();
            }
            return null;
        }

        public List<Donut> PointInDonuts(double y, double x)
        {

            if (_donuts != null)
            {
                return (from donut in _donuts
                        let isvalidaPoint = Math.Sqrt(Math.Pow((donut.X1Xvalue - x), 2) + Math.Pow((donut.Y1Value - y), 2))
                        where !(isvalidaPoint < donut.InnerRadius || isvalidaPoint > donut.OutterRadius)
                        select donut).ToList(); 
            }
            return null;
        }


        internal List<Square> PointInSquares(double x, double y)
        {
            return _squares.Where(sqr => (sqr.X1Xvalue <= x)
                && (x <= sqr.X1Xvalue + sqr.SideValue) 
                && (sqr.Y1Value <= y) 
                && (y <= sqr.Y1Value + sqr.SideValue))
                .ToList();
        }

        List<Triangle> PointInTriangles(double x, double y)
        {

            if (_triangles != null)
            {
                return (from trn in _triangles
                    let asX = x - trn.X1Xvalue
                    let asY = y - trn.Y1Value
                    let sAb = (trn.X2Value - trn.X1Xvalue)*asY - (trn.Y2Value - trn.Y1Value)*asX > 0
                    where (trn.X3Value - trn.X1Xvalue)*asY - (trn.Y3Value - trn.Y1Value)*asX > 0 != sAb
                    where
                        (trn.Y2Value - trn.X2Value)*(y - trn.Y2Value) - (trn.Y3Value - trn.Y2Value)*(x - trn.X2Value) >
                        0 == sAb
                    select trn).ToList();
            }
            return null;
        }

        #endregion

        public string DeleteShape(string id)
        {
            try
            {
                var splitId = id.Split('-');
                switch (splitId[0])
                {
                    case Constants.Circle:
                        _circles.RemoveAll(x => x.Id == id);
                        break;
                    case Constants.Square:
                        _squares.RemoveAll(x => x.Id == id);
                        break;
                    case Constants.Triangle:
                        _triangles.RemoveAll(x => x.Id == id);
                        break;
                    case Constants.Rectangle:
                        _rectangles.RemoveAll(x => x.Id == id);
                        break;
                    case Constants.Donut:
                        _donuts.RemoveAll(x => x.Id == id);
                        break;
                }
                return string.Format("Shape with ID:{0} was removed succesfully",id);
            }
            catch (Exception exception)
            {
                return string.Format("Error deleting the shape: {0}. Error message: {1}", id, exception.Message);
            }
        }
    }
}

