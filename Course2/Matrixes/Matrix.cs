using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vector = Vector.Vector;

namespace Matrix
{
    class Matrix
    {
        private vector[] array;

        public Matrix(int m, int n)
        {
            this.array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int n = matrix.array.Length;
            int m = matrix.array[0].getSize();
            this.array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new vector(m);

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
            this.array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new vector(m);
                for (int j = 0; j < m; j++)
                {
                    this.array[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(vector[] array)
        {
            int n = array.Length;
            int m = array[0].getSize();
            this.array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new vector(m);
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

        public vector GetString(int numberOfString)
        {
            return this.array[numberOfString];
        }

        public void SetString(int numberOfString, vector inputVector)
        {
            for (int i = 0; i < inputVector.getSize(); i++)
            {
                this.array[numberOfString].SetComponent(i, inputVector.GetComponent(i));
            }
        }

        public vector GetColumn(int numberOfColumn)
        {
            vector column = new vector(this.GetSizeOfMatrix()[1]);
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

        public vector MultipleVector(vector vector)
        {
            int n = this.GetSizeOfMatrix()[0];
            int m = this.GetSizeOfMatrix()[1];
            double sum = 0;
            vector outputVector = new vector(n);

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

        public double GetDeterminant()
        {
            int arrayLength = this.array.GetLength(0);
            int tempIndex = 0;
            int numberOfChanges = 0;
            int numberOfStep = 0;

            while (numberOfStep != arrayLength - 1)
            {
                bool firstIsNull = true;

                for (int i = numberOfStep; i < arrayLength; i++)
                {
                    if (this.array[i].GetComponent(numberOfStep) != 0)
                    {
                        firstIsNull = false;
                        tempIndex = i;
                        break;
                    }
                }

                if (firstIsNull)
                {
                    return 0;
                }
                else
                {
                    if (tempIndex != numberOfStep)
                    {
                        for (int i = numberOfStep; i < arrayLength; i++)
                        {
                            double temp = this.array[tempIndex].GetComponent(i);
                            this.array[tempIndex].SetComponent(i, this.array[numberOfStep].GetComponent(i));
                            this.array[numberOfStep].SetComponent(i, temp);
                        }

                        numberOfChanges++;
                    }

                    for (int i = numberOfStep + 1; i < arrayLength; i++)
                    {
                        double coefficient = this.array[i].GetComponent(numberOfStep) / this.array[numberOfStep].GetComponent(numberOfStep);

                        for (int j = numberOfStep; j < arrayLength; j++)
                        {
                            this.array[i].SetComponent(j, this.array[i].GetComponent(j) - this.array[numberOfStep].GetComponent(j) * coefficient);
                        }
                    }
                }

                numberOfStep++;
            }

            double det = this.array[0].GetComponent(0);

            for (int i = 1; i < arrayLength; i++)
            {
                det *= this.array[i].GetComponent(i);
            }

            return det * Math.Pow(-1, numberOfChanges);
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
    }
}
