using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        var path = "C:\\Users\\Asus\\Desktop\\labs\\dotnet\\lab4_5\\text.txt";
        var dic = new SortedDictionary<string, int>();
        string[] buffer;
        try
        {
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                while (!sr.EndOfStream)
                {
                    buffer = Regex.Split(sr.ReadLine(), "(\\W)");
                    foreach (var it in buffer)
                    {
                        string trimmed = it.Trim();
                        if (string.IsNullOrEmpty(trimmed)) continue;

                        if (dic.ContainsKey(trimmed))
                            dic[trimmed]++;
                        else
                            dic.Add(trimmed, 1);
                    }
                }
            }
            
            // LINQ-запрос для слов "King" и "Edward"
            var sel = dic.Where(val => val.Key == "King" || val.Key == "Edward")
                         .OrderBy(val => val.Value);
            
            Console.WriteLine("Частота слов 'King' и 'Edward':");
            foreach (var it in sel)
                Console.WriteLine("{0}: {1}", it.Key, it.Value);
            
            // LINQ-запросы для знаков препинания
            Console.WriteLine("\nЧастота знаков препинания:");
            var punctuationMarks = new Dictionary<string, string>
            {
                { ".", "Точки" },
                { ";", "Точки с запятой" },
                { "?", "Знаки вопроса" },
                { "!", "Знаки восклицания" },
                { "-", "Тире" }
            };
            
            foreach (var mark in punctuationMarks)
            {
                var count = dic.ContainsKey(mark.Key) ? dic[mark.Key] : 0;
                Console.WriteLine("{0}: {1}", mark.Value, count);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}