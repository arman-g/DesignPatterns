using DesignPatterns.AbstractFactory.Clients;
using DesignPatterns.AbstractFactory.Factories;
using Xunit;

namespace DesignPatterns.xUnitTests
{
    public class AbstractFactoryTests
    {
        [Fact(DisplayName = "Van Nuys - Audi A5")]
        public void VanNuysDealership_AudiA5_Test()
        {
            var inventory = new DealershipInventory(new VanNuysDealershipFactory());

            Assert.True(inventory.AudiA5.InStack);
            Assert.Equal("Audi A5", inventory.AudiA5.Description);
            Assert.Equal(2, inventory.AudiA5.Doors);
            Assert.Equal("V2.0L", inventory.AudiA5.Engine);
            Assert.Equal("Sports Coupe", inventory.AudiA5.Type);
            Assert.Equal(0, inventory.AudiA5.Miles);
            Assert.Equal(43000, inventory.AudiA5.Price);
            Assert.Equal(2000, inventory.AudiA5.DownPayment);
        }

        [Fact(DisplayName = "Van Nuys - Lexus Nx 200H")]
        public void VanNuysDealership_LexusNx200H_Test()
        {
            var inventory = new DealershipInventory(new VanNuysDealershipFactory());

            Assert.True(inventory.LexusNx200H.InStack);
            Assert.Equal("Lexus Nx 200h", inventory.LexusNx200H.Description);
            Assert.Equal(4, inventory.LexusNx200H.Doors);
            Assert.Equal("V2.0L", inventory.LexusNx200H.Engine);
            Assert.Equal("Mini SUV", inventory.LexusNx200H.Type);
            Assert.Equal(0, inventory.LexusNx200H.Miles);
            Assert.Equal(40000, inventory.LexusNx200H.Price);
            Assert.Equal(2000, inventory.LexusNx200H.DownPayment);
        }

        [Fact(DisplayName = "Van Nuys - Toyota Camry LE")]
        public void VanNuysDealership_ToyotaCamryLe_Test()
        {
            var inventory = new DealershipInventory(new VanNuysDealershipFactory());

            Assert.True(inventory.ToyotaCamryLe.InStack);
            Assert.Equal("Toyota Camry LE", inventory.ToyotaCamryLe.Description);
            Assert.Equal(4, inventory.ToyotaCamryLe.Doors);
            Assert.Equal("V1.8L", inventory.ToyotaCamryLe.Engine);
            Assert.Equal("Sedan", inventory.ToyotaCamryLe.Type);
            Assert.Equal(0, inventory.ToyotaCamryLe.Miles);
            Assert.Equal(20000, inventory.ToyotaCamryLe.Price);
            Assert.Equal(2000, inventory.ToyotaCamryLe.DownPayment);
        }

        [Fact(DisplayName = "Beverly Hills - Audi A5")]
        public void BeverlyHillsDealership_AudiA5_Test()
        {
            var inventory = new DealershipInventory(new BeverlyHillsDealershipFactory());

            Assert.True(inventory.AudiA5.InStack);
            Assert.Equal("Audi A5", inventory.AudiA5.Description);
            Assert.Equal(2, inventory.AudiA5.Doors);
            Assert.Equal("V2.0L", inventory.AudiA5.Engine);
            Assert.Equal("Sports Coupe", inventory.AudiA5.Type);
            Assert.Equal(0, inventory.AudiA5.Miles);
            Assert.Equal(45000, inventory.AudiA5.Price);
            Assert.Equal(3000, inventory.AudiA5.DownPayment);
        }

        [Fact(DisplayName = "Beverly Hills - Lexus Nx 200H")]
        public void BeverlyHillsDealership_LexusNx200H_Test()
        {
            var inventory = new DealershipInventory(new BeverlyHillsDealershipFactory());
            
            Assert.True(inventory.LexusNx200H.InStack);
            Assert.Equal("Lexus Nx 200h", inventory.LexusNx200H.Description);
            Assert.Equal(4, inventory.LexusNx200H.Doors);
            Assert.Equal("V2.0L", inventory.LexusNx200H.Engine);
            Assert.Equal("Mini SUV", inventory.LexusNx200H.Type);
            Assert.Equal(0, inventory.LexusNx200H.Miles);
            Assert.Equal(43000, inventory.LexusNx200H.Price);
            Assert.Equal(2000, inventory.LexusNx200H.DownPayment);
        }

        [Fact(DisplayName = "Beverly Hills - Toyota Camry LE")]
        public void BeverlyHillsDealership_ToyotaCamryLe_Test()
        {
            var inventory = new DealershipInventory(new BeverlyHillsDealershipFactory());

            Assert.False(inventory.ToyotaCamryLe.InStack);
        }
    }
}
