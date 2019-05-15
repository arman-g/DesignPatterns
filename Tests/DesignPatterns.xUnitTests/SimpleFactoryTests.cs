using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.SimpleFactory.Factories;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class SimpleFactoryTests
    {
        private readonly ITestOutputHelper _output;

        public SimpleFactoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory(DisplayName = "Positive Case - Existing Automobile")]
        [InlineData("Audi A5")]
        [InlineData("BMW i3")]
        public void ExistingAutomobile_Test(string name)
        {
            var autoFactory = new AutoFactory();

            var automobile = autoFactory.CreateInstance(name);
            Assert.Equal(name, automobile.Name);

            automobile.TurnOn();
            Assert.Equal(CarStatus.On, automobile.Status);
            _output.WriteLine(automobile.GetStatus());

            automobile.TurnOff();
            Assert.Equal(CarStatus.Off, automobile.Status);
            _output.WriteLine(automobile.GetStatus());
        }

        [Fact(DisplayName = "Negative Case - Non Existing Automobile")]
        public void NonExistingAutomobile_Test()
        {
            var autoFactory = new AutoFactory();

            var automobile = autoFactory.CreateInstance("Toyota");
            Assert.NotEqual(CarStatus.On | CarStatus.Off, automobile.Status);

            automobile.TurnOn();
            Assert.NotEqual(CarStatus.On, automobile.Status);
            automobile.TurnOff();
            Assert.NotEqual(CarStatus.Off, automobile.Status);

            Assert.Equal(string.Empty, automobile.Name);
            Assert.Equal(string.Empty, automobile.GetStatus());
        }
    }
}
