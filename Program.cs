using System;

namespace adventofcode2019
{
    class Program
    {
        private static string[] LoadInput(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName);
        }

        private static string LoadFlatInput(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        }

        static void Main(string[] args)
        {
            var masses = LoadInput("input-day1.txt");
            var day1 = new Day1(masses);

            Console.WriteLine($"Day 1 - pt1. {day1.GetDay1Part1()}");
            Console.WriteLine($"Day 1 - pt2. {day1.GetDay1Part2()}");

            var opcodes = LoadFlatInput("input-day2.txt");
            var day2 = new Day2(opcodes);
            Console.WriteLine($"Day 2 - pt1. {day2.GetDay2Part1()}");
            Console.WriteLine($"Day 2 - pt2. {day2.GetDay2Part2()}");

            var paths = LoadFlatInput("input-day3.txt");
            var day3 = new Day3(paths);
            day3.GetDay3();

            var day4 = new Day4();
            day4.GetPart1();
        }
    }
}
