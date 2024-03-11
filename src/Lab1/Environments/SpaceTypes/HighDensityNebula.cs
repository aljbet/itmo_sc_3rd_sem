using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;

public class HighDensityNebula : SpaceBase
{
    public HighDensityNebula(double length, int kAntimatter = 1)
        : base(length)
    {
        if (kAntimatter < 0)
        {
            throw new ArgumentException("Amount of antimatter cannot be negative");
        }

        Antimatter = new Obstacle(kAntimatter);
    }

    public Obstacle Antimatter { get; init; }
}