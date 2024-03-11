using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public abstract class ImpulseEngineBase
{
    protected ImpulseEngineBase(double fuelConsumption, double velocity)
    {
        if (fuelConsumption <= 0)
        {
            throw new ArgumentException("Fuel consumption cannot be negative");
        }

        if (velocity < 0)
        {
            throw new ArgumentException("Velocity cannot be negative");
        }

        TotalPath = 0;
        Velocity = velocity;
        FuelConsumption = fuelConsumption;
        StartVelocity = velocity;
    }

    public double TotalPath { get; protected set; }
    public double FuelConsumption { get; init; }
    protected double Velocity { get; set; }
    private double StartVelocity { get; init; }

    public abstract void OneSecondPassed();

    public void Reset()
    {
        TotalPath = 0;
        Velocity = StartVelocity;
    }
}