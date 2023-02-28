using System;
using System.Linq;

namespace Homework2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Первое задание");
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArr(returnArraySatisfiedPred(a, x => x % 2 == 0));
            PrintArr(returnArraySatisfiedPred(a, x => x % 2 == 1));
            
            Console.WriteLine("Второе задание");

            int[] b = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] b1 = { 6,7,8,9,10,1,2,3,4,5 };
            reverseArr(b);
            reverseArr(b1);
            PrintArr(b);
            PrintArr(b1);
            
            Console.WriteLine("Третье задание");

            int[,] matr = { {1,2},{3,4},{5,6}};
            int[,] matr1 = { { 13, 2, 31 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            printMatr(matr);
            Console.WriteLine();
            printMatr(matr1);
            
            Console.WriteLine("Четвертое задание");
            
            int[,] matr3 = { {1,4},{4,1} };
            
            int[,] matr4 = { { 13, 2, 31 }, { -4, 50, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            
            Console.WriteLine(findNumberOfStringAndDigitInMatrWithMaxSum(matr3));
            Console.WriteLine(findNumberOfStringAndDigitInMatrWithMaxSum(matr4));
            
            Console.WriteLine("Пятое задание");

            
            var arr = new double[3][];
            arr[0] = new double[6];
            arr[1] = new double[6];
            arr[2] = new double[5];
            var array = creatJaggedArr(arr);
            Console.WriteLine(findMaxValueOfAverageSumOfString(array));
            
            

        }


        ///в массиве с четным кол-вом элементов меняет местами его первую и вторую половину.
        public static void reverseArr(int[] arr)
        {
            if (arr.Length % 2 == 1)
            {
                throw new Exception();
            }

            int len = arr.Length;
            var segmentFirstHalf = new ArraySegment<int>(arr, 0, len/2).ToArray();
            var segmentSecondHalf = new ArraySegment<int>(arr, len/2, len/2).ToArray();
            int[] result = segmentSecondHalf.Concat(segmentFirstHalf).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }
        }
        
        
        /// новый массив, в котором удалены все элементы, не удовлетворяющие предикату
        public static int[] returnArraySatisfiedPred(int[] arr, Func<int, bool> f)
        {
            int size = arr.Where(x => f(x)).ToArray().Length;

            int[] result = new int[size];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (f(arr[i]))
                {
                    result[j] = arr[i];
                    ++j;
                }
            }

            return result;
        }

        

       
        /// выводящий её элементы в следующем порядке:
        /// первая строка слева направо, вторая строка справа налево, третья строка слева направо, четвертая строка справа налево и т. д.
        public static void printMatr(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write(matr[i, j] + " ");
                    }
                }
                else
                {
                    for (int j = matr.GetLength(1) - 1; j >= 0; j--)
                    {
                        Console.Write(matr[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
        
        /// метод, находящий номер строки в МАТРИЦЕ с наибольшей суммой элементов, а также значение наибольшей суммы.
        public static (int,int) findNumberOfStringAndDigitInMatrWithMaxSum(int[,] matr)
        {
            int numberOfString = 0;

            int maxSum = int.MinValue;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    sum += matr[i, j];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    numberOfString = i+1;
                }
                
            }

            return (numberOfString, maxSum);
        }
        
        
        
        public static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        
        /// находит в ступенчатом массиве максимальное значение среди всех средних значений строк массива
        public static double findMaxValueOfAverageSumOfString(double[][] arr)
        {
            double max = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                double sum = 0.0;
                int count = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum += arr[i][j];
                    ++count;
                }
                max = Math.Max(max, sum / (double)count);

            }
            return max;
        }
        
        
        
        /// создает ступенчатый массив с рандомными числами и выводит его в консоль
        public static double[][] creatJaggedArr(double[][] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = r.Next(-100, 100);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }
            return arr;
        }
        
        
        
    }
}