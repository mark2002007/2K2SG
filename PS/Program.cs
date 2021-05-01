using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using HDF5DotNet;
using PS._3.Menu;

namespace PS
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Programs\MyPrograms\C#\Canvas (Cshp dnet core)\PS\3\Data\test.dat";
            //string line = string.Empty;
            //using (BinaryWriter file = new BinaryWriter(File.Open(path, FileMode.Create)))
            //{
            //    file.Write("Hello,");
            //    file.Write(" World!");
            //}
            //using (BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open)))
            //{
            //    while (file.PeekChar() != -1)
            //    {
            //        Console.WriteLine(file.ReadString());
            //    }
            //}
            //Console.WriteLine(line);
            Menu m = new Menu(PlaylistTypes.Bin);
            m.ShowMenu();
        }
    }
}
