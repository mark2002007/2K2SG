using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMLA
{
    //==================================================1
    class GaußClass
    {
        static double[] DeepCopy1D(double[] arr) => Enumerable.Range(0, arr.Length).Select(i => arr[i]).ToArray();

        static double[,] DeepCopy2D(double[,] arr)
        {
            double[,] arr_c = new double[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(1); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr_c[i, j] = arr[i, j];
            return arr_c;
        }

        static double[] Gauß(double[,] A, double[] b)
        {
            double[] X = new double[b.Length];
            int n = (int)Math.Sqrt(A.Length);
            for (int k = 1; k < n; k++)
            {
                //Вибір головного елемента
                int ind = 0;
                double max = 0;
                for (int i = k; i <= n; i++)
                    if (Math.Abs(A[i - 1, k - 1]) > Math.Abs(max))
                    {
                        max = A[i - 1, k - 1];
                        ind = i - 1;
                    }

                double[] t = new double[n];
                for (int i = 0; i < n; i++) t[i] = A[k - 1, i];
                for (int i = 0; i < n; i++) A[k - 1, i] = A[ind, i];
                for (int i = 0; i < n; i++) A[ind, i] = t[i];

                double t_num = b[k - 1];
                b[k - 1] = b[ind];
                b[ind] = t_num;
                //Обчислення рядків
                for (int i = k + 1; i <= n; i++)
                {
                    double m = -1 * A[i - 1, k - 1] / A[k - 1, k - 1];
                    b[i - 1] = b[i - 1] + m * b[k - 1];
                    for (int j = k + 1; j <= n; j++)
                        A[i - 1, j - 1] = A[i - 1, j - 1] + m * A[k - 1, j - 1];
                }
            }

            //Розрахунок x[n]
            X[n - 1] = b[n - 1] / A[n - 1, n - 1];
            //Розрахунок x[n-1] ... x[1]
            for (int k = n - 1; k >= 1; k--) //Мат. сума
                X[k - 1] = (b[k - 1] - Enumerable.Range(k + 1, n - k).Select(j => A[k - 1, j - 1] * X[j - 1]).Sum()) / A[k - 1, k - 1];


            return X.Any(x => double.IsInfinity(x)) ? null : X;
        }

        public static double GaußDet(double[,] A)
        {
            int swaps = 0;
            int n = (int)Math.Sqrt(A.Length);
            for (int k = 1; k < n; k++)
            {
                //Вибір головного елемента
                int ind = 0;
                double max = 0;
                for (int i = k; i <= n; i++)
                    if (Math.Abs(A[i - 1, k - 1]) > Math.Abs(max))
                    {
                        max = A[i - 1, k - 1];
                        ind = i - 1;
                    }

                if (max != A[k - 1, k - 1]) swaps++;

                double[] t = new double[n];
                for (int i = 0; i < n; i++) t[i] = A[k - 1, i];
                for (int i = 0; i < n; i++) A[k - 1, i] = A[ind, i];
                for (int i = 0; i < n; i++) A[ind, i] = t[i];
                //Обчислення рядків
                for (int i = k + 1; i <= n; i++)
                {
                    double m = -1 * A[i - 1, k - 1] / A[k - 1, k - 1];
                    for (int j = k + 1; j <= n; j++)
                        A[i - 1, j - 1] = A[i - 1, j - 1] + m * A[k - 1, j - 1];
                }
            }

            return Math.Pow(-1, swaps) * Enumerable.Range(0, n).Select(i => A[i, i]).Aggregate(1.0, (x, y) => x * y);
        }

        static bool LES_Solution_Check(double[,] A, double[] b, double[] X)
        {
            int n = (int)Math.Sqrt(A.Length);
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++) sum += A[i, j] * X[j];
                if (sum != b[i]) return false;
            }
            return true;
        }
    }
}
