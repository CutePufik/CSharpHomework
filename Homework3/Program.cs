using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace Homework3;

public class MyHomeWork
{
     static void Main(string[] args)
    {
    //     //task 1
    //     string s = "М312КУ   Я101Да НУ312ВЫС В111ФВФ";
    //     string[] arrstr = ArrayCarNumbers(s);
    //     arrstr.Print();
    //
    //     //task 2
    //     Console.WriteLine();
    //     var s2 = "*this is italic*";
    //     Console.WriteLine(s2);
    //     Console.WriteLine(StarsWithTags(s2));
    //     var s3 = "**bold text (not italic)**";
    //     Console.WriteLine(s3);
    //     Console.WriteLine(StarsWithTags(s3));
    //     Console.WriteLine();
    //
    //
    //     //task 3
    //     // валидирует IP-адреса
    //     // "192.168.0.1"
    //     // "10.0.0.1"
    //     // "154.16.2.2"
    //     // "200.255.0.0"
    //     // "0.0.0.0"
    //     Console.WriteLine(Regex.Match("192.168.0.1",
    //         @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"));
    //     Console.WriteLine(Regex.Match("10.0.0.1",
    //         @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"));
    //     Console.WriteLine(Regex.Match("154.16.2.2",
    //         @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"));
    //     Console.WriteLine(Regex.Match("200.255.0.0",
    //         @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"));
    //     Console.WriteLine(Regex.Match("0.0.0.0",
    //         @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"));
    //     Console.WriteLine();
    //
    //
    //     // task4
    //     var s4 = "ThisIsSomeText";
    //     Console.WriteLine(s4);
    //     Console.WriteLine(SeparateWordsCamelCase(s4));
    //     Console.WriteLine();
    //     
    //     //task 5
    //     string s5 =
    //         "@alex=(USD=123 RUB=234 EUR=456 comment=&*&6f7shahjd?=EUR4536USD-77JH) @sam=(RUB=100) @ivan=(EUR=12904 RUB=9 comment=USDJPYRUB=777U*7d%^#)";
    //     PrintClientData(s5);
     }


    
    /// находит в строке все автомобильные номера и возвращает массив из них.
    static String[] ArrayCarNumbers(string s)
    {
        var regexMatches = Regex.Matches(s, @"[А-Я]{1}[0-9]{3}[А-Я]{2}");
        string[] results = new string[regexMatches.Count];
        for (int i = 0; i < regexMatches.Count; i++)
        {
            results[i] = regexMatches[i].Value;
        }

        return results;
    }

   
    /// Преобразовывает текст, обрамленный в звездочки, в текст обрамленный тегом <em></em>, т.е. курсив. Не трогает текст в двойных звездочках (жирный).
    static String StarsWithTags(String s)
    {
        return Regex.Replace(s, @"(?<!\*)((\*\*){0,300})(\*)([\w+\s+]+)(\*)((\*\*){0,300})(?!\*)", @"<em>$1$4$6</em>");
    }

    
    /// "разделяет" слова с помощью пробелов в тексте стиля CamelCase
    static string SeparateWordsCamelCase(string s)
    {
        return Regex.Replace(s, @"([A-Z][a-z]*)(?=[A-Z])?", @"$1 ");
    }
    
    
    /// в данных о счетах клиентов выводит логин и длину строки-описания
    static void PrintClientData(string s)
    {
        foreach (Match match in Regex.Matches(s,@"@(?<login>\w+)=\((?<description>.+?)\)"))
        {
            string login = match.Groups["login"].Value;
            int len= match.Groups["description"].Value.Length;
            Console.WriteLine($"{login} => {len}");
        }
    }
    
}

public static class Extensions
{
    /// Печатает массив
    public static void Print<T>(this T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }

        Console.WriteLine();
    }
}