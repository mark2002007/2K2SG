using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace NMLA
{
    public class IOMatrix
    {
        //==========Helpers
        static int LongestElem(string[,] A)
        {
            int max_l = 0;
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    if (A[i, j].ToString().Length > max_l)
                        max_l = A[i, j].Length;
            return max_l;
        }
        //==========Vectors
        public static void OutputVector(string[] b)
        {
            string[,] A = new string[b.Length, 1];
            for (int i = 0; i < A.GetLength(0); i++) A[i, 0] = b[i];
            OutputMatrix(A);
        }

        public static void OutputVector(double[] b)
        {
            string[] b_str = new string[b.Length];
            for (int i = 0; i < b_str.Length; i++) b_str[i] = b[i].ToString();
            OutputVector(b_str);
        }

        public static double[] InputVector(int n = 0, string label = null)
        {
            if (n == 0)
            {
                Console.Write("Enter vector lenght : ");
                n = int.Parse(Console.ReadLine());
            }
            double[,] A = InputMatrix(n, 1, label);
            double[] b = new double[n];
            for (int i = 0; i < n; i++) b[i] = A[i, 0];
            return b;
        }
        //==========Matrix
        //TODO : fix alignment
        public static void OutputMatrix(string[,] A)
        {
            int max_l = LongestElem(A);
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (j == 0) Console.Write("|");
                    Console.Write($"\t{A[i, j]}");
                }
                Console.WriteLine("\t|");
            }
        }

        public static void OutputMatrix(double[,] A)
        {
            string[,] A_str = new string[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    A_str[i, j] = A[i, j].ToString();
            OutputMatrix(A_str);
        }

        static double[,] InputMatrix(int n, int m, string label = null)
        {
            string[,] A_str = new string[n, m];
            double[,] A = new double[n, m];
            for (int i = 0; i < n; i++) for (int j = 0; j < m; j++) A_str[i, j] = "#";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Clear();
                    if (label is object) Console.WriteLine(label);
                    A_str[i, j] = "*";
                    OutputMatrix(A_str);
                    Console.Write("Element : ");
                    try
                    {

                        A_str[i, j] = Console.ReadLine();
                        A[i, j] = double.Parse(A_str[i, j]);
                    }
                    catch
                    {
                        j--;
                    }
                }
            }
            Console.Clear();
            return A;
        }

        public static double[,] InputSquareMatrix(int n = 0, string label = null)
        {
            if (n == 0)
            {
                Console.Write("Enter matrix rank : ");
                n = int.Parse(Console.ReadLine());
            }
            return InputMatrix(n, n, label);
        }
        //==========ExtendedMatrix
        public static (double[,], double[]) InputSquareExtendedMatrix(int n = 0)
        {
            if (n == 0)
            {
                Console.Write("Enter matrix rank : ");
                n = int.Parse(Console.ReadLine());
            }
            return (InputMatrix(n, n), InputVector(n));
        }

    }
}
