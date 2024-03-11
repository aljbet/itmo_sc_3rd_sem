using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class JumpingEngineOmega : JumpingEngineBase
{
    public JumpingEngineOmega(double fuelConsumption)
        : base(fuelConsumption, Constants.MediumLength)
    {
    }

    public override double FuelWaste(double distance)
    {
        return distance * Math.Log(distance) * FuelConsumption;
    }
}