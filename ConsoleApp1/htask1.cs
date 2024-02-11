using static System.Console;
using static System.Math;

namespace homeWork1 
{
    static class Programm 
    {
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
            var (A, B, C) = (1, -2, 1);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A,B,C)} корней");
            (A, B, C) = (3, 20, -4);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A, B, C)} корней");
            (A, B, C) = (-4, 5, -20);
            WriteLine($"У уравнения {A}x^2 + {B}x + {C}   ->   {CountRootsOfEquation(A, B, C)} корней");

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

    }    
}
