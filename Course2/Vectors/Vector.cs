using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector
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
                Console.WriteLine("Размерность вектора должна быть > 0.");
            }

            components = new double[n];

            for (int i = 0; i < n; i++)
            {
                components[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            for (int i = 0; i < vector.GetSize(); i++)
            {
                components[i] = vector.components[i];
            }
        }

        public Vector(double[] array)
        {
            components = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                components[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            components = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (i >= array.Length)
                {
                    components[i] = 0;
                }
                else
                {
                    components[i] = array[i];
                }
            }
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", components) + " }";
        }

        public Vector GetSum(Vector vector2)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                if (i < vector2.GetSize())
                {
                    components[i] += vector2.components[i];
                }
            }

            return this;
        }

        public Vector GetDifference(Vector vector2)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                if (i < vector2.GetSize())
                {
                    components[i] -= vector2.components[i];
                }
            }

            return this;
        }

        public Vector MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                components[i] *= scalar;
            }

            return this;
        }

        public Vector Reverse()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                components[i] *= -1;
            }

            return this;
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double newComponent)
        {
            components[index] = newComponent;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() < vector2.GetSize())
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
            if (vector1.GetSize() < vector2.GetSize())
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

            for (int i = 0; i < Math.Min(vector1.GetSize(), vector2.GetSize()); i++)
            {
                sum += vector1.components[i] * vector2.components[i];
            }

            return sum;
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

            Vector vector = (Vector)obj;

            if (vector.GetSize() != GetSize())
            {
                return false;
            }
            else
            {
                double eps = 1e-5;

                for (int i = 0; i < GetSize(); i++)
                {
                    if ((vector.GetComponent(i) - GetComponent(i)) > eps)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + (int)components[i];
            }

            return hash;
        }
    }
}

