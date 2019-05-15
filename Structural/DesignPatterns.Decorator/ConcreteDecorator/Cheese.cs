using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.Decorator;

namespace DesignPatterns.Decorator.ConcreteDecorator
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = nameof(Cheese);
        }

        public override string GetDescription()
        {
            return $"{_pizza.GetDescription()}, {Description}";
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.25;
        }
    }
}
