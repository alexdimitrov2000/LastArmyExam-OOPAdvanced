public abstract class Mission : IMission
{
    protected Mission(string name, double enduranceRequired, double wearLevelDecrement, double scoreToComplete)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.WearLevelDecrement = wearLevelDecrement;
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name { get; }

    public double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public double WearLevelDecrement { get; }
}