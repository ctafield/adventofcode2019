using System;
using System.Linq;

public class Day4
{
    private int[] OpCodes { get; set; }

    public Day4(string opcodes)
    {
        OpCodes = opcodes.Split(',', StringSplitOptions.None).Select(x => int.Parse(x)).ToArray();
    }

    private void ProcessOpCodes(int[] opCodes)
    {
        for (var i = 0; i < opCodes.Length; i++)
        {
            var op = opCodes[i];

            if (op == 99)
            {
                break;
            }

            var modeP1 = 0;
            var modeP2 = 0;
            var modeP3 = 0;

            if (op > 99)
            {
                var ops = op.ToString().PadLeft(5, '0');

                modeP3 = int.Parse(ops.Substring(0, 1));
                modeP2 = int.Parse(ops.Substring(1, 1));
                modeP1 = int.Parse(ops.Substring(2, 1));

                var newOp = ops.Substring(3);

                // update the opcode
                op = int.Parse(newOp);
            }

            if (op == 1)
            {
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                opCodes[target] = val1 + val2;
            }
            else if (op == 2)
            {
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                opCodes[target] = val1 * val2;
            }
            else if (op == 3)
            {
                var target = opCodes[++i];
                opCodes[target] = 1; // todo change?
            }
            else if (op == 4)
            {
                var target = opCodes[++i];
                Console.WriteLine("Output --> " + opCodes[target]);
            }
            else
            {
                throw new Exception("invalid op");
            }
        }
    }

    public void GetPart1()
    {
        Console.WriteLine("Day 4 - pt1. Running...");

        var opCodes = (int[])OpCodes.Clone();

        ProcessOpCodes(opCodes);

        Console.WriteLine("Day 4 - pt1. Ended...");
    }

    public long GetPart2()
    {
        return 0;
    }
}