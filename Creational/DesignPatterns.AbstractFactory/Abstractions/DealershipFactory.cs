namespace DesignPatterns.AbstractFactory.Abstractions
{
    public abstract class DealershipFactory
    {
        public abstract Car CreateAudiA5();
        public abstract Car CreateLexusNx200H();
        public abstract Car CreateToyotaCamryLe();
    }
}
