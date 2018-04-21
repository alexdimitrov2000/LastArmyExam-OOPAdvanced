using System;
using System.Linq;
using System.Reflection;

public class SoldiersFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == soldierTypeName);

        ISoldier instance = (ISoldier)Activator.CreateInstance(type, name, age, experience, endurance);

        return instance;
    }
}