using System;

namespace Shape
{
    public class Triangle : IShape
    {
        private double x1;
        private double x2;
        private double x3;
        private double y1;
        private double y2;
        private double y3;

        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public static double GetSideLength(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
        {
            double eps = 1e-10;

            if (Math.Abs((x3 - x1) * (y2 - y1) - (y3 - y1) * (x2 - x1)) < eps)
            {
                return 0;
            }
            else
            {
                double a = GetSideLength(x1, x2, y1, y2);
                double b = GetSideLength(x1, x3, y1, y3);
                double c = GetSideLength(x2, x3, y2, y3);
                double p = GetPerimeter() / 2;

                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public double GetPerimeter()
        {
            double a = GetSideLength(x1, x2, y1, y2);
            double b = GetSideLength(x1, x3, y1, y3);
            double c = GetSideLength(x2, x3, y2, y3);

            return a + b + c;
        }

        public override string ToString()
        {
            return "Треугольник с координатами ((" + x1 + ", " + y1 + "), (" + x2 + ", " + y2 + "), (" + x3 + ", " + y3 + ")).";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;
            
            return triangle.x1 == x1 && triangle.x2 == x2 && triangle.x3 == x3 && triangle.y1 == y1 && triangle.y2 == y2 && triangle.y3 == y3;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;

            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + y3.GetHashCode();

            return hash;
        }
    }
}
