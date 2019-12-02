using System;
using System.Collections.Generic;
using System.Linq;

public class Day1
{

    private int[] Masses { get; set; }

    public Day1(IEnumerable<string> masses)
    {
        Masses = masses.Select(x => int.Parse(x)).ToArray();
    }

    public int GetDay1Part1()
    {
        return Masses.Select(x => (int)(x / 3) - 2).Sum();
    }

    private int GetFuel(int mass)
    {
        var x = (mass / 3) - 2;
        if (x <= 0)
        {
            return 0;
        }

        return x + GetFuel(x);
    }

    public long GetDay1Part2()
    {
        return Masses.Select(x => GetFuel(x)).Sum();
    }
}