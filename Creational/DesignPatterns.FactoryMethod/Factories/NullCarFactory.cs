using DesignPatterns.FactoryMethod.Abstractions;

namespace DesignPatterns.FactoryMethod.Factories
{
    public class NullCarFactory : CarFactoryBase
    {
        public override CarBase Create(decimal miles = 0)
        {
            return CarBase.Null;
        }
    }
}
