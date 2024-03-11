namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;

public abstract class ArmorBase
{
    protected ArmorBase()
    {
        AsteroidStrength = 0;
        MeteorStrength = 0;
    }

    public int AsteroidStrength { get; set; }
    public int MeteorStrength { get; set; }

    public bool IsWorking()
    {
        return AsteroidStrength > 0 && MeteorStrength > 0;
    }

    public void TakeAsteroidDamage()
    {
        AsteroidStrength--;
    }

    public void TakeMeteorDamage()
    {
        MeteorStrength--;
    }
}