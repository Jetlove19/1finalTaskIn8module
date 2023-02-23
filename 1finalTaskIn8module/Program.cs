using System;
using System.IO;

namespace _1finalTaskIn8module
{
    class Program
    {
        static void Main(string[] args)
        {
            ClearDirFiles();
            
        }

       static void ClearDirFiles()
        {
            string path = @"\Users\Jetlove\Desktop\DeleteFiles30";
            var DelFailDir = new DirectoryInfo(path);

            if (DelFailDir.Exists)
            {
                Console.WriteLine("Папка существует");
                Console.WriteLine("Папки:");

                string[] dirs = Directory.GetDirectories(path);
                foreach (var item in dirs)
                {
                    Console.WriteLine("{0}", item);
                }
                Console.WriteLine("Файлы:");

                string[] files = Directory.GetFiles(path);
                foreach (var item in files)
                {
                    Console.WriteLine(item);
                }

                foreach (FileInfo file in DelFailDir.GetFiles())
                {
                    var timeSpan = file.LastAccessTime;
                    var timeSpan1 = DateTime.Now;
                    var timeSpan2 = TimeSpan.FromMinutes(30);
                    var duration = timeSpan1 - timeSpan;

                    if (duration >= timeSpan2)
                    {
                        file.Delete();
                    }
                    else
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Нет файлов, которые не используются более 30 минут");
                        Console.WriteLine($"Прошло{duration}времени");
                        break;
                    }
                }

                foreach (DirectoryInfo dir in DelFailDir.GetDirectories())
                {
                    var timeSpan = dir.LastAccessTime;
                    var timeSpan1 = DateTime.Now;
                    var timeSpan2 = TimeSpan.FromMinutes(30);
                    var duration = timeSpan1 - timeSpan;

                    if (duration >= timeSpan2)
                    {
                        dir.Delete(true);
                    }
                    else
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Нет папок, которые не используются более 30 минут");
                        Console.WriteLine($"Прошло {duration} времени");
                        break;
                    }
                }
            }



        }
       
        
    }
}
