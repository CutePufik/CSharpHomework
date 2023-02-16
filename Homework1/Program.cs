using System;
using System.Linq;

namespace Homework1
{
    enum Seasons
    {
        Winter,
        Spring,
        Summer,
        Autumn
    };

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Первое задание");
            // Console.WriteLine(makeTheNumberOfTensZero(345));
            // Console.WriteLine(makeTheNumberOfTensZero(123));
            // Console.WriteLine();

            // Console.WriteLine("Второе задание");
            // Console.WriteLine(colorOfSquare(2,2));
            // Console.WriteLine(colorOfSquare(7,6));
            // Console.WriteLine();

            // Console.WriteLine("Третье задание");
            // Console.WriteLine(findNumberOfRootsOfAnEquation(1,2,-3));
            // Console.WriteLine(findNumberOfRootsOfAnEquation(2,5,8));
            // Console.WriteLine(findNumberOfRootsOfAnEquation(9,6,1));
            // Console.WriteLine();

            // Console.WriteLine("Четвёртое задание");
            // Console.WriteLine(MinOfDouble(1.01,1.02));
            // Console.WriteLine(MinOfDouble(1.41243124,1.41554215));
            // Console.WriteLine();

            // Console.WriteLine("Пятое задание");
            // Console.WriteLine(prodBetweenTwoInt(1,10));
            // Console.WriteLine(prodBetweenTwoInt(15,2));
            // Console.WriteLine();

            // Console.WriteLine("Шестое задание");
            // Console.WriteLine(findCountOfNumbersLessAndDivideK(5));
            // Console.WriteLine(findCountOfNumbersLessAndDivideK(2));
            // Console.WriteLine();

            // Console.WriteLine("Седьмое задание");
            // Console.WriteLine(returnSeason(4));
            // Console.WriteLine(returnSeason(7));
            // Console.WriteLine();
            
            // Console.WriteLine("Восьмое задание");
            // descriptionOfRandomMonth(5);
            // descriptionOfRandomMonth(6);
            // Console.WriteLine();
            
        }


        /// Обнуляет в трехзначном числе разряд десятков
        public static int makeTheNumberOfTensZero(int number)
        {
            if (number <= 99 || number >= 1000)
            {
                throw new Exception();
            }

            return number / 100 * 100 + number % 10;
        }

        /// возвращает какой цвет имеет поле с данными координатами на шахматной доске
        public static String colorOfSquare(int x, int y)
        {
            if (!(x >= 1 && x <= 8 && y >= 1 && y <= 8))
            {
                throw new Exception("Нет такой клетки");} 
            String color = ( x % 2 == 1) && ( y % 2 == 1) || ( x % 2 == 0) && ( y % 2 == 0) ? " Черный" : " Белый";
            return color;
        }

        /// количество вещественных корней квадратного уравнения Ax2+Bx+c=0
        public static int findNumberOfRootsOfAnEquation(int A, int B, int C)
        {
            if (A == 0)
            {
                throw new Exception();
            }


            int result = 0;
            if (B * B - 4 * A * C == 0)
            {
                result = 1;
            }
            else if (B * B - 4 * A * C > 0)
            {
                result = 2;
            }
            

            return result;
        }

        /// возвращает минимум из двух переданных вещественных чисел
        public static double MinOfDouble(double number1, double number2)
        {
            double result = 0;
            if (number1 > number2)
            {
                result = number2;
            }
            else
            {
                result = number1;
            }

            return result;
        }

        /// произведение всех чётных целых чисел от A до B включительно.
        public static double prodBetweenTwoInt(int A, int B)
        {
            if (A > B)
            {
                (A, B) = (B, A);
            }

            double result = 1.0;
            for (int i = A; i <= B; i++)
            {
                result *= i;
            }

            return result;
        }
        
        
        /// количество чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело
        public static (int, int ) findCountOfNumbersLessAndDivideK(int K)
        {
            var result = (0, 0);
            Console.WriteLine("Введите число");
            var number = int.Parse(Console.ReadLine());
            while (number != 0)
            {
                if (number < K)
                {
                    result.Item1++;
                }

                if (number % K == 0)
                {
                    result.Item2++;
                }

                Console.WriteLine("Введите число");
                number = int.Parse(Console.ReadLine());
            }

            return result;
        }
        
        /// по номеру месяца [1..12] возвращает время года.
        public static Seasons returnSeason(int numberOfMonth)
        {
            
            
            var winterMonth = new int[] { 12, 1, 2 };
            var springMonth = new int[] { 3, 4, 5 };
            var summerMonth = new int[] { 6, 7, 8 };
            var autumnMonth = new int[] { 9, 10, 11 };

            if (winterMonth.Contains(numberOfMonth))
            {
                return Seasons.Winter;
            }
            else if (springMonth.Contains(numberOfMonth))
            {
                return Seasons.Spring;
            }
            else if (summerMonth.Contains(numberOfMonth))
            {
                return Seasons.Summer;
            }
            else if (autumnMonth.Contains(numberOfMonth))
            {
                return Seasons.Autumn;
            }
            else
            {
                throw new Exception();
            }
        }

        
        /// выводит на консоль N строк описанания случайного месяца.
        public static void descriptionOfRandomMonth(int numberOfRandomMonth)
        {
            if (numberOfRandomMonth < 0)
            {
                throw new Exception();}
            
            Random r = new Random();
            for (int i = 0; i < numberOfRandomMonth; i++)
            {
                int numberOfMonth = r.Next(1, 13);
                Seasons season = returnSeason(numberOfMonth);
                Console.WriteLine($"Месяц №{numberOfMonth}, его сезон: {season}");
            }
        }
    }
}