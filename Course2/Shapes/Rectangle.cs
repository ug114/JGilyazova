using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
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
}
