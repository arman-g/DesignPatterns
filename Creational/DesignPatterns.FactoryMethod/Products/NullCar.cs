using DesignPatterns.FactoryMethod.Abstractions;

namespace DesignPatterns.FactoryMethod.Products
{
    public class NullCar : CarBase
    {
        public NullCar() :
            base(
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                0)
        { }
    }
}
