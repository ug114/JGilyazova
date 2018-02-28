using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(0);
            Vector vector2 = new Vector(new double[] { 1, 2, 0 });
            Vector vector3 = new Vector(new double[] { 1, 1 });
            Console.WriteLine("{0}, {1}, {2}", vector2.getSize(), vector2.GetSum(vector3).toString(), vector2.MultiplyByScalar(2).toString());
        }
    }
}
