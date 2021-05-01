using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Transactions;
using Microsoft.VisualBasic.CompilerServices;

namespace NMLA
{
    class Running //==================================================3
    {
        static double[] RunningMethod(double [] A, double[] B, double[] C, double [] F)
        { 
            int n = F.Length;
            if (!(Math.Abs(B[0]) <= Math.Abs(C[0]) &&
                  Math.Abs(A[n-1]) <= Math.Abs(C[n-1]) &&
                  Math.Abs(B[0]) + Math.Abs(A[n-1]) < Math.Abs(C[0]) + Math.Abs(C[n-1])))
                throw new Exception("D is not stable!");

            double [] k = new double[n];
            double [] e = new double[n];
            double [] Y = new double[n];

            n--;
            k[n] = -A[n] / C[n];
            e[n] = F[n] / C[n];
            for (int i = n - 1; i >= 1; i--)
            {
                k[i] = -A[i] / (C[i] + B[i] * k[i + 1]);
                e[i] = (F[i] - B[i] * e[i + 1]) / (C[i] + B[i] * k[i + 1]);
            }
            Y[0] = (F[0] - B[0] * e[1]) / (C[0] + B[0] * k[1]);
            for (int i = 1; i < n + 1; i++)
                Y[i] = k[i]*Y[i - 1] + e[i];
            return Y;
        }

        static double [,] FromDiagToMatrix(double [] A, double [] B, double [] C)
        {
            int n = C.Length;
            double[,] res = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (j == i + 1)
                        res[i, j] = B[i];
                    else if (j == i)
                        res[i, j] = C[i];
                    else if (j == i - 1)
                        res[i, j] = A[i];
            return res;
        }

        //static void Main(string[] args)
        //{
        //    //==========3.1)
        //    //Input
        //    //double[] A, B, C, F;
        //    //using (StreamReader file = new StreamReader(@"C:\Programs\MyPrograms\C#\Canvas (Cshp dnet core)\NMLA\Data\F.txt"))
        //    //{
        //    //    F = file.ReadLine().Split(",").Select(x => double.Parse(x)).ToArray();
        //    //}

        //    //using (StreamReader file = new StreamReader(@"C:\Programs\MyPrograms\C#\Canvas (Cshp dnet core)\NMLA\Data\TridiagonalMatrix.txt"))
        //    //{
        //    //    B = file.ReadLine().Split(',').Select(x => double.Parse(x)).ToArray();
        //    //    C = file.ReadLine().Split(',').Select(x => double.Parse(x)).ToArray();
        //    //    A = file.ReadLine().Split(',').Select(x => double.Parse(x)).Reverse().Append(double.NaN).Reverse()
        //    //        .ToArray();
        //    //}
        //    ////Compute
        //    //var Y = RunningMethod(A, B, C, F);
        //    //double[,] D = FromDiagToMatrix(A, B, C);
        //    ////Output
        //    //Console.WriteLine("D : ");
        //    //IOMatrix.OutputMatrix(D);
        //    //Console.WriteLine("F : ");
        //    //IOMatrix.OutputVector(F);
        //    //Console.WriteLine("Y : ");
        //    //IOMatrix.OutputVector(Y);
        //    //Console.WriteLine($"Dy = F : { MatrixTools.IsEqual(MatrixTools.MatrixMult(D, Y), MatrixTools.VecToMat(F)) }");
        //    //IOMatrix.OutputMatrix(MatrixTools.MatrixMult(D, Y));


        //    //==========3.2)
        //    //Setup
        //    Console.Write("Enter n : ");
        //    int n = int.Parse(Console.ReadLine());
        //    var preset = GetSpecialPreset(n);
        //    double[] A = preset.Item1, B = preset.Item2, C = preset.Item3, F = preset.Item4;
        //    //Compute
        //    var Y = RunningMethod(A, B, C, F);
        //    double[,] D = FromDiagToMatrix(A, B, C);
        //    var Y_ = ComputeY_(n);
        //    //Output
        //    Console.WriteLine("D : ");
        //    IOMatrix.OutputMatrix(D);
        //    Console.WriteLine("F : ");
        //    IOMatrix.OutputVector(F);
        //    Console.WriteLine("Y : ");
        //    IOMatrix.OutputVector(Y);
        //    Console.WriteLine($"Dy = F : { MatrixTools.IsEqual(MatrixTools.MatrixMult(D, Y), MatrixTools.VecToMat(F)) }");
        //    Console.WriteLine($"||y - y*|| = {MatrixTools.SubVecs(Y, Y_).Max()}");

        //    Console.Read();
        //}

        public static (double[], double[], double[], double[]) GetSpecialPreset(int n)
        {

            double[] A = Enumerable.Repeat(1.0, n + 1).ToArray();
            A[n] = 0;

            double[] B = Enumerable.Repeat(1.0, n).ToArray();
            B[0] = 0;

            double h = 1.0 / n;

            double[] C = new double[n + 1];
            C[0] = C[n] = 1;
            for (int i = 1; i < n; i++)
                C[i] = -2 - (1 + i * h) * h * h;

            double[] F = new double[n + 1];
            F[0] = 1;
            F[n] = 3;
            for (int i = 1; i < n; i++)
                F[i] = h * h * (4 - (1 + i * h) * (2 * i * i * h * h + 1));

            return (A, B, C, F);
        }
        static double[] ComputeY_(int n)
        {
            double[] Y_ = new double[n + 1];
            double h = 1.0 / n;
            for (int i = 0; i <= n; i++)
                Y_[i] = 2 * i * i * h * h + 1;
            return Y_;
        }
    }
}
