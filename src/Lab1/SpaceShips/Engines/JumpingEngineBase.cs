using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public abstract class JumpingEngineBase
{
    protected JumpingEngineBase()
    {
        FuelConsumption = 0;
        JumpingAbility = 0;
    }

    protected JumpingEngineBase(double fuelConsumption, double jumpingAbility)
    {
        if (fuelConsumption <= 0)
        {
            throw new ArgumentException("Fuel consumption cannot be negative");
        }

        if (jumpingAbility <= 0)
        {
            throw new ArgumentException("Jumping ability cannot be negative");
        }

        FuelConsumption = fuelConsumption;
        JumpingAbility = jumpingAbility;
    }

    public double FuelConsumption { get; set; }
    public double JumpingAbility { get; set; }

    public abstract double FuelWaste(double distance);
}