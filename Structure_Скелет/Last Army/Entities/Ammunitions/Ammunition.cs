public abstract class Ammunition : IAmmunition
{
    private const int wearLevelMultiplier = 100;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * wearLevelMultiplier;
    }

    public string Name { get; }

    public double Weight { get; protected set; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
