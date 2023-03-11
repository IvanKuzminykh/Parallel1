namespace Parallel1
{
    internal abstract class MatrixProcessing
    {
        public double Determinant(double[,] a)
        {
            if (a.GetLength(0) != a.GetLength(1)) throw new ArgumentException();
            if (a.GetLength(0) == 2) return a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            double det = 0;
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                det += Math.Pow(-1, i) * a[0, i] * Determinant(SubMatrix(a, 0, i));
            }
            return det;
        }
        public double[,]? InverseMatrix(double[,] a)
        {
            if (a.GetLength(0) != a.GetLength(1)) return null;
            double det = Determinant(a);
            double[,] inversed = new double[a.GetLength(0), a.GetLength(1)];
            double[,] transposed = Transpose(a);
            for (int i = 0; i < inversed.GetLength(0); ++i)
            {
                for (int j = 0; j < inversed.GetLength(1); ++j)
                {
                    inversed[i, j] = Math.Pow(-1, i + j) * Minor(transposed, i, j);
                }
            }
            inversed = MatrixMultiplication(inversed, 1.0 / det);
            return inversed;
        }

        public abstract double[,] MatrixMultiplication(double[,] a, double k);
        public abstract double[,]? MatrixMultiplication(double[,] a, double[,] b);
        public abstract double[,] Transpose(double[,] a);

        public void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        double Minor(double[,] a, int row, int column)
        {
            return Determinant(SubMatrix(a, row, column));
        }
        double[,] SubMatrix(double[,] matrix, int row, int column)
        {
            double[,] subMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int currentRow = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int currentColumn = 0;
                if (i == row) continue;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (j == column) continue;
                    subMatrix[currentRow, currentColumn] = matrix[i, j];
                    currentColumn++;
                }
                currentRow++;
            }
            return subMatrix;
        }
    }
}