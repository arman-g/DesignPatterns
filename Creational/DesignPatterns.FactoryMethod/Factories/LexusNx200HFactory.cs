using DesignPatterns.FactoryMethod.Abstractions;
using DesignPatterns.FactoryMethod.Products;

namespace DesignPatterns.FactoryMethod.Factories
{
    /// <inheritdoc />
    /// <summary>
    /// Represents Factory Method design pattern example.
    /// </summary>
    /// /// <remarks>https://www.dofactory.com/net/factory-method-design-pattern</remarks>
    public class LexusNx200HFactory : CarFactoryBase
    {
        public override CarBase Create(decimal miles = 0)
        {
            return new LexusNx200H(miles);
        }
    }
}
