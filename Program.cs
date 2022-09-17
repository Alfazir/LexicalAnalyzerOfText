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
            string path = @"C:\test\test1.txt";
            string line;

            var Lexemes = new Dictionary<string, int>(); // словарь лексем


            if (File.Exists(path))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(path, Encoding.UTF8);   // считываем файл


                    while ((line = file.ReadLine()) != null)
                    {

                        #region Удаляем всё лишнее
                        string tagPattern = @"<[^>]*>"; // удаляем тэги
                         Regex tagRegex = new Regex(tagPattern);
                         line = tagRegex.Replace(line, @" "); // ghj,tks
                        line = Regex.Replace(line, "[!\"#$%&()*+,./:;<=>?@\\[\\]^_`{|}~][^0-9]", " ");
                        
                      //   line = new string(line.Where(c => !char.IsPunctuation(c) ).ToArray()).ToLower();
                        #endregion

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
                            if (item != "")
                            {
                                //Console.WriteLine($"{item}");
                                try
                                {
                                    Lexemes.Add(item, 1);
                                }

                                catch
                                {
                                    Lexemes[item] = ++Lexemes[item];
                                }
                               // Console.WriteLine($" {item}    {Lexemes[item]}");
                            }
                        }



                    }

                    //var myList = Lexemes.ToList();
                  ///  myList.Sort();
                    foreach (KeyValuePair<string, int> keyValuePair in Lexemes.OrderBy(key => key.Value).Reverse())
                    {
                        Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
                    }

                   /* foreach (var lexem in Lexemes)
                    {
                        Console.WriteLine($"{lexem.Key} {lexem.Value}");
                    }*/
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