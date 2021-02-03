using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookmarkOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Users\Md Sadman Chowdhury\source\repos\BookmarkOrganizer\Data\Source\";
            String[] files =  Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories);

            try
            {
                int x = 1;
                foreach (string currentFile in files)
                {
                    string text = System.IO.File.ReadAllText(@currentFile);
                    string[] fileNames = currentFile.Split('\\');
                    string fileName = fileNames[fileNames.Length - 1];
                    string values = "";

                    string[] subs = text.Split('\n');
                    for (int y = 0; y < subs.Length; y++)
                    {
                        if (y == 0 || y % 2 == 0)
                        {

                        }
                        else
                        {
                            values += subs[y];
                            if (y + 2 < subs.Length)
                            {
                                values += '\n';
                            }
                        }
                    }

                    System.IO.File.WriteAllText(@currentFile, values);

                    x++;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
