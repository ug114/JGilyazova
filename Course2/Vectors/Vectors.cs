using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            try
            {
                if (n <= 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Exception");
            }
            this.components = new double[n];
            for (int i = 0; i < n; i++)
            {
                this.components[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            for (int i = 0; i < vector.getSize(); i++)
            {
                this.components[i] = vector.components[i];
            }
        }

        public Vector(double[] array)
        {
            this.components = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.components[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            this.components = new double[n];
            if (array.Length == n)
            {
                for (int i = 0; i < n; i++)
                {
                    this.components[i] = array[i];
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    this.components[i] = array[i];
                }

                for (int i = 0; i < n; i++)
                {
                    this.components[i] = 0;
                }
            }
        }

        public int getSize()
        {
            return this.components.Length;
        }

        public string toString()
        {
            string outputString = "{" + this.components[0].ToString();

            for (int i = 1; i < this.getSize(); i++)
            {
                outputString = outputString + ", " + this.components[i];
            }

            return outputString + "}";
        }

        public Vector GetSum(Vector vector2)
        {
            if (vector2.getSize() < this.getSize())
            {
                for (int i = 0; i < vector2.getSize(); i++)
                {
                    this.components[i] += vector2.components[i];
                }
            }
            else
            {
                for (int i = 0; i < this.getSize(); i++)
                {
                    this.components[i] += vector2.components[i];
                }
            }
            return this;
        }

        public Vector GetDifference(Vector vector2)
        {
            if (vector2.getSize() < this.getSize())
            {
                for (int i = 0; i < vector2.getSize(); i++)
                {
                    this.components[i] += vector2.components[i];
                }
            }
            else
            {
                for (int i = 0; i < this.getSize(); i++)
                {
                    this.components[i] -= vector2.components[i];
                }
            }
            return this;
        }

        public Vector MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < this.getSize(); i++)
            {
                this.components[i] *= scalar;
            }
            return this;
        }

        public Vector Reverse()
        {
            for (int i = 0; i < this.getSize(); i++)
            {
                this.components[i] *= -1;
            }
            return this;
        }

        public double GetComponent(int index)
        {
            return this.components[index];
        }

        public void SetComponent(int index, double newComponent)
        {
            this.components[index] = newComponent;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            if (vector1.getSize() < vector2.getSize())
            {
                return vector2.GetSum(vector1);
            }
            else
            {
                return vector1.GetSum(vector2);
            }
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            if (vector1.getSize() < vector2.getSize())
            {
                return vector2.GetDifference(vector1);
            }
            else
            {
                return vector1.GetDifference(vector2);
            }
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;

            for (int i = 0; i < Math.Min(vector1.getSize(), vector2.getSize()); i++)
            {
                sum += vector1.components[i] * vector2.components[i];
            }

            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Vector vector = obj as Vector;
            if (vector as Vector == null)
            {
                return false;
            }

            if (vector.getSize() != this.getSize())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.getSize(); i++)
                {
                    if (vector.GetComponent(i) != this.GetComponent(i))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        //public override int GetHashCode()
        //{
        //    return (int);
        //}

        static void Main(string[] args)
        {
            Vector vector1 = new Vector(0);
            Vector vector2 = new Vector(new double[] { 1, 2, 0 });
            Vector vector3 = new Vector(new double[] { 1, 1 });
            Console.WriteLine("{0}, {1}, {2}", vector2.getSize(), vector2.GetSum(vector3).toString(), vector2.MultiplyByScalar(2).toString());
        }
    }
}

