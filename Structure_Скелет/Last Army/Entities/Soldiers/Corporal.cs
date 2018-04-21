using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double overallSkillMiltiplier = 2.5;
    private const int regenerationIncrease = 10;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife"
        };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
    protected override double OverallSkillMultiplier => overallSkillMiltiplier;
    protected override int RegenerationIncrease => regenerationIncrease;
}