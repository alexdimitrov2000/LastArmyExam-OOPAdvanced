public class Hard : Mission
{
    private const string name = "Disposal of terrorists";
    private const int enduranceRequired = 80;
    private const int wearLevelDecrement = 70;

    public Hard(double scoreToComplete) : base(name, enduranceRequired, wearLevelDecrement, scoreToComplete)
    {

    }
}