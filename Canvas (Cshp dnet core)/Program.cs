using System;
using System.Linq;
using HDF5DotNet;

namespace Canvas__Cshp_dnet_core_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson 28
            // ---
            //Lesson 30
            //int[,] arr1 = new int[3, 5];
            //
            //int[,] arr2 = new int[3, 5]
            //{
            //    {1,2,3,4,5},
            //    {6,7,8,9,10},
            //    {11,12,13,14,15}
            //};
            //int[,] arr3 = new int[,]
            //{
            //    {1,2,3,4,5},
            //    {6,7,8,9,10},
            //    {11,12,13,14,15}
            //};
            //int[,] arr4 = 
            //{
            //    {1,2,3,4,5},
            //    {6,7,8,9,10},
            //    {11,12,13,14,15}
            //};
            //
            //int res1 = arr2.Rank;
            //arr2.GetLength(0);
            //for(int i = 0; i < arr2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr2.GetLength(1); j++)
            //        Console.Write(arr2[i,j] + "\t");
            //    Console.WriteLine();
            //}
            //
            //int[,] arr5 = new int[3, 5];
            //Random rand = new Random();
            //for (int i = 0; i < arr5.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr5.GetLength(1); j++)
            //        arr5[i, j] = rand.Next();
            //}
            //
            // Lesson 33
            //int[][] arr1 = new int[3][];
            //int[,] arr2 = new int[3,5];
            //int r1 = arr1.Rank; //1
            //int r2 = arr2.Rank; //2
            //
            //int l1 = arr1.Length; //3
            //int l2 = arr2.Length; //15
            //
            //Lesson 34
            //
            //Random rand = new Random();
            //int[][][] arr1 = new int[rand.Next(1,5)][][];
            //
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    arr1[i] = new int[rand.Next(1, 5)][];
            //    for (int j = 0; j < arr1[i].Length; j++)
            //    {
            //        arr1[i][j] = new int[rand.Next(1, 5)];
            //        for (int k = 0; k < arr1[i][j].Length; k++)
            //        {
            //            arr1[i][j][k] = rand.Next(0, 10);
            //        }
            //    }
            //}
            //
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    Console.WriteLine("#" + (i + 1) + " :");
            //    for (int j = 0; j < arr1[i].Length; j++)
            //    {
            //        Console.Write("\t");
            //        for (int k = 0; k < arr1[i][j].Length; k++)
            //        {
            //            Console.Write(arr1[i][j][k] + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            //Lesson #38
            /*
             * Stack:
             *  Size = 1Mb
             *  Speed = Fast
             *  Place = RAM
             *  Use = for executing comands and contain pointers
             *  Work principle = LIFO
             * Heap:
             *  Size:
             *   x32 : 1.5Gb
             *   x64 : 8Tb
             *  Speed = Slow
             *  Place = RAM
             *  Use = containt data
             *  Work principle = ---
             *  
             *  F12 - show metadata
             *  
             */

            //Lesson #40( ?? ):

            //string str = null;
            //Console.WriteLine("String lenght : " + (str ?? string.Empty).Length); // верне дожину str якщо str!=null в іншому випадку верне довжину ""

            //Lesson #41 ( ??= ):

            //string str = null;
            //str ??= string.Empty; // Присвоїть в str пусту стоку якщо str == null в іншрму випадку str льшить своє значення

            //Lesson #42 ( ?. )d

            //int[] arr = {1,2,3};

            //Console.WriteLine("Sum : " + arr?.Sum() ); // Виведе суму елементів якщо arr != null в іншому випадку верне null
            //Console.WriteLine("Sum : " + (arr?.Sum()??0)); // Виведе суму елементів якщо arr != null в іншому випадку верне 0

            // Lesson #44 ( out )
            // Out means the same as ref but then some value must be assignet to it's variable but we do not have to assign value before parsing this value in function
            // Also we can type Func( out int a) to create variable and then call function

            // Lesson #50
            // Int smaller than float so implicit conversion is OK
            //int a1 = 5; // -2147483648 < a1 < 2147483647
            //float b1 = a1; // -3.40282347E+38F < b1 < 3.40282347E+38F;
            // Float bigger than int so implicit conversion is not OK
            //float a2 = 5;
            //int b1 = a2;
            // Float bigger than int and we can convert it manually but there is possible loss of data
            //float a3 = 5;
            //int b3 = (int)a3;
            // We can not convert any type to boolean (manually or implicitly)
            //int a4 = 5;
            //bool b4 = a4; // 0 or 1
            // But we can use Convert class for this purpose
            //bool b5 = Convert.ToBoolean(a4);
            // Int converts to float and adds to another float
            //int a6 = 2;
            //float b6 = 3.5f;
            //float c6 = a6 + b6;
            // But float can not be converted to int so there is an exception
            //int d6 = a6 + b6;
            // More examples
            //int e6 = a6 + (int)b6; // OK
            //int f6 = (int)(a6 + b6); // OK

            // Lesson #51
            //int a = int.MaxValue;
            //a = checked(a + 1);
            //checked
            //{
            //    a += 1;
            //}
            //a = unchecked(a + 1);
            //unchecked
            //{
            //    a += 1;
            //}

            //double b = 0.0 / 0.0; // NaN (Not A Number)
            //Console.WriteLine(double.IsNaN(b)); // True
            //double b1 = 1.0 / 0.0; // Infinity
            //Console.WriteLine(double.IsInfinity(b1)); // True
            //double b2 = double.MaxValue + double.MaxValue; // Infinity
            //Console.WriteLine(double.IsInfinity(b2)); // True
            ////The same can be applied for float

            //decimal a = decimal.MaxValue;
            //decimal b = decimal.MaxValue;
            //decimal c = unchecked(a + b); //decimal Overflow always throws an exception

            //Lesson #52
            //string str = null;

            //int? i = null;
            //Console.WriteLine(i == null); //True
            //Console.WriteLine(i.HasValue); //False
            //Console.WriteLine(i.GetValueOrDefault()); //0
            //Console.WriteLine(i.GetValueOrDefault(3)); //3
            //Console.WriteLine(i ?? 55); //55
            //Console.WriteLine(i.Value); //InvalidOperationException
            //Console.WriteLine(i); //- 

            //int? i = 2;
            //Console.WriteLine(i == null); //False
            //Console.WriteLine(i.HasValue); //True
            //Console.WriteLine(i.GetValueOrDefault()); //2
            //Console.WriteLine(i.GetValueOrDefault(3)); //2
            //Console.WriteLine(i ?? 55); //2
            //Console.WriteLine(i.Value); //2
            //Console.WriteLine(i); //2

            //int a = 2;
            //int? b = 3;
            //int? result = a + b; //5
            //Console.WriteLine(result); //5
            //Console.WriteLine(a == b); //false
            //Console.WriteLine(a > b); // false
            //Console.WriteLine(a < b); //true

            //int a = 2;
            //int? b = null;
            //int? result = a + b; //null
            //Console.WriteLine(result); //null
            //Console.WriteLine(a == b); //false
            //Console.WriteLine(a > b); //false
            //Console.WriteLine(a < b); //false

            //var myday = DayOfWeek.Wednesday;
            //Console.WriteLine(Enum.GetUnderlyingType(typeof(DayOfWeek))); //System.Byte
            //Console.WriteLine(myday); // Wednesday
            //Console.WriteLine((int)myday); // 3
            //Console.WriteLine((DayOfWeek)3); // Wednesday
            //Console.WriteLine(GetNextDay(myday)); // Thursday

            //byte from_source = 100;
            //if(Enum.IsDefined(typeof(DayOfWeek), from_source))
            //        myday = (DayOfWeek)from_source;
            //else
            //    Console.WriteLine("Invalid num for day of week");

            //Console.WriteLine();
            //foreach (var elem in Enum.GetValues(typeof(DayOfWeek)))
            //{
            //    Console.WriteLine(elem);
            //}

            //Console.WriteLine((DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine(), ignoreCase: true)); //Parse of Enum
            Console.WriteLine(MyLibraryProj.MyLibraryClass.Add(3,2));
        }
        class Point
        {
            public static int Counter { get; set; }
            public Point() : this(0,0) 
            { 
            }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Counter++;
            }
            public Point(Point p) : this(p.X,p.Y)
            {
            }
            public int X { get; set; }
            public int Y { get; set; }
            public void PrintInfo() { Console.WriteLine($"X : {X}; Y : {Y};"); }

            public int z;
            public static void Foo()
            {
                var p = new Point();
                p.z = 5;
            }
        }
        enum DayOfWeek : byte
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static DayOfWeek GetNextDay(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday) return DayOfWeek.Monday;
            return day + 1;
        }

        public static int DescendingOrder(int num)
        {
            int[] arr = new int[num.ToString().Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = num % 10;
                num /= 10;
            }
            Array.Sort(arr);
            for (int i = 1; i < arr.Length; i++)
                num += arr[i] * (int)Math.Pow(10,i);
            num += arr[0];
            return num;
        }

        static void ParamsTest(params int [] ints)
        {
            //DO SOMETHING
        }
        static void ResizeArr<T>(ref T[] arr, int size)
        {
            T[] new_arr = new T[size];
            if (size > arr.Length)
                size = arr.Length;
            for (int i = 0; i < size; i++)
                new_arr[i] = arr[i];
            arr = new_arr;
        }

        static void Insert<T>(T elem, int index, ref T[] arr)
        {
            ResizeArr(ref arr, arr.Length + 1);

            for (int i = arr.Length - 1; i > index; i--)
                arr[i] = arr[i - 1];
            arr[index] = elem;
        }

        static void Insert<T>(T elem, string index, ref T[] arr)
        {
            if (index == "BEGIN") Insert(elem, 0, ref arr);
            else if(index == "END") Insert(elem, arr.Length, ref arr);
        }

        static void Remove<T>(int index, ref T[] arr)
        {
            T[] new_arr = new T[arr.Length - 1];
            for (int i = 0; i < index; i++)
                new_arr[i] = arr[i];
            for (int i = index; i < new_arr.Length; i++)
                new_arr[i] = arr[i + 1];
            arr = new_arr;
        }

        static void Remove<T>(string index, ref T[] arr)
        {
            if (index == "BEGIN") Remove(0, ref arr);
            else if (index == "END") Remove(arr.Length - 1, ref arr);
        }

        static int[] RandArr(uint size, int start, int stop)
        {
            int[] arr = new int [size];
            Random rand = new Random();
            for (int i = 0; i < size; i++) arr[i] = rand.Next(start, stop);
            return arr;
        }
    }
}
