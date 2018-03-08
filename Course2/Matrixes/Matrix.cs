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
            array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int n = matrix.array.Length;
            int m = matrix.array[0].GetSize();
            array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new vector(m);

                for (int j = 0; j < m; j++)
                {
                    array[i].SetComponent(j, matrix.array[i].GetComponent(j));
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
            int m = array[0].GetSize();
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

        public int GetNumberOfRows()
        {
            return array.GetLength(0);
        }

        public int GetNumberOfColumns()
        {
            return array[0].GetSize();
        }

        public vector GetString(int numberOfString)
        {
            return array[numberOfString];
        }

        public void SetString(int numberOfString, vector inputVector)
        {
            for (int i = 0; i < inputVector.GetSize(); i++)
            {
                array[numberOfString].SetComponent(i, inputVector.GetComponent(i));
            }
        }

        public vector GetColumn(int numberOfColumn)
        {
            vector column = new vector(GetNumberOfColumns());
            int n = GetNumberOfRows();
            for (int i = 0; i < n; i++)
            {
                column.SetComponent(i, array[numberOfColumn].GetComponent(i));
            }
            return column;
        }

        public void Transpose()
        {
            double temp;
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j > i)
                    {
                        temp = array[i].GetComponent(j);
                        array[i].SetComponent(j, array[j].GetComponent(i));
                        array[j].SetComponent(i, temp);
                    }
                }
            }
        }

        public void Multiple(double scalar)
        {
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i].SetComponent(j, array[i].GetComponent(j) * scalar);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{ ");
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        builder.Append("{");
                    }

                    builder.Append(array[i].GetComponent(j));

                    if (j != m - 1)
                    {
                        builder.Append(", ");
                    }

                    if (j == m - 1)
                    {
                        builder.Append("}");
                    }
                }
                if (i != n - 1)
                {
                    builder.Append(", ");
                }
            }
            
            return builder.Append(" }").ToString();
        }

        public vector MultipleVector(vector vector)
        {
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();
            double sum = 0;
            vector outputVector = new vector(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum += array[i].GetComponent(j) * vector.GetComponent(j);
                }
                outputVector.SetComponent(i, sum);
                sum = 0;
            }

            return outputVector;
        }

        public void Sum(Matrix inputMatrix)
        {
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                   array[i].SetComponent(j, array[i].GetComponent(j) + inputMatrix.array[i].GetComponent(j));
                }
            }
        }

        public void Difference(Matrix inputMatrix)
        {
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i].SetComponent(j, array[i].GetComponent(j) - inputMatrix.array[i].GetComponent(j));
                }
            }
        }

        public double GetDeterminant()
        {
            int arrayLength = array.GetLength(0);
            int tempIndex = 0;
            int numberOfChanges = 0;
            int numberOfStep = 0;

            while (numberOfStep != arrayLength - 1)
            {
                bool firstIsNull = true;

                for (int i = numberOfStep; i < arrayLength; i++)
                {
                    if (array[i].GetComponent(numberOfStep) != 0)
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
                            double temp = array[tempIndex].GetComponent(i);
                            array[tempIndex].SetComponent(i, array[numberOfStep].GetComponent(i));
                            array[numberOfStep].SetComponent(i, temp);
                        }

                        numberOfChanges++;
                    }

                    for (int i = numberOfStep + 1; i < arrayLength; i++)
                    {
                        double coefficient = array[i].GetComponent(numberOfStep) / array[numberOfStep].GetComponent(numberOfStep);

                        for (int j = numberOfStep; j < arrayLength; j++)
                        {
                            array[i].SetComponent(j, array[i].GetComponent(j) - array[numberOfStep].GetComponent(j) * coefficient);
                        }
                    }
                }

                numberOfStep++;
            }

            double det = array[0].GetComponent(0);

            for (int i = 1; i < arrayLength; i++)
            {
                det *= array[i].GetComponent(i);
            }

            return det * Math.Pow(-1, numberOfChanges);
        }

        public static Matrix Sum(Matrix matrix1, Matrix matrix2)
        {
            int n = matrix1.GetNumberOfRows();
            int m = matrix1.GetNumberOfColumns();
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
            int n = matrix1.GetNumberOfRows();
            int m = matrix1.GetNumberOfColumns();
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
            int n = matrix1.GetNumberOfRows();
            int m = matrix2.GetNumberOfColumns();
            int l = matrix1.GetNumberOfColumns();
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
