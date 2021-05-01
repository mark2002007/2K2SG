using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMLA
{
    class IterativeProcess
    {
        static (double[], double, int) JacobiMethod(double[,] A, double[] b, double e, int max_k = -1)
        {
            double step = 0;
            double [] x = new double [b.Length], _x = new double[b.Length];
            for (int k = 1;; k++)
            {
                for (int n = 0; n < x.Length; n++)
                    x[n] = _x[n];
                x
                for (int i = 0; i < b.Length; i++)
                    _x[i] = -(Enumerable.Range(0, x.Length).Where(j => j != i).Select(j => A[i, j] * x[j]).Sum() - b[i])/A[i,i];

                step = MatrixTools.SubVecs(_x, x).Select(x => Math.Abs(x)).Max();
                if (step < e || k == max_k + 1)
                {
                    double r = MatrixTools.SubVecs(MatrixTools.MatToVec(MatrixTools.MatrixMult(A, _x)), b).Select(x => Math.Abs(x)).Max();
                    return (_x, r, k);
                }
            }
        }
         
        static void Main(string[] args)
        {
            //Input
            var ExMat = IOMatrix.InputSquareExtendedMatrix();
            double[,] A = ExMat.Item1;
            double[] b = ExMat.Item2;
            //Console.Write("Enter ε : ");
            //double e = double.Parse(Console.ReadLine());
            Console.Write("Enter n (ε = 10^(-n)) : ");
            double e = Math.Pow(10,-double.Parse(Console.ReadLine()));
            
            Console.Clear();
            Console.WriteLine("Enter k_max (-1 for infinity) : ");
            double k_max = int.Parse(Console.ReadLine());
            Console.Clear();

            //Compute
            var res = JacobiMethod(A,b,Math.Pow(10,-300));

            //Output
            Console.WriteLine("A : ");
            IOMatrix.OutputMatrix(A);
            Console.WriteLine("b : ");
            IOMatrix.OutputVector(b);
            Console.WriteLine("x^(k+1) : ");
            IOMatrix.OutputVector(res.Item1);
            Console.WriteLine($"\n||Ax^(k+1) - b|| : {res.Item2}");
            Console.WriteLine($"\nk + 1 : {res.Item3}");

            Console.ReadKey();
        }
    }
}
