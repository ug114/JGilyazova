using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Square : Shape, IComparable
    {
        private double lengthOfSide;

        public Square(double lengthOfSide)
        {
            this.lengthOfSide = lengthOfSide;
        }

        public double GetWidth()
        {
            return lengthOfSide;
        }

        public double GetHeight()
        {
            return lengthOfSide;
        }

        public double GetArea()
        {
            return lengthOfSide * lengthOfSide;
        }

        public double GetPerimeter()
        {
            return lengthOfSide * 4;
        }

        public override string ToString()
        {
            return lengthOfSide.ToString();
        }

        //public int CompareTo(Shape shape)
        //{
        //    return GetArea().CompareTo(shape.GetArea());
        //}

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

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square square = (Square)obj;
            double eps = 1e-5;

            return (square.lengthOfSide - lengthOfSide) < eps;
        }

        public override int GetHashCode()
        {
            return (int)lengthOfSide;
        }
    }
}
