using System;
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
}
