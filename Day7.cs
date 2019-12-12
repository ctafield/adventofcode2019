using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Day7
{
    private class OpCodeProcessor
    {
        public Queue<int> Inputs { get; set; } = new Queue<int>();

        public int Output { get; set; }

        public void ProcessOpCodes(int[] opCodes)
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
                    opCodes[target] = Inputs.Dequeue();
                }
                else if (op == 4)
                {
                    var target = opCodes[++i];

                    var val1 = (modeP1 == 1) ? target : opCodes[target];
                    Output = val1;
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
    }


    private int[] OpCodes { get; set; }

    private int _input;

    public Day7(string opcodes)
    {
        OpCodes = opcodes.Split(',', StringSplitOptions.None).Select(x => int.Parse(x)).ToArray();
    }

    public void GetPart1()
    {
        var generatedInputs = new List<int[]>();

        for (var a = 0; a <= 4; a++)
        {
            for (var b = 0; b <= 4; b++)
            {
                for (var c = 0; c <= 4; c++)
                {
                    for (var d = 0; d <= 4; d++)
                    {
                        for (var e = 0; e <= 4; e++)
                        {
                            var array = new int[]
                            {
                                a,
                                b,
                                c,
                                d,
                                e
                            };

                            if (a == b || a == c || a == d || a == e)
                            {
                                continue;
                            }
                            if (b == c || b == d || b == e)
                            {
                                continue;
                            }
                            if (c == d || c == e)
                            {
                                continue;
                            }
                            if (d == e)
                            {
                                continue;
                            }

                            generatedInputs.Add(array);
                        }
                    }
                }
            }
        }

        var highest = 0;

        foreach (var inputs in generatedInputs)
        {
            var amp1 = new OpCodeProcessor();
            var amp2 = new OpCodeProcessor();
            var amp3 = new OpCodeProcessor();
            var amp4 = new OpCodeProcessor();
            var amp5 = new OpCodeProcessor();

            OpCodeProcessor[] amps = {
                amp1,
                amp2,
                amp3,
                amp4,
                amp5
            };

            int output = 0;
            for (var i = 0; i < amps.Length; i++)
            {
                amps[i].Inputs.Enqueue(inputs[i]);
                amps[i].Inputs.Enqueue(output);

                amps[i].ProcessOpCodes(OpCodes);
                output = amps[i].Output;
            }

            if (output > highest)
                highest = output;
        }

        Console.WriteLine($"Final output: {highest}");
    }
}