using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == name);

        IAmmunition instance = (IAmmunition)Activator.CreateInstance(type, name);

        return instance;
    }
}