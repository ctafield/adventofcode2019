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

        public object Clone()
        {
            return new XY
            {
                X = X,
                Y = Y
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
                    Positions.Add(XY.Clone() as XY);
                }
            }
            else
            {
                for (var i = 0; i > val; i--)
                {
                    XY.X -= 1;
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
                    Positions.Add(XY.Clone() as XY);
                }
            }
            else
            {
                for (var i = 0; i > val; i--)
                {
                    XY.Y -= 1;
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

    public int GetDay3Part1()
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
        
        var crosses = w1_position.Positions.Intersect(w2_position.Positions, new PositionComparer());
        foreach (var cross in crosses)
        {
            var distance = Math.Abs(cross.X) + Math.Abs(cross.Y);
            distances.Add(distance);
        }

        return distances.Min();
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