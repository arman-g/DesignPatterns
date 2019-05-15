namespace DesignPatterns.Composite.Abstractions
{
    public interface IParty
    {
        string Name { get; set; }
        decimal Rate { get; set; }
        decimal PayOutAmount { get; set; }

        string Stats(int indent = 0);
        void Validate();
    }
}
