using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Finder
{
    public static class FileFinder
    {
        public static void Search(string directory, string startFile, int offset)
        {
            byte[] bStartFile = new byte[16];

            if (File.Exists(startFile))
            {
                using (FileStream fs = File.OpenRead(startFile))
                {
                    UTF8Encoding temp = new UTF8Encoding(true);
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Read(bStartFile, 0, 16);
                }
            }

            Console.WriteLine(bStartFile);

            IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles(directory, "*.txt", SearchOption.AllDirectories);

            List<string> conditionFiles = new List<string>();

            foreach (var file in allFilesInAllFolders)
            {
                using (StreamReader sr = new StreamReader(file.ToString()))
                {
                    string sAnotherFile = sr.ReadToEnd();
                    byte[] bAnotherFile = System.Text.Encoding.UTF8.GetBytes(sAnotherFile);

                    bool flag = false;

                    for (int i = 0; i <= bAnotherFile.Length - bStartFile.Length; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < 16; j++)
                        {
                            if (bAnotherFile[i + j] == bStartFile[j])
                                count++;
                            else
                            {
                                count = 0;
                                break;
                            }
                        }
                        if (count == 16)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine(file.ToString());
                    }
                }
            }
        }
    }
}
