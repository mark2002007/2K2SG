using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Windows;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Canvas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 3};
            int[] arrc = new int[arr.Length];
            Array.Copy(arr,arrc,arr.Length);
            arr[1] = 100;
            Console.WriteLine($"{arr[1]} : {arrc[1]}");
        }
         
    }
}
