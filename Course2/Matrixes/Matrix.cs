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
             array = new vector[n];
                        
            matrix.array.CopyTo(array, 0);
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
            this.array = new vector[n];

            for (int i = 0; i < n; i++)
            {
                this.array[i] = new vector(array[i]);
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
            array[numberOfString] = new vector(inputVector);
        }

        public vector GetColumn(int numberOfColumn)
        {
            int n = GetNumberOfRows();
            vector column = new vector(n);
            
            for (int i = 0; i < n; i++)
            {
                column.SetComponent(i, array[i].GetComponent(numberOfColumn));
            }

            return column;
        }

        public void Transpose()
        {
            int n = GetNumberOfRows();
            int m = GetNumberOfColumns();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j > i)
                    {
                        double temp = array[i].GetComponent(j);
                        array[i].SetComponent(j, array[j].GetComponent(i));
                        array[j].SetComponent(i, temp);
                    }
                }
            }
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            int n = GetNumberOfRows();
            
            for (int i = 0; i < n; i++)
            {
                array[i].MultiplyByScalar(scalar);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{ ");
            int n = GetNumberOfRows();
            
            for (int i = 0; i < n; i++)
            {
                builder.Append(array[i].ToString());
                    
                if (i != n - 1)
                {
                    builder.Append(", ");
                }
            }
            
            return builder.Append(" }").ToString();
        }

        public vector MultipleByVector(vector vector)
        {
            int n = GetNumberOfRows();
            double sum = 0;
            vector outputVector = new vector(n);

            for (int i = 0; i < n; i++)
            {
                sum = vector.GetScalarMultiplication(array[i], vector);
                outputVector.SetComponent(i, sum);
                sum = 0;
            }

            return outputVector;
        }

        public Matrix GetSum(Matrix inputMatrix)
        {
            int n = GetNumberOfRows();
            
            for (int i = 0; i < n; i++)
            {
                array[i].GetSum(inputMatrix.array[i]);
            }

            return this;
        }

        public Matrix GetDifference(Matrix inputMatrix)
        {
            int n = GetNumberOfRows();
            
            for (int i = 0; i < n; i++)
            {
                array[i].GetDifference(inputMatrix.array[i]);
            }

            return this;
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

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            return new Matrix(matrix1).GetSum(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            return new Matrix(matrix1).GetDifference(matrix2);
        }

        public static Matrix Multiplicate(Matrix matrix1, Matrix matrix2)
        {
            int n = matrix1.GetNumberOfRows();
            int m = matrix2.GetNumberOfColumns();
            Matrix outputMatrix = new Matrix(m, n);
            
            for (int i = 0; i < n; i++)
            {
                double sum = 0;

                for (int j = 0; j < m; j++)
                {
                    sum = vector.GetScalarMultiplication(matrix1.array[i], matrix2.GetColumn(j));
                    outputMatrix.array[i].SetComponent(j, sum);
                    
                }
            }

            return outputMatrix;
        }
    }
}
