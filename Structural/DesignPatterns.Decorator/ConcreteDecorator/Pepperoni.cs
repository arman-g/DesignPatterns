using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.Decorator;

namespace DesignPatterns.Decorator.ConcreteDecorator
{
    public class Pepperoni : PizzaDecorator
    {
        public Pepperoni(Pizza pizza) : base(pizza)
        {
            Description = nameof(Pepperoni);
        }

        public override string GetDescription()
        {
            return $"{_pizza.GetDescription()}, {Description}";
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.50;
        }
    }
}
