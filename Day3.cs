using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public class Day3
{
    private string[] Wire1Directions { get; set; }

    private string[] Wire2Directions { get; set; }

    public class XY : ICloneable
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public int Steps { get; set; } = 0;

        public object Clone()
        {
            return new XY
            {
                X = X,
                Y = Y,
                Steps = Steps
            };
        }
    }

    public class Coords
    {
        public XY XY { get; set; } = new XY { X = 0, Y = 0 };

        public List<XY> Positions { get; set; } = new List<XY>();

        public void Move(string direction, int amount)
        {
            switch (direction)
            {
                case "U":
                    MoveY(amount);
                    break;
                case "D":
                    MoveY(-amount);
                    break;
                case "L":
                    MoveX(-amount);
                    break;
                case "R":
                    MoveX(amount);
                    break;
            }
        }

        public void MoveX(int val)
        {
            if (val > 0)
            {
                for (var i = 0; i < val; i++)
                {
                    XY.X += 1;
                    XY.Steps += 1;
                    Positions.Add(XY.Clone() as XY);
                }
            }
            else
            {
                for (var i = 0; i > val; i--)
                {
                    XY.X -= 1;
                    XY.Steps += 1;
                    Positions.Add(XY.Clone() as XY);
                }
            }
        }

        public void MoveY(int val)
        {
            if (val > 0)
            {
                for (var i = 0; i < val; i++)
                {
                    XY.Y += 1;
                    XY.Steps += 1;
                    Positions.Add(XY.Clone() as XY);
                }
            }
            else
            {
                for (var i = 0; i > val; i--)
                {
                    XY.Y -= 1;
                    XY.Steps += 1;
                    Positions.Add(XY.Clone() as XY);
                }
            }
        }
    }

    public Day3(string directions)
    {
        var allDirections = directions.Split(Environment.NewLine);

        Wire1Directions = allDirections[0].Split(',', StringSplitOptions.None).ToArray();
        Wire2Directions = allDirections[1].Split(',', StringSplitOptions.None).ToArray();
    }

    public void GetDay3()
    {
        var w1_position = new Coords();
        var w2_position = new Coords();

        foreach (var direction in Wire1Directions)
        {
            var dir = direction.Substring(0, 1);
            var amount = int.Parse(direction.Substring(1));
            w1_position.Move(dir, amount);
        }

        foreach (var direction in Wire2Directions)
        {
            var dir = direction.Substring(0, 1);
            var amount = int.Parse(direction.Substring(1));
            w2_position.Move(dir, amount);
        }

        // Get all the matches
        var distances = new List<int>();
        var moves = new List<int>();

        var crosses = w1_position.Positions.Intersect(w2_position.Positions, new PositionComparer());
        foreach (var cross in crosses)
        {
            // Part 1
            var distance = Math.Abs(cross.X) + Math.Abs(cross.Y);
            distances.Add(distance);

            // Part 2
            var index1 = w1_position.Positions.FirstOrDefault(w1 => w1.X == cross.X && w1.Y == cross.Y);
            var steps1 = index1.Steps;

            var index2 = w2_position.Positions.FirstOrDefault(w2 => w2.X == cross.X && w2.Y == cross.Y);
            var steps2 = index2.Steps;

            moves.Add(steps1 + steps2);
        }

        var shortest = distances.Min();
        var smallestMoves = moves.Min();

        Console.WriteLine($"Day 3 - pt1. {shortest}");
        Console.WriteLine($"Day 3 - pt2. {smallestMoves}");
    }
    private class PositionComparer : IEqualityComparer<XY>
    {
        public bool Equals([AllowNull] XY x, [AllowNull] XY y)
        {
            return x?.X == y?.X && x?.Y == y?.Y;
        }

        public int GetHashCode([DisallowNull] XY obj)
        {
            return 1000000 * obj.X + obj.Y;
        }
    }
}