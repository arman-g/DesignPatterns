using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.Decorator;

namespace DesignPatterns.Decorator.ConcreteDecorator
{
    public class Mushroom : PizzaDecorator
    {
        public Mushroom(Pizza pizza) : base(pizza)
        {
            Description = nameof(Mushroom);
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
