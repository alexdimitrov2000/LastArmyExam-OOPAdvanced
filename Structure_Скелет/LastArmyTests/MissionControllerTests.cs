using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void MissionControllerPerformMethodFails()
    {
        var army = new Army();
        var warehouse = new WareHouse();
        var missionController = new MissionController(army, warehouse);

        string result = missionController.PerformMission(new Easy(1));

        Assert.That(result.StartsWith("Mission on hold"));
    }

    [Test]
    public void MissionControllerPerformMethodSucceeds()
    {
        IArmy army = new Army();
        IWareHouse warehouse = new WareHouse();
        var missionController = new MissionController(army, warehouse);

        string result = missionController.PerformMission(new Easy(0));

        Assert.IsTrue(result.StartsWith("Mission completed"));
    }
}