using System;
using System.Linq;

public class Day2
{
    private int[] OpCodes { get; set; }

    public Day2(string opcodes)
    {
        OpCodes = opcodes.Split(',', StringSplitOptions.None).Select(x => int.Parse(x)).ToArray();
    }

    private void ProcessOpCodes(int[] opCodes)
    {
        for (var i = 0; i < opCodes.Length; i ++)
        {
            var op = opCodes[i];

            if (op == 99)
            {
                break;
            }

            if (op == 1)
            {
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                opCodes[target] = opCodes[source1] + opCodes[source2];
            }
            else if (op == 2)
            {
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                opCodes[target] = opCodes[source1] * opCodes[source2];
            }
            else 
            {
                throw new Exception("invalid op");
            }
        }
    }

    public long GetDay2Part1()
    {
        var opCodes = (int[])OpCodes.Clone();

        opCodes[1] = 12;
        opCodes[2] = 2;

        ProcessOpCodes(opCodes);

        return opCodes[0];
    }

    public long GetDay2Part2()
    {

        for (var i = 0; i < 99; i++) {
            for (var j = 0; j < 99; j++) {

                var opCodes = (int[])OpCodes.Clone();

                opCodes[1] = i;
                opCodes[2] = j;

                ProcessOpCodes(opCodes);

                if (opCodes[0] == 19690720) {
                    return 100 * i + j;
                }
            }
        }

        return 0;
    }
}