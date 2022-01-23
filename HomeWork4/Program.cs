using System;

namespace Homework_4
{
    public class Program
{
    private static int _initialArraySize;
    private static int _evenArrSize = 0;
    private static int[] _oddArr;
    private static int[] _evenArr;

    public static void Main(string[] args)
    {
        // прочитать из консоли число и провести валидацию введенных данных
        ReadConsole();
        Console.WriteLine();

        // создать массив и заполнить его случайными числами от 1 до 26 включительно
        Console.WriteLine("Randomly filled array:");
        int[] arr = GenerateArray(_initialArraySize);
        Console.WriteLine();

        // определить размерность массива с четными числами
        foreach (var item in arr)
        {
            if (item % 2 == 0)
            {
                _evenArrSize++;
            }
        }

        // инициализовать массивы с четными и нечетными числами
        _evenArr = new int[_evenArrSize];
        _oddArr = new int[_initialArraySize - _evenArrSize];

        // заполнить четный массив
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                _evenArr[counter] = arr[i];
                counter++;
            }
        }

        // заполнить нечетный массив
        int counter1 = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 1)
            {
                _oddArr[counter1] = arr[i];
                counter1++;
            }
        }

        // преобразовать массивы с числами в массивы с буквами
        Console.WriteLine("Array filled with English alphabet even-numbered letters:");
        string myStrWithEvenLetters = ConvertIntToCHar(_evenArr);
        string myChangedStrWithEvenLetters = ChangeLowerToUpper(myStrWithEvenLetters);
        Console.WriteLine(myChangedStrWithEvenLetters);

        Console.WriteLine("Array filled with English alphabet odd-numbered letters:");
        string myStrWithOddLetters = ConvertIntToCHar(_oddArr);
        string myChangedStrWithOddLetters = ChangeLowerToUpper(myStrWithOddLetters);
        Console.WriteLine(myChangedStrWithOddLetters);

        // определение, в каком массиве больше букв в верхнем регистре
        Console.WriteLine("Number of uppercase letters in array filled with English alphabet letters:");
        int counterForEvenStr = CountUpperLetters(myChangedStrWithEvenLetters);
        Console.WriteLine($" 1) even-numbered - {counterForEvenStr}.");

        int counterForOddStr = CountUpperLetters(myChangedStrWithOddLetters);
        Console.WriteLine($" 2) odd-numbered - {counterForOddStr}.");

        // вывод результата сравнения
        Comparer(counterForEvenStr, counterForOddStr);
        Console.ReadLine();
    }

    private static void ReadConsole()
    {
        Console.WriteLine("Enter the number of array elements");
        string consoleOutput = Console.ReadLine();
        bool isInt = int.TryParse(consoleOutput, out _initialArraySize);
        if (isInt && _initialArraySize > 0 && _initialArraySize <= 26)
        {
        }
        else
        {
            Console.WriteLine("Invalid value, please try again");
            ReadConsole();
        }
    }

    private static int[] GenerateArray(int number)
    {
        Random rnd = new Random();
        int[] arr = new int[number];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 26);
            Console.Write(arr[i] + " ");
        }

        return arr;
    }

    private static string ConvertIntToCHar(int[] arr)
    {
        string[] letters = new string[arr.Length];
        for (int k = 0; k < arr.Length; k++)
        {
            int c = 96;
            c += arr[k];
            string letter = Convert.ToChar(c).ToString();
            letters[k] = letter;
        }

        return string.Join(" ", letters);
    }

    private static string ChangeLowerToUpper(string st)
    {
        string[] myStr = st.Split(" ");
        for (int i = 0; i < myStr.Length; i++)
        {
            if (myStr[i].Contains('a'))
            {
                myStr[i] = myStr[i].Replace('a', 'A');
            }
            else if (myStr[i].Contains('e'))
            {
                myStr[i] = myStr[i].Replace('e', 'E');
            }
            else if (myStr[i].Contains('i'))
            {
                myStr[i] = myStr[i].Replace('i', 'I');
            }
            else if (myStr[i].Contains('d'))
            {
                myStr[i] = myStr[i].Replace('d', 'D');
            }
            else if (myStr[i].Contains('h'))
            {
                myStr[i] = myStr[i].Replace('h', 'H');
            }
            else if (myStr[i].Contains('j'))
            {
                myStr[i] = myStr[i].Replace('j', 'J');
            }
        }

        return string.Join(" ", myStr);
    }

    private static int CountUpperLetters(string st1)
    {
        int countUpperLetters = 0;
        char[] letters = st1.ToCharArray();
        foreach (var item in letters)
        {
            if (char.IsUpper(item))
            {
                countUpperLetters++;
            }
        }

        return countUpperLetters;
    }

    private static void Comparer(int n, int m)
    {
        if (n > m)
        {
            Console.WriteLine("There are more uppercase letters in the first array than in the second.");
        }
        else if (m > n)
        {
            Console.WriteLine("There are more uppercase letters in the second array than in the first one.");
        }
        else if (n == m)
        {
            Console.WriteLine("The number of uppercase letters is the same in both arrays");
        }
    }
}
}