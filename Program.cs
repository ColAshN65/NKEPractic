using System;

namespace NKEPractic
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] Sides = new string[3];
                Console.Write("_____№1,3_____\nВведи стороны треугольника:\n" +
                              "AB = ");
                Sides[0] = Console.ReadLine();
                Console.Write("BC = ");
                Sides[1] = Console.ReadLine();
                Console.Write("AC = ");
                Sides[2] = Console.ReadLine();
                Triangle triangle = new Triangle(Sides);
                Console.Write("Треугольник - " + triangle.GetTypeOfTriangle()+
                    $" и {triangle.GetAngleTriangleType()}"+
                    $"\nПлощадь: {triangle.GetArea()}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
