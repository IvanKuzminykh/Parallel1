using Parallel1;
using System.Data.Common;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Sequential seq = new Sequential();
        double[,] a = { { 1, -2, 5 }, { 3, -1, 0 }, { 2, 1, 3} };
        double[,] b = { { 5, 6 }, { 1, -4 }, { -2, 1 } };
        double[,] c = seq.MatrixMultiplication(a, b);
        double[,] invA = seq.InverseMatrix(a);
        seq.Print(seq.MatrixMultiplication(a, invA));
        seq.Print(c);
    }
}