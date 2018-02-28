using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shapes.Square firstSquare = new Shapes.Square(4);
            Shapes.Square secondSquare = new Shapes.Square(3);

            Shapes.Triangle firstTriangle = new Shapes.Triangle(1, 2, 7, 2, 5, 7);
            Shapes.Triangle secondTriangle = new Shapes.Triangle(0, 0, 4, 2, 5, 7);

            Shapes.Rectangle firstRectangle = new Shapes.Rectangle(3, 5);
            Shapes.Rectangle secondRectangle = new Shapes.Rectangle(1, 2);

            Shapes.Circle firstCircle = new Shapes.Circle(2);
            Shapes.Circle secondCircle = new Shapes.Circle(8);

            Console.WriteLine(firstRectangle.getArea());

            Shapes.Shape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };
        }
    }
}
