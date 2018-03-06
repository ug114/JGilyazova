using System;
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

            return rectangle.height == height && rectangle.width == width;
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
