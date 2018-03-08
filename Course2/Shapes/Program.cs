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
using System.Collections;

namespace Shape
{
    //public class AreaComparer : IComparer
    //{
    //    public int Compare(Object x, Object y)
    //    {
            
    //        return 0;
    //    }
    //}

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

            shape[] array = { firstSquare, secondSquare, firstTriangle, secondTriangle, firstRectangle, secondRectangle, firstCircle, secondCircle };

            //Array.Sort(array, square.SortByArea());
            //Console.WriteLine(array[array.Length - 1].ToString());

            Array.Sort(array, square.SortByPerimeter());
            Console.WriteLine(array[array.Length - 2].ToString());

            //foreach (shape s in array)
            //{
            //    Console.WriteLine(s.GetPerimeter());
            //}
        }
    }
}
