using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace Canvas
{
    class Program
    {
        static void Main(string[] args)
        {



            //1
            //List<int> all = new List<int>() { 111,105,98,99,105,106,85,85,105,107,88,107,80,112,111,125,103,96,136,98,94,89,97,109,101,112,150,104,115,116,109,113,99,113,109,109,86,87,105,96,89,117,102,109,111,103,108,108,111,109,94,145,107,109,98,115,107,104,97,139,116,106,129,106,108,127,117,101,113,139,108,121,103,113,106,108,119,118,127,107,104,109,98,122,119,150,106,93,108,116,118,119,98,107,101,124,125,107,123,117 };
            //List<int> X = all.OrderBy(x => x).GroupBy(x => x).Select(x => x.First()).ToList();
            //List<int> v = all.OrderBy(x => x).GroupBy(x => x).Select(x => x.Count()).ToList();
            //foreach (var elem in all.OrderBy(x => x))
            //    Console.Write($"{elem}, ");
            //Console.WriteLine($"All : {all.Count}");
            //for (int i = 0; i < X.Count; i++)
            //    Console.WriteLine($"{X[i]} - {v[i]}");
            //List<int> all_s = all.OrderBy(x => x).ToList();
            //Console.WriteLine(((double)(all_s[49] + all_s[50]))/2);
        }

    }
}
