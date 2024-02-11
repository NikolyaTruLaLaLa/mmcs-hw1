using System.Security.Cryptography;
using static System.Console;
using static System.Math;

namespace homeWork1 
{

    static class Programm 
    {
        //static double eps = Pow(1, -10);
        static void Main()
        {
            print_problem(1);
            int a = 100;
            WriteLine($"Before: {a}     After: {ZeroingTens(a)}");
            a = 198;
            WriteLine($"Before: {a}     After: {ZeroingTens(a)}");
            a = -678;
            WriteLine($"Before: {a}     After: {ZeroingTens(a)}");

            print_problem(2);
            int x = 1; int y = 1;
            WriteLine($"Клетка ({x}, {y}) -> {GetPointColor(x, y)}");
            x = 1; y = 2;
            WriteLine($"Клетка ({x}, {y}) -> {GetPointColor(x, y)}");
            x = 3; y = 4;
            WriteLine($"Клетка ({x}, {y}) -> {GetPointColor(x, y)}");

            print_problem(3);
            var (A, B, C) = (1.0, -2.0, 1.0);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A,B,C)} корней");
            (A, B, C) = (3, 20.35, -4);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A, B, C)} корней");
            (A, B, C) = (-4, 5, -20);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A, B, C)} корней");

            print_problem(4);
            var (x1, x2) = (1.333333333334, 1.333333333335);
            WriteLine($"Минимальное из {x1}, {x2} -> {FoundMin(x1, x2)}");
            (x1, x2) = (-1, 10000.32);
            WriteLine($"Минимальное из {x1}, {x2} -> {FoundMin(x1, x2)}");
                (x1, x2) = (25.3456, 25.3456);
            WriteLine($"Минимальное из {x1}, {x2} -> {FoundMin(x1, x2)}");

            print_problem(5);
            (x, y) = (2, 10);
            WriteLine($"Произведение всех чётных чисел в промежутке [{x} : {y}]N = {ProductOfEvenNumb(x, y)}");
            (x, y) = (2, -10);
            WriteLine($"Произведение всех чётных чисел в промежутке [{x} : {y}]N = {ProductOfEvenNumb(x, y)}");
            (x, y) = (18, 15);
            WriteLine($"Произведение всех чётных чисел в промежутке [{x} : {y}]N = {ProductOfEvenNumb(x, y)}");

            print_problem(6);
            int k = 3; int c1; int c2;
            CountBySomeRules(k, out c1, out c2);
            WriteLine($"Количесвто чисел, меньших {k} -> {c1}.   Количество чисел, делящихся на {k} -> {c2}");

            print_problem(7);
            int i = 0;
            WriteLine($"Месяц номер {i} -> {NumbToSeason(i)}");
            i = 4;
            WriteLine($"Месяц номер {i} -> {NumbToSeason(i)}");
            i = 7;
            WriteLine($"Месяц номер {i} -> {NumbToSeason(i)}");
            i = 13;
            WriteLine($"Месяц номер {i} -> {NumbToSeason(i)}");

            print_problem(8);
            PrintRandomNSeasonMonth(5);
        }


        static void print_problem(int i) 
        {
            WriteLine(); WriteLine();
            WriteLine($"****TASK {i}****");
            WriteLine(); 
        }

        // task 1
        // in  -> int a трёхзначное число
        // out -> int это же число с 0 вместо разряда десятков
        static int ZeroingTens(int a) 
        {
            int sgn = Sign(a);
            a = Abs(a);
            if ((a < 100) || (a > 999))
                throw new ArgumentException($"{a} - не трёхзначное число");

            return (a - (a % 100 / 10) * 10) * sgn;
        }

        static void Validate(int x) 
        {
            if ((1 > x) || (x > 8))
                throw new ArgumentException($"{x} - не чсило от 1 до 8");
        }
        // task 2
        // in  -> int x, y - координаты клетки от 1 до 8
        // out -> string "black" или "white" - цвет клетки, если (1, 1) black
        static string GetPointColor(int x, int y) 
        {
            Validate(x); Validate(y);

            return ((x + y) % 2 == 0) ? "чёрная" : "белая";
        }


        // task 3
        // in  -> double A, B, C (A != 0) - коэффециэнты квадратного уравнения
        // out -> int от 0 до 2 - количество вещественных корней квадратного уравнения
        static int CountRootsOfEquation(double a,  double b, double c)
        {
            if (a == 0) throw new ArgumentException($"{a} = 0, уравнение не квадратное");

            double d = b * b - 4 * a * c;
            if (d == 0) return 1;
            else if (d > 0) return 2;
            else return 0;

        }

        // task 4
        // in  -> double a,b
        // out -> double min(a,b)
        static double FoundMin(double a, double b) => (a < b) ? a : b;

        // task 5
        // in  -> int a, b
        // out -> double произведение всех чётных чисел между а и b включительно
        static double ProductOfEvenNumb(int a, int b)
        {
            if (a > b) 
                (a, b) = (b, a);
            double p = 1.0;
            for (int i = a + a % 2; i <= b - b % 2; i += 2)
                p *= i;
            return p;
        }

        // task 6
        //in            -> int k, out int c_less, c_divs
        //in in process -> последовательность целых чисел, признак её завершения — число 0
        //out           -> int c_less (количество чисел, меньших k)
        //                 int c_divs (количество чисел, делящихся на k)
        static void CountBySomeRules(int k, out int c_less, out int c_divs)
        {
            int a = k + 1;
            (c_less, c_divs) = (0, 0);
            WriteLine("Введите последовательность целых чисел. Чтобы завершить ввод, введите 0:");
            do
            {
                if (a < k) c_less += 1;
                if (a % k == 0) c_divs += 1;
                Write(">>> ");
                a = int.Parse(ReadLine());
            }
            while (a != 0);
        }

        // task 7
        // in  -> int i - номер месяца от 1 до 12
        // out -> string название месяца
        static string NumbToSeason(int i) 
        {
            switch (i) 
            {
                case 1 :
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
                default:
                    return "Неизвестный месяц";
            }
        }

        // task 8
        // in ->

        static void PrintRandomNSeasonMonth(int n)
        {
            if (n < 0)
                throw new ArgumentException($"{n} должно быть больш либо равно 0");

            Random rnd = new Random();
            for (int i = 1; i <= n; i++)
            {
                int t = rnd.Next(1, 13);
                WriteLine($"Месяц №{t}, его сезон: {NumberToSeason(t)}");
            }

        }

        static string NumberToSeason(int i)
        {
            switch (i)
            {
                case >=1 and <=2 or <=12 and >=12:
                    return "Зима";
                case >= 3 and <= 5:
                    return "Весна";
                case >= 6 and <= 8:
                    return "Лето";
                case >= 9 and <= 11:
                    return "Осень";
                default:
                    return "Неизвестный сезон";
            }
        }

    }
}
//
/*
 * 

****TASK 1****

Before: 100     After: 100
Before: 198     After: 108
Before: -678     After: -608


****TASK 2****

Клетка (1, 1) -> чёрная
Клетка (1, 2) -> белая
Клетка (3, 4) -> белая


****TASK 3****

У уравнения 1x^2 + -2x + 1   ->   1 корней
У уравнения 3x^2 + 20,35x + -4   ->   2 корней
У уравнения -4x^2 + 5x + -20   ->   0 корней


****TASK 4****

Минимальное из 1,333333333334, 1,333333333335 -> 1,333333333334
Минимальное из -1, 10000,32 -> -1
Минимальное из 25,3456, 25,3456 -> 25,3456


****TASK 5****

Произведение всех чётных чисел в промежутке [2 : 10]N = 3840
Произведение всех чётных чисел в промежутке [2 : -10]N = -0
Произведение всех чётных чисел в промежутке [18 : 15]N = 288


****TASK 6****

Введите последовательность целых чисел. Чтобы завершить ввод, введите 0:
>>> 1
>>> 3
>>> 2
>>> 4
>>> -2
>>> 6
>>> 0
Количесвто чисел, меньших 3 -> 3.   Количество чисел, делящихся на 3 -> 2


****TASK 7****

Месяц номер 0 -> Неизвестный месяц
Месяц номер 4 -> Апрель
Месяц номер 7 -> Июль
Месяц номер 13 -> Неизвестный месяц


****TASK 8****

Месяц №6, его сезон: Лето
Месяц №4, его сезон: Весна
Месяц №2, его сезон: Зима
Месяц №5, его сезон: Весна
Месяц №3, его сезон: Весна

*/