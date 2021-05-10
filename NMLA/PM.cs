using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace NMLA
{
    class PM
    {
        static (int, double, double[]) PM_Method (double [,] A, double [] y, double [] l, double delta, double eps)
        {
            double ynorm = Math.Sqrt(Enumerable.Range(0, y.Length).Select(i => Math.Pow(y[i], 2)).Sum()); // ||y^(i)||
            double [] x = Enumerable.Range(0,y.Length).Select(i => y[i]/ynorm).ToArray(); //x^(0) and x^(k) 
            int[] S = Enumerable.Range(0, x.Length).Where(i => Math.Abs(x[i]) > delta).ToArray(); //S^(0) and S^(k)
            double[] x_ = new double[x.Length]; //x^(k-1)
            int[] S_ = new int[S.Length]; //S^(k-1)
            double[] l_ = new double[l.Length]; //λ^(0) and λ^(k)
            for (int k = 1;;k++)
            {
                Array.Copy(x, x_, x.Length); //x^(k) -> x^(k-1)
                Array.Copy(S, S_, S.Length); //S^(k) -> S^(k-1)
                Array.Copy(l, l_, l.Length); //λ^(k) -> λ^(k-1)
                y = MatrixTools.MatToVec(MatrixTools.MatrixMult(A, x_));
                l = Enumerable.Range(0, l.Length).Select(i => S_.Contains(i) ? y[i] / x_[i] : 0).ToArray();
                ynorm = Math.Sqrt(Enumerable.Range(0, y.Length).Select(i => Math.Pow(y[i], 2)).Sum());
                x = Enumerable.Range(0, x.Length).Select(i => y[i] / ynorm).ToArray();
                S = Enumerable.Range(0, S.Length).Where(i => Math.Abs(x[i]) > delta).ToArray();
                if (S_.All(i => Math.Abs(l[i] - l_[i]) <= eps) || MatrixTools.SubVecs(x,x_).Max() <= eps)
                    return (k, S_.Select(i => l[i]).Sum() / S_.Length, x);
            }
        }

        static void Main(string[] args)
        {
            //Inpute
            Console.Write("n : "); int n = int.Parse(Console.ReadLine());
            Console.Write("Enter n (δ = 10^(-n)) : "); double delta = Math.Pow(10, -double.Parse(Console.ReadLine()));
            //Console.Write("Enter δ : "); double delta = double.Parse(Console.ReadLine());
            Console.Write("Enter n (ε = 10^(-n)) : "); double eps = Math.Pow(10, -double.Parse(Console.ReadLine()));
            //Console.Write("Enter ε : "); double eps = double.Parse(Console.ReadLine());
            double[,] A = IOMatrix.InputSquareMatrix(n,"A");
            double[] y0 = IOMatrix.InputVector(n,"y_0");
            double[] l0 = IOMatrix.InputVector(n,"l_0");
            
            //Compute
            var res = PM_Method(A, y0, l0, delta, eps);

            //Output
            Console.WriteLine($"k : {res.Item1}");
            Console.WriteLine($"l_1 : {res.Item2}");
            Console.WriteLine("x^(k) : ");
            IOMatrix.OutputVector(res.Item3);

            Console.WriteLine(new string('-', 60));

            Console.WriteLine($"Ax : ");
            IOMatrix.OutputVector(MatrixTools.MatToVec(MatrixTools.MatrixMult(A, res.Item3)));
            Console.WriteLine($"lx : ");
            IOMatrix.OutputVector(res.Item3.Select(e => e * res.Item2).ToArray());

            Console.WriteLine(new string('-',60));

            Console.WriteLine("A : ");
            IOMatrix.OutputMatrix(A);
            Console.WriteLine("y_0 : ");
            IOMatrix.OutputVector(y0);
            Console.WriteLine("l_0 : ");
            IOMatrix.OutputVector(l0);
            Console.WriteLine($"δ : {eps}");
            Console.WriteLine($"ε : {eps}");
            
        }
    }
}
