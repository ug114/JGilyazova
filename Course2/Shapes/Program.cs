using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using square = Shape.Square;
using triangle = Shape.Triangle;
using rectangle = Shape.Rectangle;
using circle = Shape.Circle;
using shape = Shape.Shape;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            square firstSquare = new square(4);
            square secondSquare = new square(3);

            triangle firstTriangle = new triangle(1, 2, 7, 2, 5, 7);
            triangle secondTriangle = new triangle(0, 0, 4, 2, 5, 7);

            rectangle firstRectangle = new rectangle(3, 5);
            rectangle secondRectangle = new rectangle(1, 2);

            circle firstCircle = new circle(2);
            circle secondCircle = new circle(8);

            Console.WriteLine(firstRectangle.getArea());

            shape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };
        }
    }
}
