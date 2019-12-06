using System;
using System.Linq;

public class Day5
{
    private int[] OpCodes { get; set; }

    private int _input;

    public Day5(string opcodes)
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
                opCodes[target] = _input;
            }
            else if (op == 4)
            {
                var target = opCodes[++i];

                var val1 = (modeP1 == 1) ? target : opCodes[target];
                Console.WriteLine("Output --> " + val1);
            }
            else if (op == 5)
            {
                // jump if true
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                if (val1 > 0)
                {
                    i = val2 - 1; // +1 gets added on loop.
                    continue;
                }
            }
            else if (op == 6)
            {
                // jump if false
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                if (val1 == 0)
                {
                    i = val2 - 1; // +1 gets added on loop
                    continue;
                }
            }
            else if (op == 7)
            {
                // less than
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                opCodes[target] = (val1 < val2) ? 1 : 0;
            }
            else if (op == 8)
            {
                // equals
                var source1 = opCodes[++i];
                var source2 = opCodes[++i];
                var target = opCodes[++i];

                var val1 = (modeP1 == 1) ? source1 : opCodes[source1];
                var val2 = (modeP2 == 1) ? source2 : opCodes[source2];

                opCodes[target] = (val1 == val2) ? 1 : 0;
            }
            else
            {
                throw new Exception("invalid op");
            }
        }
    }

    public void GetPart1()
    {
        Console.WriteLine("Day 5.");

        Console.WriteLine("Part 1 - Running...");

        _input = 1;
        var part1OpCodes = (int[])OpCodes.Clone();
        ProcessOpCodes(part1OpCodes);

        Console.WriteLine("Tests....");

        var testOps = new[] {
            3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
            1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
            999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
        };

        _input = 7;
        Console.WriteLine("Expect 999");
        var test1 = (int[])testOps.Clone();
        ProcessOpCodes(test1);

        _input = 8;
        Console.WriteLine("Expect 1000");
        var test2 = (int[])testOps.Clone();
        ProcessOpCodes(test2);

        _input = 9;
        Console.WriteLine("Expect 1001");
        var test3 = (int[])testOps.Clone();
        ProcessOpCodes(test3);

        Console.WriteLine("Part 2. Running...");

        _input = 5;
        var part2OpCodes = (int[])OpCodes.Clone();

        ProcessOpCodes(part2OpCodes);

        Console.WriteLine("Day 5 - Ended...");
    }
}