using DesignPatterns.AbstractFactory.Abstractions;
using DesignPatterns.AbstractFactory.Products;

namespace DesignPatterns.AbstractFactory.Factories
{
    public class VanNuysDealershipFactory : DealershipFactory
    {
        public override Car CreateAudiA5()
        {
            return new AudiA5
            {
                Price = 43000,
                DownPayment = 2000,
                InStack = true
            };
        }

        public override Car CreateLexusNx200H()
        {
            return new LexusNx200H
            {
                Price = 40000,
                DownPayment = 2000,
                InStack = true
            };
        }

        public override Car CreateToyotaCamryLe()
        {
            return new ToyotaCamryLe
            {
                Price = 20000,
                DownPayment = 2000,
                InStack = true
            };
        }
    }
}
