using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;

public class NitrineParticlesNebula : SpaceBase
{
    public NitrineParticlesNebula(double length, int kSpaceWhale = 1)
        : base(length)
    {
        if (kSpaceWhale < 0)
        {
            throw new ArgumentException("Amount of space whales cannot be negative");
        }

        SpaceWhale = new Obstacle(kSpaceWhale);
    }

    public Obstacle SpaceWhale { get; init; }
}