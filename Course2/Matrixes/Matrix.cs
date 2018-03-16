using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] rows;

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

            rows = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                rows[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.RowsNumber];

            for (int i = 0; i < matrix.RowsNumber; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int rowsNumber = array.GetLength(0);
            int columnsNumber = array.GetLength(1);

            if (rowsNumber <= 0)
            {
                throw new ArgumentException("Количество строк матрицы должно быть > 0.");
            }

            if (columnsNumber <= 0)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть > 0.");
            }

            rows = new Vector[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i] = new Vector(columnsNumber);

                for (int j = 0; j < columnsNumber; j++)
                {
                    rows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] array)
        {
            int rowsNumber = array.GetLength(0);

            if (rowsNumber <= 0)
            {
                throw new ArgumentException("Количество элементов массива должно быть > 0.");
            }

            int columnsNumber = array[0].Length;

            if (columnsNumber <= 0)
            {
                throw new ArgumentException("Размерность векторов должна быть > 0.");
            }

            for (int i = 0; i < rowsNumber; i++)
            {
                if (columnsNumber < array[i].Length)
                {
                    columnsNumber = array[i].Length;
                }
            }

            rows = new Vector[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i] = new Vector(columnsNumber);

                for (int j = 0; j < array[i].Length; j++)
                {
                    rows[i].SetComponent(j, array[i].GetComponent(j));
                }
            }
        }

        public int RowsNumber
        {
            get
            {
                return rows.Length;
            }
        }

        public int ColumnsNumber
        {
            get
            {
                return rows[0].Length;
            }
        }

        public Vector GetRow(int rowNumber)
        {
            return new Vector(rows[rowNumber]);
        }

        public void SetRow(int rowNumber, Vector inputVector)
        {
            if (rowNumber < 0 || rowNumber >= RowsNumber)
            {
                throw new ArgumentException("Неверный номер строки.");
            }

            rows[rowNumber] = new Vector(inputVector);
        }

        public Vector GetColumn(int columnNumber)
        {
            Vector column = new Vector(RowsNumber);

            for (int i = 0; i < RowsNumber; i++)
            {
                column.SetComponent(i, rows[i].GetComponent(columnNumber));
            }

            return column;
        }

        public Matrix Transpose()
        {
            Vector[] array = new Vector[ColumnsNumber];
            
            for (int i = 0; i < ColumnsNumber; i++)
            {
                array[i] = GetColumn(i);
            }

            rows = array;

            return this;
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(scalar);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("{ ");

            for (int i = 0; i < RowsNumber; i++)
            {
                builder.Append(rows[i].ToString());

                if (i != RowsNumber - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.Append(" }").ToString();
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (ColumnsNumber != vector.Length)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть равно размерности вектора.");
            }

            Vector outputVector = new Vector(RowsNumber);

            for (int i = 0; i < RowsNumber; i++)
            {
                double sum = Vector.GetScalarMultiplication(rows[i], vector);
                outputVector.SetComponent(i, sum);
            }

            return outputVector;
        }

        public Matrix GetSum(Matrix inputMatrix)
        {
            if (RowsNumber != inputMatrix.RowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (ColumnsNumber != inputMatrix.ColumnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < RowsNumber; i++)
            {
                rows[i].GetSum(inputMatrix.rows[i]);
            }

            return this;
        }

        public Matrix GetDifference(Matrix inputMatrix)
        {
            if (RowsNumber != inputMatrix.RowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (ColumnsNumber != inputMatrix.ColumnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < RowsNumber; i++)
            {
                rows[i].GetDifference(inputMatrix.rows[i]);
            }

            return this;
        }

        public double GetDeterminant()
        {
            if (ColumnsNumber != RowsNumber)
            {
                throw new ArgumentException("Количество строк матрицы должны быть равно количеству столбцов.");
            }

            int tempIndex = 0;
            int changesNumber = 0;
            int stepNumber = 0;

            while (stepNumber != RowsNumber - 1)
            {
                bool firstIsNull = true;

                for (int i = stepNumber; i < RowsNumber; i++)
                {
                    if (rows[i].GetComponent(stepNumber) != 0)
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
                    if (tempIndex != stepNumber)
                    {
                        for (int i = stepNumber; i < RowsNumber; i++)
                        {
                            double temp = rows[tempIndex].GetComponent(i);
                            rows[tempIndex].SetComponent(i, rows[stepNumber].GetComponent(i));
                            rows[stepNumber].SetComponent(i, temp);
                        }

                        changesNumber++;
                    }

                    for (int i = stepNumber + 1; i < RowsNumber; i++)
                    {
                        double coefficient = rows[i].GetComponent(stepNumber) / rows[stepNumber].GetComponent(stepNumber);

                        for (int j = stepNumber; j < RowsNumber; j++)
                        {
                            rows[i].SetComponent(j, rows[i].GetComponent(j) - rows[stepNumber].GetComponent(j) * coefficient);
                        }
                    }
                }

                stepNumber++;
            }

            double det = rows[0].GetComponent(0);

            for (int i = 1; i < RowsNumber; i++)
            {
                det *= rows[i].GetComponent(i);
            }

            return det * Math.Pow(-1, changesNumber);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsNumber != matrix2.RowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.ColumnsNumber != matrix2.ColumnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetSum(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsNumber != matrix2.RowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.ColumnsNumber != matrix2.ColumnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetDifference(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsNumber != matrix2.RowsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            Matrix outputMatrix = new Matrix(matrix1.RowsNumber, matrix2.ColumnsNumber);

            for (int i = 0; i < matrix1.RowsNumber; i++)
            {
                for (int j = 0; j < matrix2.ColumnsNumber; j++)
                {
                    double sum = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));
                    outputMatrix.rows[i].SetComponent(j, sum);
                }
            }

            return outputMatrix;
        }
    }
}
