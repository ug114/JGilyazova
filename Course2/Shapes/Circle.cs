using System;
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
