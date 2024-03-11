namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class ImpulseEngineClassC : ImpulseEngineBase
{
    public ImpulseEngineClassC(double fuelConsumption, double startVelocity)
        : base(fuelConsumption, startVelocity) { }

    public override void OneSecondPassed()
    {
        TotalPath += Velocity;
    }
}