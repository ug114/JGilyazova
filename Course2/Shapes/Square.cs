namespace Shape
{
    public class Square : IShape
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
            return "Квадрат со стороной " + sideLength.ToString() + ".";
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
            return sideLength.GetHashCode();
        }
    }
}
