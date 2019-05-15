using System;
using DesignPatterns.NullObject.Abstractions;
using DesignPatterns.NullObject.Autos;

namespace DesignPatterns.NullObject.Repositories
{
    public class AutoRepository
    {
        public AutomobileBase Find(string carName)
        {
            if (carName.Contains("Audi", StringComparison.OrdinalIgnoreCase))
            {
                return new Audi();
            }
            if(carName.Contains("bmw", StringComparison.OrdinalIgnoreCase))
            {
                return new Bmw();
            }
            return AutomobileBase.Null;
        }
    }
}
