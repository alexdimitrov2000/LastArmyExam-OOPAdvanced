using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == difficultyLevel);

        IMission instance = (IMission)Activator.CreateInstance(type, neededPoints);

        return instance;
    }
}