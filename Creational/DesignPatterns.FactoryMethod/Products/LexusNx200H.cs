using DesignPatterns.FactoryMethod.Abstractions;

namespace DesignPatterns.FactoryMethod.Products
{
    public class LexusNx200H : CarBase
    {
        public LexusNx200H(
            decimal miles = 0) : 
            base(
                "V2.0L", 
                4, 
                "Lexus Nx 200h", 
                "Mini SUV",
                40000,
                miles)
        {}
    }
}
