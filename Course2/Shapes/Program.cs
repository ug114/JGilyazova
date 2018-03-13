using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Square firstSquare = new Square(4);
            Square secondSquare = new Square(3);

            Triangle firstTriangle = new Triangle(1, 2, 7, 2, 5, 7);
            Triangle secondTriangle = new Triangle(0, 0, 4, 2, 5, 7);

            Rectangle firstRectangle = new Rectangle(3, 5);
            Rectangle secondRectangle = new Rectangle(1, 2);

            Circle firstCircle = new Circle(2);
            Circle secondCircle = new Circle(8);

            Shape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };

            //Array.Sort(array, square.SortByArea());
            //Console.WriteLine(array[array.Length - 1].ToString());

            Array.Sort(array, Square.SortByPerimeter());
            Console.WriteLine(array[array.Length - 2].ToString());

            //foreach (shape s in array)
            //{
            //    Console.WriteLine(s.GetPerimeter());
            //}
        }
    }
}
