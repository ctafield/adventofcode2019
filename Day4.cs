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

    private bool IsValid(int input)
    {
        var stringInput = input.ToString();

        if (stringInput.Length != 6) {
            return false;
        }
        var lastChar = 0;
        for (var i = 0; i < stringInput.Length; i++) {
            var thisChar = int.Parse(stringInput[i].ToString());
            if (thisChar < lastChar) {
                return false;
            }
            lastChar = thisChar;
        }

        if (!sequential.Any(s => stringInput.Contains(s))) {
            return false;
        }

        return true;
    }

    public void GetPart1()
    {
        var valid = new List<int>();

        for (var i = 245182; i <= 790572; i++)
        {
            if (IsValid(i)) {
                valid.Add(i);
            }
        }

        Console.WriteLine($"Day 4 - pt1. {valid.Count()}");
    }
}