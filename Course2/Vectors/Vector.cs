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
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            components = new double[n];
        }

        public Vector(Vector vector)
        {
            int size = vector.GetSize();

            if (size <= 0)
            {
                throw new ArgumentException();
            }

            vector.components.CopyTo(components = new double[size], 0);
        }

        public Vector(double[] array)
        {
            if (array.Length <= 0)
            {
                throw new ArgumentException();
            }

            array.CopyTo(components = new double[array.Length], 0);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            array.CopyTo(components = new double[n], 0);
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
            int minSize = Math.Min(GetSize(), vector2.GetSize());
            int maxSize = Math.Min(GetSize(), vector2.GetSize());

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref components, maxSize);
                
                for (int i = 0; i < maxSize; i++)
                {
                    components[i] += vector2.components[i];
                }
            }
            else
            {
                for (int i = 0; i < minSize; i++)
                {
                    components[i] += vector2.components[i];
                }
            }

            return this;
        }

        public Vector GetDifference(Vector vector2)
        {
            int minSize = Math.Min(GetSize(), vector2.GetSize());
            int maxSize = Math.Min(GetSize(), vector2.GetSize());

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref components, maxSize);

                for (int i = 0; i < maxSize; i++)
                {
                    components[i] -= vector2.components[i];
                }
            }
            else
            {
                for (int i = 0; i < minSize; i++)
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
            return MultiplyByScalar(-1);
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
                return new Vector(vector2).GetSum(vector1);
            }
            else
            {
                return new Vector(vector1).GetSum(vector2);
            }
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() < vector2.GetSize())
            {
                return new Vector(vector2).GetDifference(vector1);
            }
            else
            {
                return new Vector(vector1).GetDifference(vector2);
            }
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double sum = 0;
            int minSize = Math.Min(vector1.GetSize(), vector2.GetSize());

            for (int i = 0; i < minSize; i++)
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
                for (int i = 0; i < GetSize(); i++)
                {
                    if (vector.GetComponent(i) != GetComponent(i))
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

            foreach (double component in components)
            {
                hash = prime * hash + (int)component;
            }

            return hash;
        }
    }
}

