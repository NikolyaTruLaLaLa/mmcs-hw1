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
        }


        static void print_problem(int i) 
        {
            WriteLine(); WriteLine();
            WriteLine($"****TASK {i}****");
            WriteLine(); 
        }

        // in  -> трёхзначное число
        // out -> это же число с 0 вместо разряда десятков
        static int ZeroingTens(int a) 
        {
            int sgn = Sign(a);
            a = Abs(a);
            if ((a < 100) || (a > 999))
                throw new ArgumentException($"{a} - не трёхзначное число");

            return (a - (a % 100 / 10) * 10) * sgn;
        }
    }    
}
