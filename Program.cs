using System;

namespace adventofcode2019
{
    class Program
    {
        private static string[] LoadInput()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }

        static void Main(string[] args)
        {
            var input = LoadInput();
            var adventOfCode = new AdventOfCode(input);
        
            Console.WriteLine($"1. {adventOfCode.GetPart1()}");
            Console.WriteLine($"2. {adventOfCode.GetPart2()}");
        }
    }
}
