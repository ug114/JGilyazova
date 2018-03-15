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
            rows = new Vector[matrix.rowsNumber];

            for (int i = 0; i < matrix.rowsNumber; i++)
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

        public int rowsNumber
        {
            get
            {
                return rows.Length;
            }
        }

        public int columnsNumber
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
            if (rowNumber < 0 || rowNumber >= rowsNumber)
            {
                throw new ArgumentException("Неверный номер строки.");
            }

            rows[rowNumber] = new Vector(inputVector);
        }

        public Vector GetColumn(int columnNumber)
        {
            Vector column = new Vector(rowsNumber);

            for (int i = 0; i < rowsNumber; i++)
            {
                column.SetComponent(i, rows[i].GetComponent(columnNumber));
            }

            return column;
        }

        public Matrix Transpose()
        {
            Matrix matrix = new Matrix(this);

            if (columnsNumber > rowsNumber)
            {
                Array.Resize(ref rows, columnsNumber);
            }

            if (columnsNumber < rowsNumber)
            {
                Array.Resize(ref rows, columnsNumber);
            }
            
            for (int i = 0; i < rowsNumber; i++)
            {
                SetRow(i, matrix.GetColumn(i));
            }

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

            for (int i = 0; i < rowsNumber; i++)
            {
                builder.Append(rows[i].ToString());

                if (i != rowsNumber - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.Append(" }").ToString();
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (columnsNumber != vector.Length)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть равно размерности вектора.");
            }

            Vector outputVector = new Vector(rowsNumber);

            for (int i = 0; i < rowsNumber; i++)
            {
                double sum = Vector.GetScalarMultiplication(rows[i], vector);
                outputVector.SetComponent(i, sum);
            }

            return outputVector;
        }

        public Matrix GetSum(Matrix inputMatrix)
        {
            if (rowsNumber != inputMatrix.rowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (columnsNumber != inputMatrix.columnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i].GetSum(inputMatrix.rows[i]);
            }

            return this;
        }

        public Matrix GetDifference(Matrix inputMatrix)
        {
            if (rowsNumber != inputMatrix.rowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (columnsNumber != inputMatrix.columnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i].GetDifference(inputMatrix.rows[i]);
            }

            return this;
        }

        public double GetDeterminant()
        {
            if (columnsNumber != rowsNumber)
            {
                throw new ArgumentException("Количество строк матрицы должны быть равно количеству столбцов.");
            }

            int tempIndex = 0;
            int changesNumber = 0;
            int stepNumber = 0;

            while (stepNumber != rowsNumber - 1)
            {
                bool firstIsNull = true;

                for (int i = stepNumber; i < rowsNumber; i++)
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
                        for (int i = stepNumber; i < rowsNumber; i++)
                        {
                            double temp = rows[tempIndex].GetComponent(i);
                            rows[tempIndex].SetComponent(i, rows[stepNumber].GetComponent(i));
                            rows[stepNumber].SetComponent(i, temp);
                        }

                        changesNumber++;
                    }

                    for (int i = stepNumber + 1; i < rowsNumber; i++)
                    {
                        double coefficient = rows[i].GetComponent(stepNumber) / rows[stepNumber].GetComponent(stepNumber);

                        for (int j = stepNumber; j < rowsNumber; j++)
                        {
                            rows[i].SetComponent(j, rows[i].GetComponent(j) - rows[stepNumber].GetComponent(j) * coefficient);
                        }
                    }
                }

                stepNumber++;
            }

            double det = rows[0].GetComponent(0);

            for (int i = 1; i < rowsNumber; i++)
            {
                det *= rows[i].GetComponent(i);
            }

            return det * Math.Pow(-1, changesNumber);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rowsNumber != matrix2.rowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.columnsNumber != matrix2.columnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetSum(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rowsNumber != matrix2.rowsNumber)
            {
                throw new ArgumentException("Количество строк первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            if (matrix1.columnsNumber != matrix2.columnsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству столбцов второй матрицы.");
            }

            return new Matrix(matrix1).GetDifference(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.columnsNumber != matrix2.rowsNumber)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            Matrix outputMatrix = new Matrix(matrix1.rowsNumber, matrix2.columnsNumber);

            for (int i = 0; i < matrix1.rowsNumber; i++)
            {
                for (int j = 0; j < matrix2.columnsNumber; j++)
                {
                    double sum = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));
                    outputMatrix.rows[i].SetComponent(j, sum);
                }
            }

            return outputMatrix;
        }
    }
}
