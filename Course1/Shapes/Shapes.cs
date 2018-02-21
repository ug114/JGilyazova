using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Shapes
    {
        interface Shape
        {
            double getWidth();
            double getHeight();
            double getArea();
            double getPerimeter();
        }

        class Square : Shape
        {
            private double lengthOfSide;

            public Square(double lengthOfSide)
            {
                this.lengthOfSide = lengthOfSide;
            }

            public double getWidth()
            {
                return this.lengthOfSide;
            }

            public double getHeight()
            {
                return this.lengthOfSide;
            }

            public double getArea()
            {
                return this.lengthOfSide * this.lengthOfSide;
            }

            public double getPerimeter()
            {
                return this.lengthOfSide * 4;
            }
        }

        class Triangle : Shape
        {
            private double x1, x2, x3, y1, y2, y3;

            public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
            {
                this.x1 = x1;
                this.x2 = x2;
                this.x3 = x3;
                this.y1 = y1;
                this.y2 = y2;
                this.y3 = y3;
            }

            public double getWidth()
            {
                return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
            }

            public double getHeight()
            {
                return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
            }

            public double getArea()
            {
                double eps = 1e-10;

                if (Math.Abs((x3 - x1) * (y2 - y1) - (y3 - y1) * (x2 - x1)) < eps)
                {
                    return 0;
                }
                else
                {
                    double a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                    double b = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                    double c = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                    double p = (a + b + c) / 2;
                    return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                }
            }

            public double getPerimeter()
            {
                double a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                double b = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                double c = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                return a + b + c;
            }
        }

        class Rectangle : Shape
        {
            private double lengthOfFirstSide;
            private double lengthOfSecondSide;

            public Rectangle(double lengthOfFirstSide, double lengthOfSecondSide)
            {
                this.lengthOfFirstSide = lengthOfFirstSide;
                this.lengthOfSecondSide = lengthOfSecondSide;
            }

            public double getWidth()
            {
                return Math.Max(this.lengthOfFirstSide, this.lengthOfSecondSide);
            }

            public double getHeight()
            {
                return Math.Min(this.lengthOfFirstSide, this.lengthOfSecondSide);
            }

            public double getArea()
            {
                return this.lengthOfFirstSide * this.lengthOfSecondSide;
            }

            public double getPerimeter()
            {
                return 2 * (this.lengthOfFirstSide + this.lengthOfSecondSide);
            }
        }

        class Circle : Shape
        {
            private double radius;

            public Circle(double radius)
            {
                this.radius = radius;
            }

            public double getWidth()
            {
                return this.radius * 2;
            }

            public double getHeight()
            {
                return this.radius * 2;
            }

            public double getArea()
            {
                return Math.PI * Math.Pow(radius, 2);
            }

            public double getPerimeter()
            {
                return 2 * Math.PI * radius;
            }
        }

        //public Shape FindMaxArea(Shape[] array)
        //{
        //    double max = 0;
        //    int indexOfMax = 0;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i].getArea() > max)
        //        {
        //            max = array[i].getArea();
        //            indexOfMax = i;
        //        }
        //    }

        //    return array[indexOfMax];
        //}

        //public Shape FindSecondMaxPerimeter(Shape[] array)
        //{
        //    double max = 0;
        //    int indexOfMax = 0;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i].getPerimeter() > max)
        //        {
        //            max = array[i].getArea();
        //            indexOfMax = i;
        //        }
        //    }

        //    return array[indexOfMax];
        //}

        static void Main(string[] args)
        {
            Square firstSquare = new Square(4);
            Square secondSquare = new Square(3);
            Triangle firstTriangle = new Triangle(1, 2, 7, 2, 5, 7);
            Triangle secondTriangle = new Triangle(0, 0, 4, 2, 5, 7);
            Rectangle firstRectangle = new Rectangle(3, 5);
            Rectangle secondRectangle = new Rectangle(1, 2);
            Circle firstCircle = new Circle(2);
            Circle secondCircle = new Circle(8);
            //Console.WriteLine(firstRectangle.getArea());
            Shape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };  
        }
    }
}
