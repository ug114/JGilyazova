using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace Matrixes
{
    class Matrix
    {
        private Vector[] array;

        public Matrix(int m, int n)
        {
            this.array = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int n = matrix.array.Length;
            int m = matrix.array[0].getSize();
            this.array = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new Vector(m);

                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, matrix.array[i].GetComponent(j));
                }
            }
        }

        public Matrix(double[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            this.array = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new Vector(m);
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            int n = array.Length;
            int m = array[0].getSize();
            this.array = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new Vector(m);
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, array[i].GetComponent(j));
                }
            }
        }

        public int[] GetSizeOfMatrix()
        {
            int[] sizes = new int[2];
            sizes[0] = this.array.Length;
            sizes[1] = this.array[0].getSize();
            return sizes;
        }

        public Vector GetString(int numberOfString)
        {
            return this.array[numberOfString];
        }

        public void SetString(int numberOfString, Vector inputVector)
        {
            for (int i = 0; i < inputVector.getSize(); i++)
            {
                this.array[numberOfString].SetComponent(i, inputVector.GetComponent(i));
            }
        }

        public Vector GetColumn(int numberOfColumn)
        {
            Vector column = new Vector(this.GetSizeOfMatrix()[1]);
            int n = this.GetSizeOfMatrix()[0];
            for (int i = 0; i < n; i++)
            {
                column.SetComponent(i, this.array[numberOfColumn].GetComponent(i));
            }
            return column;
        }

        public void Transpose()
        {
            double temp;
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j > i)
                    {
                        temp = this.array[i].GetComponent(j);
                        this.array[i].SetComponent(j, this.array[j].GetComponent(i));
                        this.array[j].SetComponent(i, temp);
                    }
                }
            }
        }

        public void Multiple(double scalar)
        {
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, this.array[i].GetComponent(j) * scalar);
                }
            }
        }

        public string toString()
        {
            string outputString = "{";
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        outputString += "{";
                    }
                    outputString += this.array[i].GetComponent(j);
                    if (j != m - 1)
                    {
                        outputString += ", ";
                    }

                    if (j == m - 1)
                    {
                        outputString += "}";
                    }
                }
                if (i != n - 1)
                {
                    outputString += ", ";
                }
            }
            outputString += "}";
            return outputString;
        }

        public Vector MultipleVector(Vector vector)
        {
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];
            double sum = 0;
            Vector outputVector = new Vector(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum += this.array[i].GetComponent(j) * vector.GetComponent(j);
                }
                outputVector.SetComponent(i, sum);
                sum = 0;
            }
            return outputVector;
        }

        public void Sum(Matrix inputMatrix)
        {
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, this.array[i].GetComponent(j) + inputMatrix.array[i].GetComponent(j));
                }
            }
        }

        public void Difference(Matrix inputMatrix)
        {
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, this.array[i].GetComponent(j) - inputMatrix.array[i].GetComponent(j));
                }
            }
        }

        public static Matrix Sum(Matrix matrix1, Matrix matrix2)
        {
            int n = matrix1.GetSizeOfMatrix()[0];
            int m = matrix1.GetSizeOfMatrix()[1];
            Matrix sumMatrix = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sumMatrix.array[i].SetComponent(j, matrix1.array[i].GetComponent(j) + matrix2.array[i].GetComponent(j));
                }
            }
            return sumMatrix;
        }

        public static Matrix Difference(Matrix matrix1, Matrix matrix2)
        {
            int n = matrix1.GetSizeOfMatrix()[0];
            int m = matrix1.GetSizeOfMatrix()[1];
            Matrix outputMatrix = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    outputMatrix.array[i].SetComponent(j, matrix1.array[i].GetComponent(j) - matrix2.array[i].GetComponent(j));
                }
            }
            return outputMatrix;
        }

        public static Matrix Multiplicate(Matrix matrix1, Matrix matrix2)
        {
            int n = matrix1.GetSizeOfMatrix()[0];
            int m = matrix2.GetSizeOfMatrix()[1];
            int l = matrix1.GetSizeOfMatrix()[1];
            Matrix outputMatrix = new Matrix(m, n);
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < l; k++)
                    {
                        sum += matrix1.array[i].GetComponent(k) * matrix2.array[k].GetComponent(j);
                    }
                    outputMatrix.array[i].SetComponent(j, sum);
                    sum = 0;
                }

            }
            return outputMatrix;
        }

        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(2, 2);
            Matrix matrix2 = new Matrix(matrix1);
            double[,] array = { { 1, 2 }, { 3, 4 } };
            Matrix matrix3 = new Matrix(array);
            double[] array1 = { 1, 2, 3 };
            Vector v1 = new Vector(array1);
            double[] array2 = { 2, 4, 6 };
            Vector v2 = new Vector(array2);
            Matrix matrix4 = new Matrix(new Vector[] { v1, v2 });
            matrix4.Multiple(2);
            Console.WriteLine(matrix3.toString());
            Console.WriteLine(matrix4.toString());
            Console.WriteLine(Multiplicate(matrix3, matrix4).toString());

            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(" {0}", matrix4.array[i].GetComponent(j));
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(matrix4.MultipleVector(v1).toString());
        }
    }
}
