public class Easy : Mission
{
    private const string name = "Suppression of civil rebellion";
    private const int enduranceRequired = 20;
    private const int wearLevelDecrement = 30;

    public Easy(double scoreToComplete) : base(name, enduranceRequired, wearLevelDecrement, scoreToComplete)
    {

    }
}