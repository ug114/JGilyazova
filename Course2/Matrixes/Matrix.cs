using System;
using System.Text;
using Vector = Vectors.Vector;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] array;

        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов матрицы должно быть > 0.");
            }

            array = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int numberOfRows = matrix.GetNumberOfRows();
            int numberOfColumns = matrix.GetNumberOfColumns();

            if (numberOfRows <= 0 || numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов матрицы должно быть > 0.");
            }
                        
            array = new Vector[numberOfRows];
                        
            for (int i = 0; i < numberOfRows; i++)
            {
                array[i] = new Vector(matrix.array[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int numberOfRows = array.GetLength(0);
            int numberOfColumns = array.GetLength(1);

            if (numberOfRows <= 0 || numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов матрицы должно быть > 0.");
            }

            this.array = new Vector[numberOfRows];

            for (int i = 0; i < numberOfRows; i++)
            {
                this.array[i] = new Vector(numberOfColumns);

                for (int j = 0; j < numberOfColumns; j++)
                {
                    this.array[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            int numberOfRows = array.Length;
            int numberOfColumns = array[0].GetSize();

            for (int i = 0; i < numberOfRows; i++)
            {
                int size = array[i].GetSize();

                if (numberOfColumns < size)
                {
                    numberOfColumns = size;
                }
            }

            if (numberOfRows <= 0 || numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов матрицы должно быть > 0.");
            }

            this.array = new Vector[numberOfRows];

            for (int i = 0; i < numberOfRows; i++)
            {
                this.array[i] = new Vector(numberOfColumns);
                
                for (int j = 0; j < array[i].GetSize(); j++)
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

        public Vector GetRow(int numberOfString)
        {
            return new Vector(array[numberOfString]);
        }

        public void SetRow(int numberOfString, Vector inputVector)
        {
            array[numberOfString] = new Vector(inputVector);
        }

        public Vector GetColumn(int numberOfColumn)
        {
            int numberOfRows = GetNumberOfRows();
            
            Vector column = new Vector(numberOfRows);
            
            for (int i = 0; i < numberOfRows; i++)
            {
                column.SetComponent(i, array[i].GetComponent(numberOfColumn));
            }

            return column;
        }

        public Matrix Transpose()
        {
            int numberOfRows = GetNumberOfRows();
            int numberOfColumns = GetNumberOfColumns();

            if (numberOfRows <= 0 || numberOfColumns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов матрицы должно быть > 0.");
            }

            Matrix outputMatrix = new Matrix(numberOfColumns, numberOfRows);

            for (int i = 0; i < numberOfColumns; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    if (i == j)
                    {
                        outputMatrix.array[i].SetComponent(j, array[i].GetComponent(j));
                    }
                    else
                    {
                        outputMatrix.array[i].SetComponent(j, array[j].GetComponent(i));
                    }
                }
            }

            return outputMatrix;
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            int numberOfRows = GetNumberOfRows();
            
            foreach (Vector vector in array)
            {
                vector.MultiplyByScalar(scalar);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{ ");
            int numberOfRows = GetNumberOfRows();
            
            for (int i = 0; i < numberOfRows; i++)
            {
                builder.Append(array[i].ToString());
                    
                if (i != numberOfRows - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.Append(" }").ToString();
        }

        public Vector MultiplyByVector(Vector vector)
        {
            int numberOfRows = GetNumberOfRows();
            int numberOfColumns = GetNumberOfColumns();

            if (numberOfColumns != vector.GetSize())
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть равно размерности вектора.");
            }

            Vector outputVector = new Vector(numberOfRows);

            for (int i = 0; i < numberOfRows; i++)
            {
                double sum = Vector.GetScalarMultiplication(array[i], vector);
                outputVector.SetComponent(i, sum);
            }

            return outputVector;
        }

        public Matrix GetSum(Matrix inputMatrix)
        {
            int numberOfRows = GetNumberOfRows();

            if (numberOfRows != inputMatrix.GetNumberOfRows() || GetNumberOfColumns() != inputMatrix.GetNumberOfColumns())
            {
                throw new ArgumentException("Количество строк и столбцов первой матрицы должно быть равно количеству строк и столбцов второй матрицы.");
            }
                       
            for (int i = 0; i < numberOfRows; i++)
            {
                array[i].GetSum(inputMatrix.array[i]);
            }

            return this;
        }

        public Matrix GetDifference(Matrix inputMatrix)
        {
            int numberOfRows = GetNumberOfRows();

            if (numberOfRows != inputMatrix.GetNumberOfRows() || GetNumberOfColumns() != inputMatrix.GetNumberOfColumns())
            {
                throw new ArgumentException("Количество строк и столбцов первой матрицы должно быть равно количеству строк и столбцов второй матрицы.");
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                array[i].GetDifference(inputMatrix.array[i]);
            }

            return this;
        }

        public double GetDeterminant()
        {
            int numberOfRows = GetNumberOfRows();
            
            if (GetNumberOfColumns() != numberOfRows)
            {
                throw new ArgumentException("Количество строк матрицы должны быть равно количеству столбцов.");
            }

            int tempIndex = 0;
            int numberOfChanges = 0;
            int numberOfStep = 0;

            while (numberOfStep != numberOfRows - 1)
            {
                bool firstIsNull = true;

                for (int i = numberOfStep; i < numberOfRows; i++)
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
                        for (int i = numberOfStep; i < numberOfRows; i++)
                        {
                            double temp = array[tempIndex].GetComponent(i);
                            array[tempIndex].SetComponent(i, array[numberOfStep].GetComponent(i));
                            array[numberOfStep].SetComponent(i, temp);
                        }

                        numberOfChanges++;
                    }

                    for (int i = numberOfStep + 1; i < numberOfRows; i++)
                    {
                        double coefficient = array[i].GetComponent(numberOfStep) / array[numberOfStep].GetComponent(numberOfStep);

                        for (int j = numberOfStep; j < numberOfRows; j++)
                        {
                            array[i].SetComponent(j, array[i].GetComponent(j) - array[numberOfStep].GetComponent(j) * coefficient);
                        }
                    }
                }

                numberOfStep++;
            }

            double det = array[0].GetComponent(0);

            for (int i = 1; i < numberOfRows; i++)
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

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            int numberOfRows = matrix1.GetNumberOfRows();
            int numberOfColumns = matrix2.GetNumberOfColumns();

            if (matrix1.GetNumberOfColumns() != matrix2.GetNumberOfRows())
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }
                        
            Matrix outputMatrix = new Matrix(numberOfRows, numberOfColumns);
            
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    double sum = Vector.GetScalarMultiplication(matrix1.array[i], matrix2.GetColumn(j));
                    outputMatrix.array[i].SetComponent(j, sum);
                }
            }

            return outputMatrix;
        }
    }
}
