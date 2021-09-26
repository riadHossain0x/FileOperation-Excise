using System;
using System.IO;
using System.Linq;

namespace FileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"test.txt";

            // create a file to write to
            //using (StreamWriter writer = File.CreateText(path))
            //{
            //    writer.WriteLine("Hello");
            //    writer.WriteLine("World");
            //}

            // open the file to read from 
            //using (StreamReader reader = File.OpenText(path))
            //{
            //    string s;
            //    while ((s = reader.ReadLine()) != null)
            //    {
            //        //Console.WriteLine(s);
            //    }
            //}

            // direct access to the file
            var read = File.ReadAllLines(path).ToList();
            //read.ForEach(r => Console.WriteLine(r));

            File.WriteAllLines(path, read);

            // File.Move
            //File.Move("test.txt", "text.text");


            // File.Copy
            //File.Copy("text.text", "test.txt");

            //if (!File.Exists("text.text"))
            //    Console.WriteLine("Success");

            // File.AppendAllText

            //File.AppendAllText("test.txt", "This my Append text");

            // File.ReadLines
            //foreach (var line in File.ReadLines(path))
            //{
            //    Console.WriteLine(line);
            //}

            var f = new FileInfo(path);

            Console.WriteLine(f.FullName);
            //Console.WriteLine(f.Name);
            //Console.WriteLine(f.Length);
            //Console.WriteLine(!f.Exists);
            //Console.WriteLine(f.DirectoryName);

            // if file not found or created

            if(!f.Exists)
            {
                Console.WriteLine("File not found thats why creating new one.");
                using (var sw = f.CreateText())
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("World");
                }
            }

            // file already exist? then use AppendText
            using (StreamWriter wr = f.AppendText())
            {
                wr.Write("My new Line");
            }

            using (var rd = f.OpenText())
            {
                string s;
                while ((s = rd.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
