using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    //class Vectors
    //{
        class Vector
        {
            private double[] components;

            public Vector(int n)
            {
                //try
                //{
                //    if (n <= 0)
                //    {
                //        throw new IllegalArgumentException();
                //    }
                //}
                //catch (IllegalArgumentException)
                //{
                //    Console.WriteLine("Exception");
                //}
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
                string outputString = this.components[0].ToString();

                for (int i = 1; i < this.getSize(); i++)
                {
                    outputString = outputString + " ," + this.components[i];
                }
                return outputString;
            }

            public Vector GetSum(Vector vector2)
            {
                for (int i = 0; i < this.getSize(); i++)
                {
                    this.components[i] += vector2.components[i];
                }
                return this;
            }

            public Vector GetDifference(Vector vector2)
            {
                for (int i = 0; i < this.getSize(); i++)
                {
                    this.components[i] -= vector2.components[i];
                }
                return this;
            }

            public Vector GetMultiplication(double scalar)
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
                //vector1.GetSum(vector2);
                return vector1.GetSum(vector2);
                //double[] array = new double[vector1.getSize()];

                //for (int i = 0; i < vector1.getSize(); i++)
                //{
                //     array[i] = 
                //}
            }

            public static Vector GetDifference(Vector vector1, Vector vector2)
            {
                return vector1.GetDifference(vector2);
            }

            public static double GetMultiple(Vector vector1, Vector vector2)
            {
                double sum = 0;
                for (int i = 0; i < vector1.getSize(); i++)
                {
                    sum += vector1.components[i] * vector2.components[i]; 
                }
                return sum;
            }

        //}
        //static void Main(string[] args)
        //{
        //    double[] array = { 1, 2, 0 };
        //    Vector vector2 = new Vector(3);
        //    Vector vector1 = new Vector(array);
        //    Console.WriteLine("{0}, {1}, {2}", vector1.getSize(), vector1.GetSum(vector2).toString(), vector1.GetMultiplication(2).toString());

        //}
    }
}
