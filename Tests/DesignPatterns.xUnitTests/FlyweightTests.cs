using Xunit;
using DesignPatterns.Flyweight;
using DesignPatterns.Flyweight.DomainObjects;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class FlyweightTests
    {
        private readonly ITestOutputHelper _output;

        public FlyweightTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Shared Auto Type Instances")]
        public void Shared_auto_type_instances_Test()
        {
            var autoFactory = new AutoFactory();
            var audi1 = autoFactory.GetAuto(typeof(Audi));
            var audi2 = autoFactory.GetAuto(typeof(Audi));
            var bmw1 = autoFactory.GetAuto(typeof(Bmw));
            var bmw2 = autoFactory.GetAuto(typeof(Bmw));

            Assert.Same(audi1, audi2);
            Assert.Same(bmw1, bmw2);

            Assert.NotSame(audi1, bmw1);
            Assert.NotSame(audi2, bmw2);

            Assert.NotSame(audi1, bmw2);
            Assert.NotSame(audi2, bmw1);

            _output.WriteLine($"{audi1.GetType().Name} 2010 - Market Price {audi1.CalculatePrice(2010, 75000, 40000):C2}");
            _output.WriteLine($"{bmw1.GetType().Name} 2010 - Market Price {bmw1.CalculatePrice(2010, 75000, 40000):C2}");
            _output.WriteLine($"{audi2.GetType().Name} 2018 - Market Price {audi2.CalculatePrice(2018, 2000, 40000):C2}");
            _output.WriteLine($"{bmw2.GetType().Name} 2018 - Market Price {bmw2.CalculatePrice(2018, 2000, 40000):C2}");
        }
    }
}
