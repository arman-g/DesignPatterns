using DesignPatterns.AbstractFactory.Abstractions;

namespace DesignPatterns.AbstractFactory.Products
{
    public class ToyotaCamryLe : Car
    {
        public ToyotaCamryLe() : base("Toyota Camry LE", "V1.8L", 4, "Sedan")
        {
        }
    }
}
