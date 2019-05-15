namespace DesignPatterns.Decorator.Component
{
    public abstract class Pizza
    {
        public string Description { get; set; }

        public abstract string GetDescription();
        public abstract double CalculateCost();
    }
}
