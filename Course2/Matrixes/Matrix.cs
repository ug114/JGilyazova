using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] arrayOfRows;

        public Matrix(int n, int m)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Количество строк матрицы должно быть > 0.");
            }

            if (m <= 0)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть > 0.");
            }

            arrayOfRows = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                arrayOfRows[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            arrayOfRows = new Vector[matrix.NumberOfRows];
                        
            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                arrayOfRows[i] = new Vector(matrix.arrayOfRows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int numberOfRows = array.GetLength(0);
            int numberOfColumns = array.GetLength(1);

            if (numberOfRows <= 0)
            {
                throw new ArgumentException("Количество строк матрицы должно быть > 0.");
            }

            if (numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть > 0.");
            }

            arrayOfRows = new Vector[numberOfRows];

            for (int i = 0; i < numberOfRows; i++)
            {
                arrayOfRows[i] = new Vector(numberOfColumns);

                for (int j = 0; j < numberOfColumns; j++)
                {
                    arrayOfRows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            int numberOfRows = array.GetLength(0);
            int numberOfColumns = array[0].Length;

            if (numberOfRows <= 0)
            {
                throw new ArgumentException("Количество строк матрицы должно быть > 0.");
            }

            if (numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть > 0.");
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                if (numberOfColumns < array[i].Length)
                {
                    numberOfColumns = array[i].Length;
                }
            }
            
            arrayOfRows = new Vector[numberOfRows];

            for (int i = 0; i < numberOfRows; i++)
            {
                arrayOfRows[i] = new Vector(numberOfColumns);
                
                for (int j = 0; j < array[i].Length; j++)
                {
                    arrayOfRows[i].SetComponent(j, array[i].GetComponent(j));
                }
            }
        }

        public int NumberOfRows
        {
            get
            {
                return arrayOfRows.GetLength(0);
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return arrayOfRows[0].Length;
            }
        }

        public Vector GetRow(int numberOfRow)
        {
            return new Vector(arrayOfRows[numberOfRow]);
        }

        public void SetRow(int numberOfRow, Vector inputVector)
        {
            if (numberOfRow < 0 || numberOfRow >= NumberOfRows)
            {
                throw new ArgumentException("Неверный номер строки.");
            }

            arrayOfRows[numberOfRow] = new Vector(inputVector);
        }

        public Vector GetColumn(int numberOfColumn)
        {
            Vector column = new Vector(NumberOfRows);
            
            for (int i = 0; i < NumberOfRows; i++)
            {
                column.SetComponent(i, arrayOfRows[i].GetComponent(numberOfColumn));
            }

            return column;
        }

        public Matrix Transpose()
        {
            int oldNumberOfColumns = NumberOfColumns;
            int oldNumberOfRows = NumberOfRows;

            if (NumberOfRows > NumberOfColumns)
            {
                for (int i = 0; i < NumberOfRows; i++)
                {
                    double[] components = new double[NumberOfRows];

                    for (int j = 0; j < oldNumberOfColumns; j++)
                    {
                        components[j] = arrayOfRows[i].GetComponent(j);
                    }

                    arrayOfRows[i] = new Vector(NumberOfRows, components);
                }   
            }
            
            if (NumberOfRows < NumberOfColumns)
            {
                Array.Resize(ref arrayOfRows, NumberOfColumns);
                
                for (int i = 0; i < NumberOfRows - oldNumberOfRows; i++)
                {
                    arrayOfRows[oldNumberOfRows + i] = new Vector(NumberOfColumns);
                }
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (j > i)
                    {
                        double temp = arrayOfRows[i].GetComponent(j);
                        arrayOfRows[i].SetComponent(j, arrayOfRows[j].GetComponent(i));
                        arrayOfRows[j].SetComponent(i, temp);
                    }
                }
            }

            if (oldNumberOfRows < NumberOfRows)
            {
                for (int i = 0; i < NumberOfRows; i++)
                {
                    double[] components = new double[NumberOfRows];

                    for (int j = 0; j < oldNumberOfColumns; j++)
                    {
                        components[j] = arrayOfRows[i].GetComponent(j);
                    }

                    arrayOfRows[i] = new Vector(oldNumberOfRows, components);
                }
            }

            if (oldNumberOfColumns < NumberOfColumns)
            {
                Array.Resize(ref arrayOfRows, oldNumberOfColumns);
            }

            return this;
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            foreach (Vector vector in arrayOfRows)
            {
                vector.MultiplyByScalar(scalar);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{ ");
            
            for (int i = 0; i < NumberOfRows; i++)
            {
                builder.Append(arrayOfRows[i].ToString());
                    
                if (i != NumberOfRows - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.Append(" }").ToString();
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (NumberOfColumns != vector.Length)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть равно размерности вектора.");
            }

            Vector outputVector = new Vector(NumberOfRows);

            for (int i = 0; i < NumberOfRows; i++)
            {
                double sum = Vector.GetScalarMultiplication(arrayOfRows[i], vector);
                outputVector.SetComponent(i, sum);
            }

            return outputVector;
        }

        public Matrix GetSum(Matrix inputMatrix)
        {
            if (NumberOfRows != inputMatrix.NumberOfRows)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (NumberOfColumns != inputMatrix.NumberOfColumns)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                arrayOfRows[i].GetSum(inputMatrix.arrayOfRows[i]);
            }

            return this;
        }

        public Matrix GetDifference(Matrix inputMatrix)
        {
            if (NumberOfRows != inputMatrix.NumberOfRows)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (NumberOfColumns != inputMatrix.NumberOfColumns)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < NumberOfRows; i++)
            {
                arrayOfRows[i].GetDifference(inputMatrix.arrayOfRows[i]);
            }

            return this;
        }

        public double GetDeterminant()
        {
            if (NumberOfColumns != NumberOfRows)
            {
                throw new ArgumentException("Количество строк матрицы должны быть равно количеству столбцов.");
            }

            int tempIndex = 0;
            int numberOfChanges = 0;
            int numberOfStep = 0;

            while (numberOfStep != NumberOfRows - 1)
            {
                bool firstIsNull = true;

                for (int i = numberOfStep; i < NumberOfRows; i++)
                {
                    if (arrayOfRows[i].GetComponent(numberOfStep) != 0)
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
                        for (int i = numberOfStep; i < NumberOfRows; i++)
                        {
                            double temp = arrayOfRows[tempIndex].GetComponent(i);
                            arrayOfRows[tempIndex].SetComponent(i, arrayOfRows[numberOfStep].GetComponent(i));
                            arrayOfRows[numberOfStep].SetComponent(i, temp);
                        }

                        numberOfChanges++;
                    }

                    for (int i = numberOfStep + 1; i < NumberOfRows; i++)
                    {
                        double coefficient = arrayOfRows[i].GetComponent(numberOfStep) / arrayOfRows[numberOfStep].GetComponent(numberOfStep);

                        for (int j = numberOfStep; j < NumberOfRows; j++)
                        {
                            arrayOfRows[i].SetComponent(j, arrayOfRows[i].GetComponent(j) - arrayOfRows[numberOfStep].GetComponent(j) * coefficient);
                        }
                    }
                }

                numberOfStep++;
            }

            double det = arrayOfRows[0].GetComponent(0);

            for (int i = 1; i < NumberOfRows; i++)
            {
                det *= arrayOfRows[i].GetComponent(i);
            }

            return det * Math.Pow(-1, numberOfChanges);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.NumberOfRows != matrix2.NumberOfRows)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetSum(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.NumberOfRows != matrix2.NumberOfRows)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.NumberOfColumns != matrix2.NumberOfColumns)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetDifference(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.NumberOfColumns != matrix2.NumberOfRows)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            Matrix outputMatrix = new Matrix(matrix1.NumberOfRows, matrix2.NumberOfColumns);
            
            for (int i = 0; i < matrix1.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix2.NumberOfColumns; j++)
                {
                    double sum = Vector.GetScalarMultiplication(matrix1.arrayOfRows[i], matrix2.GetColumn(j));
                    outputMatrix.arrayOfRows[i].SetComponent(j, sum);
                }
            }

            return outputMatrix;
        }
    }
}
