using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-5.0
            string sourceDirectory = @"C:\Users\Riad\Desktop\file\myDir";
            string path = @"C:\archive";

            //try
            //{
            //    var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
            //    foreach (var current in txtFiles)
            //    {
            //        string fileName = current.Substring(sourceDirectory.Length + 1);
            //        Directory.Move(current, Path.Combine(archiveDirectory, fileName));
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}

            //DirectoryInfo di = Directory.CreateDirectory(sourceDirectory);
            //Console.WriteLine(Directory.GetCreationTime(sourceDirectory));

            // EnumerateDirectory
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

            foreach (var dir in dirs)
            {
                //Console.WriteLine($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
            }
            // LINQ query.
            var Ldirs = from dir in
                     Directory.EnumerateDirectories(sourceDirectory, "dv_*")
                       select dir;

            // GetDirectories
            List<string> xpath =  new List<string>(Directory.GetDirectories(docPath));
            //xpath.ForEach(x => Console.WriteLine(x));

            var GetLdir = from dr in Directory.GetDirectories(docPath) select dr;

            // What is Different Between EnumerateDirectory and GetDirectory

            // GetFiles
            path = @"C:\Users\Riad\Desktop\file\Generics";

            // using Generic List<>
            var csFiles = new List<string>(Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories));

            // Using IEnumerable
            var csfiles2 = from file in Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories) select file;

            // Using Array
            var csfiles3 = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);

            //foreach (var item in csfiles3)
            //{
            //    Console.WriteLine(item);
            //}

            var getSysIO = from file in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories)
                           from line in File.ReadAllLines(file)
                           where line.Contains("System")
                           select new
                           {
                               file,
                               line
                           };
            foreach (var item in getSysIO)
            {
                Console.WriteLine($"{item.file} \n {item.line}");
            }

            var dirNew = new DirectoryInfo(path);
            //Console.WriteLine(dirNew.Root);
        }
    }
}
