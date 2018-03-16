using System;

namespace Shape
{
    public class Rectangle : IShape
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
            return "Прямоугольник со сторонами " + height + ", " + width + ".";
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
            
            return rectangle.height == height && rectangle.width == width;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;

            hash = prime * hash + height.GetHashCode();
            hash = prime * hash + width.GetHashCode();

            return hash;
        }
    }
}
