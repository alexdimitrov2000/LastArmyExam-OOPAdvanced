using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
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
}
