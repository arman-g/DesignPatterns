using LazyInitialization = DesignPatterns.LazyLoad.LazyInitialization;
using System.Linq;
using VirtualProxy = DesignPatterns.LazyLoad.VirtualProxy;
using Xunit;
using Xunit.Abstractions;
using ValueHolder = DesignPatterns.LazyLoad.ValueHolder;
using Ghost = DesignPatterns.LazyLoad.Ghosts;

namespace DesignPatterns.xUnitTests
{
    public class LazyLoadTests
    {
        private readonly ITestOutputHelper _output;

        public LazyLoadTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Lazy Initialization")]
        public void LazyInitialization_Test()
        {
            var company = new LazyInitialization.Company();

            // Lazy initialization of employee objects happen here.
            var employee = company.Employees.FirstOrDefault(x => x.FirstName == "Arman");

            Assert.Equal("Arman", employee.FirstName);
        }

        [Fact(DisplayName = "Positive Case - Lazy .Net Initialization")]
        public void LazyDotNetInitialization_Test()
        {
            var company = new LazyInitialization.CompanyDotNetLazy();

            Assert.False(company.IsEmployeesInitialized);

            // Lazy initialization of employee objects happen here.
            var employee = company.Employees.FirstOrDefault(x => x.FirstName == "Aria");

            Assert.Equal("Aria", employee.FirstName);
        }

        [Fact(DisplayName = "Positive Case - Lazy Virtual Proxy")]
        public void LazyVirtualProxy_Test()
        {
            var testCompanyName = "Microsoft";
            var company = new VirtualProxy.CompanyFactory().CreateFromName(testCompanyName);

            Assert.Equal(testCompanyName, company.CompanyName);

            // Lazy initialization of employee objects happen here.
            var employee = company.Employees.FirstOrDefault(x => x.FirstName == "Aria");

            Assert.Equal("Aria", employee.FirstName);
        }

        [Fact(DisplayName = "Positive Case - Lazy Value Holder")]
        public void LazyValueHolder_Test()
        {
            var testCompanyName = "Microsoft";
            var company = new ValueHolder.CompanyFactory().CreateEmployeeFromName(testCompanyName);

            Assert.Equal(testCompanyName, company.CompanyName);

            // Lazy initialization of employee objects happen here.
            var employee = company.Employees.FirstOrDefault(x => x.FirstName == "Jeanette");

            Assert.Equal("Jeanette", employee.FirstName);
        }

        [Fact(DisplayName = "Positive Case - Lazy Ghost")]
        public void LazyGhost_Test()
        {
            var testCompanyName = "Microsoft";
            var company = new Ghost.Company("Microsoft");

            Assert.Equal(testCompanyName, company.CompanyName);
            Assert.True(company.IsGhost);

            Assert.Equal("123 Main Street", company.Address);
            Assert.True(company.IsLoaded);

            // Lazy initialization of employee objects happen here.
            var employee = company.Employees.FirstOrDefault(x => x.FirstName == "Jeanette");

            Assert.Equal("Jeanette", employee.FirstName);
        }
    }
}
