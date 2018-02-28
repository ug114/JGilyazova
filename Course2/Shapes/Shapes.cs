using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Shapes
    {
        public interface Shape
        {
            double getWidth();
            double getHeight();
            double getArea();
            double getPerimeter();
        }

        public class Square : Shape, IComparable
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

            public override string ToString()
            {
                return lengthOfSide.ToString();
            }

            public int CompareTo(object obj)
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                    
                Square square = obj as Square; 
                if (square as Square == null)
                {
                    return false;
                }
                
                return square.lengthOfSide == this.lengthOfSide;
            }

            public override int GetHashCode()
            {
                return (int)lengthOfSide;
            }
        }

        public class Triangle : Shape, IComparable
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

            public override string ToString()
            {
                return "((" + x1 + ", " + y1 + "), (" + x2 + ", " + y2 + "),(" + x3 + ", " + y3 + "))";
            }

            public int CompareTo(object obj)
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                Triangle triangle = obj as Triangle;
                if (triangle as Triangle == null)
                {
                    return false;
                }

                return triangle.x1 == this.x1 && triangle.x2 == this.x2 && triangle.x3 == this.x3 && triangle.y1 == this.y1 && triangle.y2 == this.y2 && triangle.y3 == this.y3;
            }

            public override int GetHashCode()
            {
                return (int)(x1 * x2 * x3 * y1 * y2 * y3);
            }
        }

        public class Rectangle : Shape, IComparable
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

            public override string ToString()
            {
                return lengthOfFirstSide + ", " + lengthOfSecondSide;
            }
            
            public int CompareTo(Object obj)
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                Rectangle rectangle = obj as Rectangle;
                if (rectangle as Rectangle == null)
                {
                    return false;
                }

                return rectangle.lengthOfFirstSide == this.lengthOfFirstSide && rectangle.lengthOfSecondSide == this.lengthOfSecondSide;
            }

            public override int GetHashCode()
            {
                return (int)(lengthOfFirstSide * lengthOfSecondSide);
            }
        }

        public class Circle : Shape, IComparable
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
            
            public override string ToString()
            {
                return radius.ToString();
            }

            public int CompareTo(Object obj)
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                Circle circle = obj as Circle;
                if (circle as Circle == null)
                {
                    return false;
                }

                return circle.radius == this.radius;
            }

            public override int GetHashCode()
            {
                return (int)radius;
            }
        }
    }
}
