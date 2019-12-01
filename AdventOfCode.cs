using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class AdventOfCode
{

    private int[] Masses { get; set; }

    public AdventOfCode(IEnumerable<string> input)
    {
        Masses = input.Select(x => int.Parse(x)).ToArray();
    }

    public int GetPart1()
    {
        return Masses.Select(x => (int)(x / 3) - 2).Sum();
    }

    private int GetFuel(int mass) {
        var x = (mass / 3) - 2;
        if (x <= 0) {
            return 0;
        }

        return x + GetFuel(x);
    }

    public long GetPart2()
    {
        return  Masses.Select(x => GetFuel(x)).Sum();
    }
}