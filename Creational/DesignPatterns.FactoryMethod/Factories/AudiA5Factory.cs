using DesignPatterns.FactoryMethod.Abstractions;
using DesignPatterns.FactoryMethod.Products;

namespace DesignPatterns.FactoryMethod.Factories
{
    /// <inheritdoc />
    /// <summary>
    /// Represents Factory Method design pattern example.
    /// </summary>
    /// <remarks>https://www.dofactory.com/net/factory-method-design-pattern</remarks>
    public class AudiA5Factory : CarFactoryBase
    {
        public override CarBase Create(decimal miles = 0)
        {
            return new AudiA5(miles);
        }
    }
}
