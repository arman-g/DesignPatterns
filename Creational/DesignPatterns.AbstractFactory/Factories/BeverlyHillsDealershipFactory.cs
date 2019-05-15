using System;
using DesignPatterns.AbstractFactory.Abstractions;
using DesignPatterns.AbstractFactory.Products;

namespace DesignPatterns.AbstractFactory.Factories
{
    public class BeverlyHillsDealershipFactory : DealershipFactory
    {
        public override Car CreateAudiA5()
        {
            return new AudiA5
            {
                Price = 45000,
                DownPayment = 3000,
                InStack = true
            };
        }

        public override Car CreateLexusNx200H()
        {
            return new LexusNx200H
            {
                Price = 43000,
                DownPayment = 2000,
                InStack = true
            };
        }

        public override Car CreateToyotaCamryLe()
        {
            return new ToyotaCamryLe();
        }
    }
}
