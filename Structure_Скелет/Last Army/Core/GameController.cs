using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(army, wareHouse);
        this.soldierFactory = new SoldiersFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();
        string entity = data[0];

        if (entity.Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                var soldier = soldierFactory.CreateSoldier(data[1], data[2], int.Parse(data[3]),
                    double.Parse(data[4]), double.Parse(data[5]));

                if (!wareHouse.TryEquipSoldier(soldier))
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierCannotBeEquiped, soldier.GetType().Name, soldier.Name));
                }

                this.army.AddSoldier(soldier);
            }

        }
        else if (entity.Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(name, number);
        }
        else if (entity.Equals("Mission"))
        {
            string difficultyLevel = data[1];
            double neededPoints = double.Parse(data[2]);

            writer.AppendLine(this.missionController.PerformMission(this.missionFactory.CreateMission(difficultyLevel, neededPoints)));
        }
    }

    public void RequestResult()
    {
        missionController.FailMissionsOnHold();

        writer.AppendLine(OutputMessages.Results);
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, missionController.FailedMissionCounter));

        writer.AppendLine(OutputMessages.Soldiers);
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }
    }

    /*  private void AddAmmunitions(Ammunition ammunition)
      {
          if (!this.WearHouse.ContainsKey(ammunition.Name))
          {
              this.WearHouse[ammunition.Name] = new List<Ammunition>();
              this.WearHouse[ammunition.Name].Add(ammunition);
          }
          else
          {
              this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
          }
      }

      private void AddSoldierToArmy(Soldier soldier, string type)
      {
          if (!soldier.CheckIfSoldierCanJoinTeam())
          {
              throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
          }

          if (!this.Army.ContainsKey(type))
          {
              this.Army[type] = new List<Soldier>();
          }
          this.Army[type].Add(soldier); 
      } */
}