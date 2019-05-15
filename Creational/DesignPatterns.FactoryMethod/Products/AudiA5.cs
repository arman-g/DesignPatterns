using DesignPatterns.FactoryMethod.Abstractions;

namespace DesignPatterns.FactoryMethod.Products
{
    public class AudiA5 : CarBase
    {
        public AudiA5(
            decimal miles = 0) :
            base(
                "V2.0L",
                2,
                "Audi A5",
                "Sports Coupe",
                45000,
                miles)
        {}
    }
}
