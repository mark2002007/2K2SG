using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NMLA
{
    public class MatrixTools
    {
        public static double[] AddVecs(double[] a, double[] b) =>
            Enumerable.Range(0, Math.Min(a.Length, b.Length)).Select(x => a[x] + b[x]).ToArray();
        public static double[] SubVecs(double[] a, double[] b) =>
            Enumerable.Range(0, Math.Min(a.Length,b.Length)).Select(x => a[x] - b[x]).ToArray();

        
        public static double[,] VecToMat(double[] v)
        {
            double[,] V = new double[v.Length, 1];
            for (int i = 0; i < v.Length; i++)
                V[i, 0] = v[i];
            return V;
        }

        public static double[] MatToVec(double[,] V)
        {
            double[] v = new double[V.GetLength(0)];
            for (int i = 0; i < V.GetLength(0); i++)
                v[i] = V[i,0];
            return v;
        }

        public static double[,] MatrixMult(double[,] A, double[,] B)
        {
            double[,] R = new double[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < R.GetLength(0); i++)
            for (int j = 0; j < R.GetLength(1); j++)
                R[i, j] = Enumerable.Range(0, A.GetLength(1)).Select(k => A[i, k] * B[k, j]).Sum();
            return R;
        }
        public static double[,] MatrixMult(double[,] A, double[] B) => MatrixMult(A, VecToMat(B));

        public static double[,] VecMult(double[] A, double[] B) => MatrixMult(VecToMat(A), VecToMat(B));

        public static bool IsEqual(double[,] A, double[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) ||
                B.GetLength(1) != B.GetLength(1))
                return false;
            for (int i = 0; i < A.GetLength(0); i++)
            for (int j = 0; j < A.GetLength(1); j++)
                if (A[i, j] != B[i, j])
                    return false;
            return true;
        }

        public static bool IsEqual(double[] A, double[] B) => IsEqual(VecToMat(A), VecToMat(B));

    }
}
