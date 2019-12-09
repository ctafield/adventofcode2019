using System;
using System.Collections.Generic;
using System.Linq;

public class Day6
{
    private const string COM = "COM";

    private const string YOU = "YOU";

    private const string SANTA = "SAN";

    public class Planet
    {
        public string Id { get; set; }

        public IList<string> Children { get; set; }
    }

    private IList<Planet> Planets { get; set; } = new List<Planet>();

    public Day6(string[] input)
    {
        foreach (var planet in input)
        {
            var planets = planet.Split(')');
            var planetA = planets[0];
            var planetB = planets[1];

            var existing = Planets.FirstOrDefault(p => p.Id == planetA);
            if (existing == null)
            {
                Planets.Add(new Planet
                {
                    Id = planetA,
                    Children = new List<string> { planetB }
                });
            }
            else
            {
                existing.Children.Add(planetB);
            }
        }
    }

    private int GetAllChildren(Planet planet)
    {
        var total = 0;
        foreach (var cp in planet.Children)
        {
            total += 1;
            var childPlanet = Planets.FirstOrDefault(p => p.Id == cp);
            if (childPlanet == null)
            {
                continue;
            }
            total += GetAllChildren(childPlanet);
        }

        return total;
    }

    public int GetPart1()
    {
        var total = 0;

        foreach (var planet in Planets)
        {
            total += GetAllChildren(planet);
        }

        return total;
    }

    private IList<string> GetPath(string target, string endPlanet)
    {
        var current = Planets.FirstOrDefault(x => x.Children.Contains(target));
        var paths = new List<string> {
            current.Id
        };

        while (current != null && current.Id != endPlanet)
        {
            current = Planets.FirstOrDefault(x => x.Children.Contains(current.Id));
            if (current != null)
            {
                paths.Add(current.Id);
            }
        }

        return paths;
    }

    public int GetPart2()
    {

        // get path to you
        var youPath = GetPath(YOU, COM);
        // get path to santa
        var santaPath = GetPath(SANTA, COM);

        // get the first time they converge
        var cross = youPath.Intersect(santaPath).FirstOrDefault();
        
        // now count steps from YOU to convergence point
        var youSteps = GetPath(YOU, cross).Count() - 1;
        // now count steps from SANTA to convergence point
        var santaSteps = GetPath(SANTA, cross).Count() - 1;

        return youSteps + santaSteps;
    }
}