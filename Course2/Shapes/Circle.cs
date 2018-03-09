using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Circle : Shape, IComparable
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetWidth()
        {
            return radius * 2;
        }

        public double GetHeight()
        {
            return radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return radius.ToString();
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

            Circle circle = (Circle)obj;
            
            return circle.radius == radius;
        }

        public override int GetHashCode()
        {
            return (int)radius;
        }
    }
}
