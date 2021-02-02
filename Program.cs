using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Users\Md Sadman Chowdhury\source\repos\BookmarkOrganizer\Data\Source";
            string archiveDirectory = @"C:\Users\Md Sadman Chowdhury\source\repos\BookmarkOrganizer\Data\Archive\";

            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
                int x = 1;
                foreach (string currentFile in txtFiles)
                {
                    string text = System.IO.File.ReadAllText(@currentFile);
                    string[] fileNames = currentFile.Split('\\');
                    string fileName = fileNames[fileNames.Length - 1];
                    string names = "";
                    string values = "";
                    
                    string[] subs = text.Split('\n');
                    for (int y = 0; y < subs.Length; y++)
                    {
                        if (y == 0 || y % 2 == 0)
                        {
                            names += subs[y];
                            if (y + 2 < subs.Length)
                            {
                                names += '\n';
                            }
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

                    System.IO.File.WriteAllText(archiveDirectory + fileName.Substring(0, fileName.Length - 4) + "name.txt", names);
                    System.IO.File.WriteAllText(archiveDirectory + fileName.Substring(0, fileName.Length - 4) + "value.txt", values);

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
