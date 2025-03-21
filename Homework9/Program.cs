using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

class Program
{
    public static string text = "Пример текста для обработки.";

    static async Task Main()
    {
        Console.WriteLine("Введите скрипт для обработки текста. Например:");
        Console.WriteLine("text.Length // Подсчет символов");
        Console.WriteLine("text.Split(' ').Length // Подсчет слов");

        string script = Console.ReadLine();

        try
        {
            var result = await CSharpScript.EvaluateAsync<object>(script,
                ScriptOptions.Default.WithImports("System"),
                globals: new ScriptGlobals { text = text });
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка выполнения: " + ex.Message);
        }
    }
}

public class ScriptGlobals
{
    public string text;
}
