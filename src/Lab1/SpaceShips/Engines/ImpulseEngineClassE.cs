using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    public ImpulseEngineClassE(double fuelConsumption, double startVelocity)
        : base(fuelConsumption, startVelocity) { }

    public override void OneSecondPassed()
    {
        TotalPath += Velocity;
        Velocity *= Math.E;
    }
}