using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int maximumEndurance = 100;
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }
    }

    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        private set
        {
            this.endurance = Math.Min(value, maximumEndurance);
        }
    }

    public double OverallSkill => (this.Age + this.Experience) * this.OverallSkillMultiplier;

    protected abstract double OverallSkillMultiplier { get; }

    protected abstract int RegenerationIncrease { get; }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasUnequippedWeapon = this.Weapons.Values.Any(a => a == null);

        if (hasUnequippedWeapon)
        {
            return false;
        }

        return this.Weapons.Values.All(a => a.WearLevel > 0);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<IAmmunition> weapons = this.Weapons.Values.Where(w => w != null).ToList();

        foreach (var weapon in weapons)
        {
            weapon.DecreaseWearLevel(missionWearLevelDecrement);

            if (weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public void Regenerate()
    {
        this.Endurance += this.RegenerationIncrease + this.Age;
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}