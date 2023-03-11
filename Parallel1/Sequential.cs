using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel1
{
    internal class Sequential : MatrixProcessing
    {
        public override double[,] Transpose(double[,] a)
        {
            double[,] b = new double[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < b.GetLength(0); ++i)
            {
                for (int j = 0; j < b.GetLength(1); ++j)
                {
                    b[i, j] = a[j, i];
                }

            }
            return b;
        }
        public override double[,]? MatrixMultiplication(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = b.GetLength(1);
            int p = a.GetLength(1);
            if (p != b.GetLength(0)) return null;
            double[,] result = new double[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    double member = 0;
                    for (int k = 0; k < p; ++k)
                    {
                        member += a[i, k] * b[k, j];
                    }
                    result[i, j] = member;
                }
            }
            return result;
        }
        public override double[,] MatrixMultiplication(double[,] a, double k)
        {
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    a[i, j] *= k;
                }
            }
            return a;
        }
    }
}
