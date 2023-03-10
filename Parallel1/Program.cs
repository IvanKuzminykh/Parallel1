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
    static double Minor(double[,] a)
    {
        return 0;
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
        double det = 0;

        return det;
    } // ???
    static double[,] InverseMatrix(double[,] a)
    {
        double[,] inversed = new double[a.GetLength(0), a.GetLength(1)];
        double[,] transposed = Transpose(a);

        return inversed;
    } // ???
    static void Main(string[] args)
    {
        double[,] a = { { 1, -2, 5 }, { 3, -1, 0 } };
        double[,] b = { { 5, 6 }, { 1, -4 }, { -2, 1 } };
        double[,] c = MatrixMultiplication(a, b);
        for(int i = 0; i < c.GetLength(0); ++i)
        {
            for(int j = 0; j < c.GetLength(1); ++j)
            {
                Console.Write(c[i, j] + "  ");
            }
            Console.WriteLine();
        }
        Print(Transpose(a));
    }
}