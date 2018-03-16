using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape, IComparable
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return sideLength * 4;
        }

        public override string ToString()
        {
            return sideLength.ToString();
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
            
            return square.sideLength == sideLength;
        }

        public override int GetHashCode()
        {
            return (int)sideLength;
        }
    }
}
