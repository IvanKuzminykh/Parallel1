using System.Data.Common;
using System.Threading;
class Program
{
    static void Print(double[,] a)
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
    static double[,] SubMatrix(double[,] matrix, int row, int column)
    {
        double[,] subMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        int currentRow = 0;
        for(int i = 0; i < matrix.GetLength(0); ++i)
        {
            int currentColumn = 0;
            if (i == row) continue;
            for(int j = 0; j <  matrix.GetLength(1); ++j)
            {
                if(j == column) continue;
                subMatrix[currentRow, currentColumn] = matrix[i,j];
                currentColumn++;
            }
            currentRow++;
        }
        return subMatrix;
    }
    static double Minor(double[,] a, int row, int column)
    {
        return Determinant(SubMatrix(a, row, column));
    }
    static double[,]? MatrixMultiplication(double[,] a, double[,] b)
    {
        int n = a.GetLength(0);
        int m = b.GetLength(1);
        int p = a.GetLength(1);
        if (p != b.GetLength(0)) return null;
        double[,] result = new double[n, m];
        for (int i = 0; i < n; ++i)
        {
            for(int j = 0; j <m; ++j)
            {
                double member = 0;
                for(int k = 0; k < p; ++k)
                {
                    member += a[i, k] * b[k, j];
                }
                result[i, j] = member;
            }
        }
        return result;
    }
    static double[,] MatrixMultiplication(double[,] a, double k)
    {
        for(int i = 0; i < a.GetLength(0); ++i)
        {
            for(int j = 0; j < a.GetLength(1); ++j)
            {
                a[i, j] *= k;
            }
        }
        return a;
    }
    static double[,] Transpose(double[,] a)
    {
        double[,] b = new double[a.GetLength(1), a.GetLength(0)];
        for(int i = 0; i < b.GetLength(0); ++i)
        {
            for (int j = 0; j < b.GetLength(1); ++j)
            {
                b[i, j] = a[j, i];
            }

        }
        return b;
    }
    static double Determinant(double[,] a)
    {
        if (a.GetLength(0) != a.GetLength(1)) throw new ArgumentException();
        if(a.GetLength(0) == 2) return a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
        double det = 0;
        for(int i = 0; i < a.GetLength(0); ++i)
        {
            det += Math.Pow(-1, i) * a[0, i] * Determinant(SubMatrix(a, 0, i));
        }
        return det;
    }
    static double[,]? InverseMatrix(double[,] a)
    {
        if (a.GetLength(0) != a.GetLength(1)) return null;
        double det = Determinant(a);
        double[,] inversed = new double[a.GetLength(0), a.GetLength(1)];
        double[,] transposed = Transpose(a);
        for(int i = 0; i < inversed.GetLength(0); ++i)
        {
            for(int j = 0; j <  inversed.GetLength(1); ++j)
            {
                inversed[i, j] = Math.Pow(-1, i + j) * Minor(transposed, i, j);
            }
        }
        inversed = MatrixMultiplication(inversed, 1.0 / det);
        return inversed;
    } // ???



    static void Main(string[] args)
    {
        double[,] a = { { 1, -2, 5 }, { 3, -1, 0 }, { 2, 1, 3} };
        double[,] b = { { 5, 6 }, { 1, -4 }, { -2, 1 } };
        double[,] c = MatrixMultiplication(a, b);
        double[,] invA = InverseMatrix(a);
        Print(MatrixMultiplication(a, invA));
    }
}