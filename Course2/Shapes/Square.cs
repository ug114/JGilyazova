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

            return square.lengthOfSide == lengthOfSide;
        }

        public override int GetHashCode()
        {
            int prime = 19;
            int hash = 1;

            hash = prime * hash + (int)lengthOfSide;

            return hash;
        }
    }
}
