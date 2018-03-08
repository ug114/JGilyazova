using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Rectangle : Shape, IComparable
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double GetWidth()
        {
            return Math.Max(height, width);
        }

        public double GetHeight()
        {
            return Math.Min(height, width);
        }

        public double GetArea()
        {
            return height * width;
        }

        public double GetPerimeter()
        {
            return 2 * (height + width);
        }

        public override string ToString()
        {
            return height + ", " + width;
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

            Rectangle rectangle = (Rectangle)obj;
            double eps = 1e-5;

            return (rectangle.height - height) < eps && (rectangle.width - width) < eps;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;

            hash = prime * hash + (int)height;
            hash = prime * hash + (int)width;

            return hash;
        }
    }
}
