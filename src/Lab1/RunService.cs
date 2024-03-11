using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class RunService
{
    public FlightResult Run(ShipBase ship, ICollection<SpaceBase> route)
    {
        ship = ship ?? throw new ArgumentNullException(nameof(ship));
        route = route ?? throw new ArgumentNullException(nameof(route));
        foreach (SpaceBase currentSpace in route)
        {
            switch (currentSpace)
            {
                case CasualSpace space:
                    TryToFly(ship, space);

                    if (ship.ShipFlightResult.CurrentStatus != ShipStatus.Ok) return ship.ShipFlightResult;

                    while (ship.ImpulseEngine.TotalPath < space.Length)
                    {
                        ship.ImpulseEngine.OneSecondPassed();
                    }

                    ship.ShipFlightResult.TotalFuelCost +=
                        ship.ImpulseEngine.FuelConsumption * currentSpace.Length * Constants.FuelCost;
                    ship.ImpulseEngine.Reset();

                    break;
                case HighDensityNebula space:
                    TryToFly(ship, space);

                    if (ship.ShipFlightResult.CurrentStatus != ShipStatus.Ok) return ship.ShipFlightResult;

                    ship.ShipFlightResult.TotalFuelCost += ship.JumpingEngine.FuelWaste(currentSpace.Length) *
                                                           Constants.GravitationalMatterCost;
                    break;
                case NitrineParticlesNebula space:
                    TryToFly(ship, space);

                    if (ship.ShipFlightResult.CurrentStatus != ShipStatus.Ok) return ship.ShipFlightResult;

                    while (ship.ImpulseEngine.TotalPath < currentSpace.Length)
                    {
                        ship.ImpulseEngine.OneSecondPassed();
                    }

                    ship.ShipFlightResult.TotalFuelCost +=
                        ship.ImpulseEngine.FuelConsumption * currentSpace.Length * Constants.FuelCost;
                    ship.ImpulseEngine.Reset();

                    break;
            }

            if (ship.ShipFlightResult.CurrentStatus != ShipStatus.Ok) return ship.ShipFlightResult;
        }

        return ship.ShipFlightResult;
    }

    public ShipBase ChooseBest(ShipBase firstShip, ShipBase secondShip, ICollection<SpaceBase> route)
    {
        FlightResult result1 = Run(firstShip, route);
        FlightResult result2 = Run(secondShip, route);
        if (result1.CurrentStatus == ShipStatus.Ok && result2.CurrentStatus != ShipStatus.Ok)
        {
            return firstShip;
        }

        if (result1.CurrentStatus != ShipStatus.Ok && result2.CurrentStatus == ShipStatus.Ok)
        {
            return secondShip;
        }

        if (result1.CurrentStatus == ShipStatus.Ok && result2.CurrentStatus == ShipStatus.Ok)
        {
            return result1.TotalFuelCost <= result2.TotalFuelCost ? firstShip : secondShip;
        }

        return firstShip.JumpingEngine.JumpingAbility >= secondShip.JumpingEngine.JumpingAbility
            ? firstShip
            : secondShip;
    }

    private void TryToFly(ShipBase ship, CasualSpace space)
    {
        for (int i = 0; i < space.Asteroid.PopulationSize; i++)
        {
            ship.TakeAsteroidDamage();
        }

        for (int i = 0; i < space.Meteor.PopulationSize; i++)
        {
            ship.TakeMeteorDamage();
        }
    }

    private void TryToFly(ShipBase ship, HighDensityNebula space)
    {
        if (ship.JumpingEngine.JumpingAbility < space.Length) ship.ShipFlightResult.CurrentStatus = ShipStatus.Lost;
        else ship.TakeAntimatterDamage();
    }

    private void TryToFly(ShipBase ship, NitrineParticlesNebula space)
    {
        if (ship.HasAntinitrineEmitter) return;
        for (int i = 0; i < space.SpaceWhale.PopulationSize; i++)
        {
            ship.TakeSpaceWhaleDamage();
        }
    }
}