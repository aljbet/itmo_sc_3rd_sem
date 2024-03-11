using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;

public class CasualSpace : SpaceBase
{
    public CasualSpace(double length, int kAsteroids = 1, int kMeteors = 1)
        : base(length)
    {
        if (kAsteroids < 0)
        {
            throw new ArgumentException("Amount of asteroids cannot be negative");
        }

        if (kMeteors < 0)
        {
            throw new ArgumentException("Amount of meteors cannot be negative");
        }

        Asteroid = new Obstacle(kAsteroids);
        Meteor = new Obstacle(kMeteors);
    }

    public Obstacle Asteroid { get; init; }
    public Obstacle Meteor { get; init; }
}