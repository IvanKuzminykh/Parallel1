using System.Data.Common;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {

        double[,] a = { { 1, -2, 5 }, { 3, -1, 0 }, { 2, 1, 3} };
        double[,] b = { { 5, 6 }, { 1, -4 }, { -2, 1 } };
        double[,] c = MatrixMultiplication(a, b);
        double[,] invA = InverseMatrix(a);
        Print(MatrixMultiplication(a, invA));
    }
}