using DesignPatterns.Decorator.Component;

namespace DesignPatterns.Decorator.Decorator
{
    public class PizzaDecorator : Pizza
    {
        protected readonly Pizza _pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost();
        }

        public override string GetDescription()
        {
            return _pizza.Description;
        }
    }
}
