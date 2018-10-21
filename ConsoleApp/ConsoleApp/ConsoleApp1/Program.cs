using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину прямоугольника");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ширину прямоугольника");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Вот Ваш прямоугольник:");
            Print.PrintRectangle(a, b);
            Console.ReadLine();
        }
    }
}

class Print
{
    public static void PrintLine(int a)
    {
        for (int i=1; i<=a; i++)
        {
            Console.Write("*");
        }
    }

    public static void PrintRectangle (int a, int b)
    {
        for (int j=1; j<=b; j++)
        {
            PrintLine(a);
            Console.Write("\n");
        }
    }
}
