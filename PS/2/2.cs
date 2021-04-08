using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PS
{

    //==================================================2
    class _2
    {
        static int[][][] Extend(int[][][] arr)
        {
            int[][][] res = new int[arr.Length + 1][][];
            for (int i = 0; i < arr.Length; i++) res[i] = arr[i];
            return res;
        }

        static int[][] Extend(int[][] arr)
        {
            int[][] res = new int[arr.Length + 1][];
            for (int i = 0; i < arr.Length; i++) res[i] = arr[i];
            return res;
        }

        static int[][][] Read3DArrayFromTxt(string src)
        {
            if (File.Exists(src) && File.ReadAllText(src) != "")
            {
                StreamReader file = new StreamReader(src);
                string line;
                int[] t;
                int[][][] res = new int[0][][];
                bool EOF = false;

                for (int i = 0; !EOF; i++)
                {
                    res = Extend(res);
                    for (int j = 0; ; j++)
                    {
                        line = file.ReadLine();
                        if (line == null)
                        {
                            EOF = true;
                            break;
                        }
                        else if (line != "")
                        {

                            if (j == 0) res[i] = new int[1][];
                            else res[i] = Extend(res[i]);

                            res[i][j] = line.Split(",").Select(x => int.Parse(x)).ToArray();
                        }
                        else break;
                    }
                }

                return res;
            }
            else return null;
        }

        //static void ConsoleOutJaggled3DArray(int[][][] arr)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        for (int j = 0; j < arr[i].Length; j++)
        //        {
        //            for (int k = 0; k < arr[i][j].Length; k++)
        //                Console.Write($"{arr[i][j][k]} ");
        //            Console.WriteLine();
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //static void ConsoleOut3DArray(int[,,] arr)
        //{
        //    for (int i = 0; i < arr.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < arr.GetLength(1); j++)
        //        {
        //            for (int k = 0; k < arr.GetLength(2); k++)
        //                Console.Write($"{arr[i,j,k]} ");
        //            Console.WriteLine();
        //        }
        //        Console.WriteLine();
        //    }
        //}


        static int[,,] FromJeggedToRect(int[][][] arr)
        {
            int[,,] res = new int[arr.Length, arr[0].Length, arr[0][0].Length];
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr[i].Length; j++)
                    for (int k = 0; k < arr[i][j].Length; k++)
                        res[i, j, k] = arr[i][j][k];
            return res;
        }

        static int[,,] Format3DArrForHDF(int[,,] arr)
        {
            int[,,] res = new int[arr.GetLength(0), arr.GetLength(1), arr.GetLength(2)];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    for (int k = 0; k < arr.GetLength(2); k++)
                        res[i, j, k] = arr[k, i, j];
            return res;
        }

        //static double InnerProduct(int[][][] A, int[][][] B) 
        //    => Enumerable.Range(0, A.Length)
        //    .Select(i => Enumerable.Range(0, A[i].Length)
        //    .Select(j => Enumerable.Range(0, A[i][j].Length)
        //    .Select(k => (double)(A[i][j][k] * B[i][j][k]))
        //    .Sum()).Sum()).Sum();

        //static double InnerProduct(int[,,] A, int[,,] B) => Enumerable.Range(0, A.GetLength(0))
        //    .Select(i => Enumerable.Range(0, A.GetLength(1))
        //    .Select(j => Enumerable.Range(0, A.GetLength(2))
        //    .Select(k => (double)(A[i,j,k] * B[i,j,k]))
        //    .Sum()).Sum()).Sum();
    }
}
