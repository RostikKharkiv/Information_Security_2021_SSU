using System;
using System.Diagnostics;

namespace File_Finder
{
    public class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Test";

            string startFile = @"C:\TEST\TestFile.txt";

            Stopwatch st = new Stopwatch();

            st.Start();

            FileFinder.Search(directory, startFile, 6);

            st.Stop();

            Console.WriteLine("Время выполнения: {0}", st.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}
