using DesignPatterns.Facade.Facades;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class FacadeTests
    {
        private readonly ITestOutputHelper _output;

        public FacadeTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Current Temperature")]
        public void CurrentTemperatureByZipCode_Test()
        {
            const string zipcode = "91411";
            var temperatureFacade = new TemperatureLookupFacade();
            var localTemp = temperatureFacade.GetTemperature(zipcode);

            _output.WriteLine("The current temperature is {0}F/{1}C. in {2}, {3}",
                localTemp.Fahrenheit.ToString("F1"),
                localTemp.Celsius.ToString("F1"),
                localTemp.City,
                localTemp.State);
        }
    }
}
