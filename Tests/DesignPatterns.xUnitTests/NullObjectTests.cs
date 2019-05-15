using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.NullObject.Abstractions;
using DesignPatterns.NullObject.Repositories;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class NullObjectTests
    {
        private readonly ITestOutputHelper _output;

        public NullObjectTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory(DisplayName = "Positive Case - Existing Automobile")]
        [InlineData("Audi A5", "8808a06e-0103-4963-8895-0e2cb55024c1")]
        [InlineData("BMW i3", "13225d7e-89f9-4f88-baca-30f3cb4ed3b6")]
        public void ExistingAutomobile_Test(string name, string id)
        {
            var autoRepository = new AutoRepository();

            var automobile = autoRepository.Find(name);

            Assert.NotSame(AutomobileBase.Null, automobile);
            Assert.Equal(name, automobile.Name);
            Assert.Equal(id, automobile.Id.ToString());

            Assert.Equal(CarStatus.On, automobile.Start());
            Assert.Equal(CarStatus.Off, automobile.Stop());

            _output.WriteLine("Automobile Name: '{0}', ID: '{1}'",
                automobile.Name,
                automobile.Id);
        }

        [Fact(DisplayName = "Negative Case - Non Existing Automobile")]
        public void NonExistingAutomobile_Test()
        {
            var autoRepository = new AutoRepository();

            var automobile = autoRepository.Find("Toyota Camry");

            Assert.Same(AutomobileBase.Null, automobile);
            Assert.Equal(string.Empty, automobile.Name);
            Assert.Equal(Guid.Empty, automobile.Id);

            Assert.NotEqual(CarStatus.On, automobile.Start());
            Assert.NotEqual(CarStatus.Off, automobile.Stop());

            _output.WriteLine("Automobile Name: '{0}', ID: '{1}'",
                automobile.Name,
                automobile.Id);
        }
    }
}
