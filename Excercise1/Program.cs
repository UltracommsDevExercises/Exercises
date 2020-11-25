using System;

namespace Excercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 76;
            int b = 23;

            Console.WriteLine(a + " times " + b + " = " + Multiply(a,b));
            Console.ReadLine();
        }

        /// <summary>
        /// TODO: Re-write this function to return an equivalent value, without using the '*' operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
