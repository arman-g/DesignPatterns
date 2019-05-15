using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.ConcreteComponents;
using DesignPatterns.Decorator.ConcreteDecorator;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class DecoratorTests
    {
        private readonly ITestOutputHelper _output;

        public DecoratorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Pizza Order")]
        public void PizzaOrder_Test()
        {
            Pizza largePizza = new LargePizza();
            Assert.Equal(9.00, largePizza.CalculateCost());
            Assert.Equal("Large Pizza", largePizza.GetDescription());

            largePizza = new Cheese(largePizza);
            Assert.Equal(10.25, largePizza.CalculateCost());
            Assert.EndsWith("Cheese", largePizza.GetDescription());

            largePizza = new Pepperoni(largePizza);
            Assert.Equal(11.75, largePizza.CalculateCost());
            Assert.EndsWith("Pepperoni", largePizza.GetDescription());

            largePizza = new Mushroom(largePizza);
            Assert.Equal(13.25, largePizza.CalculateCost());
            Assert.EndsWith("Mushroom", largePizza.GetDescription());

            _output.WriteLine("{0}", largePizza.GetDescription());
            _output.WriteLine("Cost: {0}", largePizza.CalculateCost().ToString("C2"));
        }
    }
}
