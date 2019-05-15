using DesignPatterns.FactoryMethod.Abstractions;
using DesignPatterns.FactoryMethod.Factories;
using Xunit;

namespace DesignPatterns.xUnitTests
{
    public class FactoryMethodTests
    {
        [Fact(DisplayName = "Positive Case - Audi A5 Factory")]
        public void AudiA5Factory_Test()
        {
            var factory = new AudiA5Factory();
            var car = factory.Create();

            Assert.Equal("Audi A5", car.Description);
            Assert.Equal(2, car.Doors);
            Assert.Equal("V2.0L", car.Engine);
            Assert.Equal(0, car.Miles);
            Assert.Equal(45000, car.Price);
        }

        [Fact(DisplayName = "Positive Case - Audi A5 Add Miles")]
        public void AudiA5_Add_Miles_Test()
        {
            var factory = new AudiA5Factory();
            var car = factory.Create();

            car.AddMiles(1050);
            car.AddMiles(-100);
            car.AddMiles(0);

            Assert.Equal(1050, car.Miles);
        }

        [Fact(DisplayName = "Positive Case - Lexus Nx 200H Factory")]
        public void LexusNx200HFactory_Test()
        {
            var factory = new LexusNx200HFactory();
            var car = factory.Create();

            Assert.Equal("Lexus Nx 200h", car.Description);
            Assert.Equal(4, car.Doors);
            Assert.Equal("V2.0L", car.Engine);
            Assert.Equal(0, car.Miles);
            Assert.Equal(40000, car.Price);
        }

        [Fact(DisplayName = "Positive Case - Lexus Nx 200H Add Miles")]
        public void LexusNx200T_Add_Miles_Test()
        {
            var factory = new AudiA5Factory();
            var car = factory.Create();

            car.AddMiles(1050);
            car.AddMiles(-100);
            car.AddMiles(0);

            Assert.Equal(1050, car.Miles);
        }

        [Fact(DisplayName = "Positive Case - Null Factory and Car")]
        public void NullFactory_Test()
        {
            var factory = new NullCarFactory();

            var nullCar = factory.Create();
            Assert.Same(CarBase.Null, nullCar);
            Assert.Equal(string.Empty, nullCar.Description);
            Assert.Equal(0, nullCar.Doors);
            Assert.Equal(string.Empty, nullCar.Engine);
            Assert.Equal(0, nullCar.Miles);
            Assert.Equal(0, nullCar.Price);
        }
    }
}
