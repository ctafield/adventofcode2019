using System;
using System.Linq;

public class Day2
{
    private int[] OpCodes { get; set; }

    public Day2(string opcodes)
    {
        OpCodes = opcodes.Split(',', StringSplitOptions.None).Select(x => int.Parse(x)).ToArray();
    }

    private void ProcessOpCodes()
    {
        for (var i = 0; i < OpCodes.Length; i += 4)
        {
            var op = OpCodes[i];

            if (op == 99)
            {
                return;
            }

            var source1 = OpCodes[i + 1];
            var source2 = OpCodes[i + 2];
            var target = OpCodes[i + 3];

            if (op == 1)
            {
                OpCodes[target] = OpCodes[source1] + OpCodes[source2];
            }
            else if (op == 2)
            {
                OpCodes[target] = OpCodes[source1] * OpCodes[source2];
            }
            else 
            {
                throw new Exception("invalid op");
            }
        }
    }

    public long GetDay2Part1()
    {
        OpCodes[1] = 12;
        OpCodes[2] = 2;

        ProcessOpCodes();

        return OpCodes[0];
    }

    public long GetDay2Part2(int val1, int val2)
    {
        OpCodes[1] = val1;
        OpCodes[2] = val2;

        ProcessOpCodes();

        return OpCodes[0];
    }
}