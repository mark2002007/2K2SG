using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMLA
{
    public static class LU //==================================================2
    {
        //Helpers


        public static bool IsEqual(double[,] A, double[] b) => MatrixTools.IsEqual(A, MatrixTools.VecToMat(b));

        //LU
        public static (double[,], double[,]) LUdecomp(double[,] A)
        {
            if (A.GetLength(0) != A.GetLength(1)) throw new Exception("WrongSizeException");

            int n = A.GetLength(0);
            double[,] L = new double[n, n];
            double[,] U = new double[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (j >= i)
                        U[i, j] = A[i, j] - Enumerable.Range(0, i).Select(k => L[i, k] * U[k, j]).Sum();
                    else
                        L[i, j] = (A[i, j] - Enumerable.Range(0, i).Select(k => L[i, k] * U[k, j]).Sum()) / U[j, j];
            for (int i = 0; i < n; i++)
                L[i, i] = 1;

            if (Math.Abs(LUdet(U)) < 5 * Math.Pow(10, -10)) throw new Exception("ZeroDetException");

            return (L, U);
        }

        public static double[] SolveWithLU(double[,] L, double[,] U, double[] b)
        {
            double[] Y = new double[b.Length];
            double[] X = new double[Y.Length];
            for (int i = 0; i < Y.Length; i++)
                Y[i] = b[i] - Enumerable.Range(0, i).Select(k => L[i, k] * Y[k]).Sum();
            for (int i = X.Length - 1; i >= 0; i--)
                X[i] = (Y[i] - Enumerable.Range(i + 1, X.Length - i - 1).Select(k => U[i, k] * X[k]).Sum()) / U[i, i];
            return X;
        }

        static double[] SolveWithLU((double[,], double[,]) LU, double[] b) => SolveWithLU(LU.Item1, LU.Item2, b);
        static double LUdet(double[,] U) => Enumerable.Range(0, U.GetLength(0)).Select(i => U[i, i]).Aggregate((x, y) => x * y);
        static double LUdet((double[,], double[,]) LU) => LUdet(LU.Item2);

        //static void Main(string[] args)
        //{
        //    //Input A and b
        //    var ExMat = IOMatrix.InputSquareExtendedMatrix();
        //    double[,] A = ExMat.Item1;
        //    double[] b = ExMat.Item2;
        //    //LU decomposition
        //    var LU = LUdecomp(A);
        //    Console.WriteLine("L : ");
        //    IOMatrix.OutputMatrix(LU.Item1);
        //    Console.WriteLine("U : ");
        //    IOMatrix.OutputMatrix(LU.Item2);
        //    //Det(A) with LU
        //    Console.WriteLine($"Det(A) = Det(L)*Det(U) = {LUdet(LU)}");
        //    //X with LU
        //    Console.WriteLine("X : ");
        //    double[] X = SolveWithLU(LU, b);
        //    IOMatrix.OutputVector(X);
        //    //Checks
        //    Console.WriteLine($"LU = A : {IsEqual(MatrixMult(LU.Item1, LU.Item2), A)}");
        //    Console.WriteLine($"Ax = b : {IsEqual(MatrixMult(A, X), b)}");

        //    Console.ReadKey();
        //}
    }
}
