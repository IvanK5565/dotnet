using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Використання: Program.exe <каталог> <текст для пошуку>");
            return;
        }

        string directory = args[0];
        string searchText = args[1];

        if (!Directory.Exists(directory))
        {
            Console.WriteLine("Каталог не існує!");
            return;
        }

        try
        {
            var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    string content = File.ReadAllText(file);
                    if (content.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Знайдено в файлі: {file}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка читання файлу {file}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка доступу до каталогу: {ex.Message}");
        }
    }
}
