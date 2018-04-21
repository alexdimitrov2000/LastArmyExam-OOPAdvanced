using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double overallSkillMiltiplier = 1.5;
    private const int regenerationIncrease = 10;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
    protected override double OverallSkillMultiplier => overallSkillMiltiplier;
    protected override int RegenerationIncrease => regenerationIncrease;
}