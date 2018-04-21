public class Medium : Mission
{
    private const string name = "Capturing dangerous criminals";
    private const int enduranceRequired = 50;
    private const int wearLevelDecrement = 50;

    public Medium(double scoreToComplete) : base(name, enduranceRequired, wearLevelDecrement, scoreToComplete)
    {

    }
}