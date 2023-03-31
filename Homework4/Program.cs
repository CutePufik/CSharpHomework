using System.Text;

class HomeWork4
{
    static void Main(string[] args)
    {
        //task1
        //CreateFileWithRandomNumbers("task1.dat",10,0.9999,1);
        //printFileDoubleNumbers("task1.dat");
        
        
        //task2
         // CreateFileInt("./input-files/task2.txt", 1,2,3,43,5);
         // printFileIntNumbers("./input-files/task2.txt");
         // Console.WriteLine(task2(1, "./input-files/task2.txt"));


        //task3
        // String[] fields = task3("./input-files/1000-7.mp3");
        // PrintArr(fields);
        
        
        
      
        







    }
    
    


    /// <summary>
    /// создает файл с вещественными рандомными числами
    /// </summary>
    /// <param name="path"></param>
    static void CreateFileWithRandomNumbers(String pathByDefault = "task1.dat", int N = 20, double a = -50,
        double b = 50)
    {
        
        if (N < 0 || a > b || String.IsNullOrEmpty(pathByDefault))
            throw new Exception();
        try
        {
            using (var fs = new FileStream(pathByDefault, FileMode.Create))
            using (var sw = new BinaryWriter(fs))
            {
                for (int i = 0; i < N; i++)
                {
                    Random random = new Random();
                    var number = a + (b - a) * random.NextDouble();
                    sw.Write(number);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    /// <summary>
    /// метод, возвращающий K-й элемент файла (элементы нумеруются с 0). Если такой элемент отсутствует, вернуть −1.
    /// </summary>
    /// <param name="K"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    static int task2(int K, String path)
    {
        try
        {
            using (var fl = new FileStream(path,FileMode.Open))
            using (var BR = new BinaryReader(fl))
            {
                if (K >= fl.Length/sizeof(int))
                    return -1;
                fl.Seek(K * sizeof(int), SeekOrigin.Begin);
                return BR.ReadInt32();
            }    
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return -1;
        }
    }
    
    
/// <summary>
/// извлечь название трека и исполнителя (и любую другую информацию по желанию) из мета-данных данного .mp3 файла и вывести их на консоль.
/// </summary>
/// <param name="path"></param>
/// <returns></returns>
    static String[] task3(String path)
    {
        
        int[] numberBytesForFields = { 3,30,30,30,4,30,1,1,1};
        String[] fields = new string[numberBytesForFields.Length];
        try
        {
            using (var fs = new FileStream(path, FileMode.Open))
            using(var BR = new BinaryReader(fs))
            {
                fs.Seek(-128, SeekOrigin.End);
                for (int i = 0; i < numberBytesForFields.Length; i++)
                {
                    fields[i] = Encoding.Default.GetString(BR.ReadBytes(numberBytesForFields[i]));
                }
                
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        }

        return fields;
    }

/// <summary>
/// Дан текстовый файл, содержащий слова, разделённые пробелами или символами конца строки. Посчитать количество слов в этом файле.
/// </summary>
/// <param name="path"></param>
/// <returns></returns>
    static int task5(String path)
    {
        return File.ReadAllText(path)
            .Split(new char[] { ',', '.', '!', '?', ':', ' ',';','\n','\r','-' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    /// <summary>
    /// создает файл со входными вещественными параметрами
    /// </summary>
    /// <param name="path"></param>
    /// <param name="a"></param>
    static void CreateFileDouble(string path, params double[] a)
    {
        try
        {
            using (var fs = new FileStream(path, FileMode.Create))
            using (var sw = new BinaryWriter(fs))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    sw.Write(a[i]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    /// <summary>
    /// создает файл со входными целыми параметрами
    /// </summary>
    /// <param name="path"></param>
    /// <param name="a"></param>
    static void CreateFileInt(string path, params int[] a)
    {
        try
        {
            using (var fs = new FileStream(path, FileMode.Create))
            using (var sw = new BinaryWriter(fs))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    sw.Write(a[i]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    /// <summary>
    /// принтует файл с вещественными числами
    /// </summary>
    /// <param name="path"></param>
    static void printFileDoubleNumbers(String path)
    {
        try
        {
            using (var fs = new FileStream(path, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                
                var len = fs.Length / sizeof(double);
                for (int i = 0; i < len; i++)
                {
                    Console.Write(br.ReadDouble() + " ");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        }
        Console.WriteLine();

        
    }
    /// <summary>
    /// принтует файл с целыми числами
    /// </summary>
    /// <param name="path"></param>
    static void printFileIntNumbers(String path)
    {
        try
        {
            using (var fs = new FileStream(path, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                
                var len = fs.Length / sizeof(int);
                for (int i = 0; i < len; i++)
                {
                    Console.Write(br.ReadInt32() + " ");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        }
        Console.WriteLine();

        
    }

    /// <summary>
    /// принтит массив
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    static void PrintArr<T>(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i] + " ");
        }
        Console.WriteLine();
    }
    
    
    
    
    
}