using System;
using System.Collections.Generic;
using System.Linq;

public class Day6
{
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
            if (childPlanet == null) {
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
}