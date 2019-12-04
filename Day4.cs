using System;
using System.Collections.Generic;
using System.Linq;

public class Day4
{
    private List<string> sequential = new List<string> {
        "00",
        "11",
        "22",
        "33",
        "44",
        "55",
        "66",
        "77",
        "88",
        "99",
    };

    private bool IsDouble(string source, string match)
    {
        var first = source.IndexOf(match);
        var last = source.LastIndexOf(match);

        return (first != -1 && (first == last));
    }

    private bool IsValid(int input, bool ignoreMultiples)
    {
        var stringInput = input.ToString();

        // 6 characters long
        if (stringInput.Length != 6)
        {
            return false;
        }

        // sequential
        var lastChar = 0;
        for (var i = 0; i < stringInput.Length; i++)
        {
            var thisChar = int.Parse(stringInput[i].ToString());
            if (thisChar < lastChar)
            {
                return false;
            }
            lastChar = thisChar;
        }

        // needs to have a sequential number in
        if (!sequential.Any(s => stringInput.Contains(s)))
        {
            return false;
        }

        if (ignoreMultiples)
        {
            foreach (var s in sequential)
            {
                var isDouble =  IsDouble(stringInput, s);
                if (!isDouble)
                {
                    // any other numbers match?
                    if (!sequential.Where(s2 => s2 != s)
                                   .Any(s2 => IsDouble(stringInput, s2)))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public void GetPart1()
    {
        var valid = new List<int>();

        Console.WriteLine("Day 4 - pt1. Tests");
        Console.WriteLine($"111111: {IsValid(111111, false)} - expected True");
        Console.WriteLine($"223450: {IsValid(223450, false)} - expected False");
        Console.WriteLine($"123789: {IsValid(123789, false)} - expected False");

        for (var i = 245182; i <= 790572; i++)
        {
            if (IsValid(i, false))
            {
                valid.Add(i);
            }
        }

        Console.WriteLine($"Day 4 - pt1. {valid.Count()}");
    }

    public void GetPart2()
    {
        var valid = new List<int>();

        Console.WriteLine("Day 4 - pt2. Tests");
        Console.WriteLine($"112233: {IsValid(112233, true)} - expected True");
        Console.WriteLine($"123444: {IsValid(123444, true)} - expected False");
        Console.WriteLine($"111122: {IsValid(111122, true)} - expected True");
        Console.WriteLine($"111223: {IsValid(111223, true)} - expected True");
        Console.WriteLine($"333556: {IsValid(333556, true)} - expected True");
        Console.WriteLine($"333557: {IsValid(333557, true)} - expected True");
        Console.WriteLine($"333355: {IsValid(333355, true)} - expected True");
        Console.WriteLine($"124444 : {IsValid(124444, true)} - expected False");
        Console.WriteLine($"333444 : {IsValid(333444, true)} - expected False");

        for (var i = 245182; i <= 790572; i++)        
        {
            if (IsValid(i, true))
            {
                valid.Add(i);
            }
        }

        Console.WriteLine($"Day 4 - pt2. {valid.Count()}");
    }
}