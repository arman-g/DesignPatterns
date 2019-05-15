using DesignPatterns.AbstractFactory.Abstractions;

namespace DesignPatterns.AbstractFactory.Clients
{
    public class DealershipInventory
    {
        public Car AudiA5 { get; }
        public Car LexusNx200H { get; }
        public Car ToyotaCamryLe { get; }

        public DealershipInventory(DealershipFactory dealershipFactory)
        {
            AudiA5 = dealershipFactory.CreateAudiA5();
            LexusNx200H = dealershipFactory.CreateLexusNx200H();
            ToyotaCamryLe = dealershipFactory.CreateToyotaCamryLe();
        }
    }
}
