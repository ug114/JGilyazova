using System;
using System.Collections.Generic;

namespace Shape
{
    class Program
    {
        public static IComparer<IShape> SortByArea()
        {
            return new SortByAreaHelper();
        }

        public static IComparer<IShape> SortByPerimeter()
        {
            return new SortByPerimeterHelper();
        }

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

            IShape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };

            Array.Sort(array, SortByArea());
            Console.WriteLine("Фигура с наибольшей площадью: {0}", array[array.Length - 1].ToString());

            Array.Sort(array, SortByPerimeter());
            Console.WriteLine("Фигура со вторым по величине периметром: {0}", array[array.Length - 2].ToString());
        }
    }
}
