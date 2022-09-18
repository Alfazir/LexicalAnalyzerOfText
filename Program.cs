using System.Text;
using System.Text.RegularExpressions;


namespace LAOT
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test\test2.fb2";
            string pathResult = @$".\LexicalAnalyz.txt";

            Console.WriteLine("Укажите путь к текстовому файлу:");
            path = Console.ReadLine();
            Console.WriteLine(File.Exists(path) ? "Файл найден, начинаем разбор..." : "Файл не найден!");
            string line;
            var Lexemes = new Dictionary<string, int>(); 

            if (File.Exists(path))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(path, Encoding.UTF8);   

                    while ((line = file.ReadLine()) != null)
                    {
                        
                        #region Удаляем всё лишнее
                        string tagPattern = @"<[^>]*>"; // удаляем тэги
                         Regex tagRegex = new Regex(tagPattern);
                         line = tagRegex.Replace(line, @" "); // ghj,tks
                        line = Regex.Replace(line, "[!\"#$%&()*+,./:;<=>?@\\[\\]^_`{|}~][^0-9]", " ");
                        line = Regex.Replace(line, "--", " ").ToLower();
                        line = Regex.Replace(line, "[[*]", " ");
                        line = Regex.Replace(line, "[0-9]", "");

                        string pattern = @"[\s]";

                        string[] text = Regex.Split(line, pattern);
                        #endregion

                        foreach (string item in text)
                        {
                            if (item != "")
                            {
                                try
                                {
                                    Lexemes.Add(item, 1);
                                }

                                catch
                                {
                                    Lexemes[item] = ++Lexemes[item];
                                }
                            }
                        }



                    }


                    foreach (KeyValuePair<string, int> keyValuePair in Lexemes.OrderBy(key => key.Value).Reverse())
                    {



                        Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
                        File.AppendAllText(pathResult, $"{keyValuePair.Key} {keyValuePair.Value}{Environment.NewLine}", Encoding.UTF8);
                    }

                }
                finally
                {
                    if (file != null)
                        file.Close();
                }

            }

            Console.Read();
        }
    }
}