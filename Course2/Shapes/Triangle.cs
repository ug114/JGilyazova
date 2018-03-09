using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
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

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
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

        public double GetPerimeter()
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

        private class SortByAreaHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Shape shape1 = (Shape)a;
                Shape shape2 = (Shape)b;

                if (shape1.GetArea() > shape2.GetArea())
                {
                    return 1;
                }
                if (shape1.GetArea() < shape2.GetArea())
                {
                    return -1;
                }

                return 0;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            Shape shape = (Shape)obj;
            return string.Compare(GetArea().ToString(), shape.GetArea().ToString());
        }

        public static IComparer SortByArea()
        {
            return new SortByAreaHelper();
        }

        private class SortByPerimeterHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Shape shape1 = (Shape)a;
                Shape shape2 = (Shape)b;

                if (shape1.GetPerimeter() > shape2.GetPerimeter())
                {
                    return 1;
                }
                if (shape1.GetPerimeter() < shape2.GetPerimeter())
                {
                    return -1;
                }

                return 0;
            }
        }

        //int IComparable.CompareTo(object obj)
        //{
        //    Shape shape = (Shape)obj;
        //    return string.Compare(GetArea().ToString(), shape.GetArea().ToString());
        //}

        public static IComparer SortByPerimeter()
        {
            return new SortByPerimeterHelper();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;
            
            return triangle.x1 == x1 && triangle.x2 == x2 && triangle.x3 == x3 && triangle.y1 == y1 && triangle.y2 == y2 && triangle.y3 == y3;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;

            hash = prime * hash + (int)x1;
            hash = prime * hash + (int)x2;
            hash = prime * hash + (int)x3;
            hash = prime * hash + (int)y1;
            hash = prime * hash + (int)y2;
            hash = prime * hash + (int)y3;

            return hash;
        }
    }
}
