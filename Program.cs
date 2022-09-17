using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LAOT
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test\test.fb2";
            string line;

            var Lexemes = new Dictionary<string, int>();

            if (File.Exists(path))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(path, Encoding.UTF8);   // считываем файл

                   
            



                    while ((line = file.ReadLine()) != null)
                    {
                        //   string tagPattern = @"<[^>]"; 
                        //  Regex tagRegex = new Regex(tagPattern);
                        //  file = tagRegex.Replace(file, @"\s");



                        /* string [] text = line.Split();

                           foreach ( string item in text)
                           {
                              Console.WriteLine($"{item}");
                           }

                        //  Console.WriteLine(text.L);*/
                        //string pattern = @"[ !?\0n]";
                        //string pattern =@"[^\w\r\n\t\s]";
                        string pattern = @"[\s]";

                        string[] text = Regex.Split(line, pattern);
                        foreach (string item in text)
                        {

                            Console.WriteLine($"{item}");
                        }



                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }

            }

            // Console.Read();


        }
    }
}