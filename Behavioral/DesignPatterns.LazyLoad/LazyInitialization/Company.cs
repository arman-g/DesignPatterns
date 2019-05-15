using System.Collections.Generic;
using DesignPatterns.LazyLoad.DomainObjects;

namespace DesignPatterns.LazyLoad.LazyInitialization
{
    public class Company
    {
        private List<Employee> _employees;

        // Lazy initialization example
        public List<Employee> Employees =>
            _employees ?? (_employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Arman",
                    LastName = "Ghazanchyan"
                },
                new Employee
                {
                    FirstName = "Jeanette",
                    LastName = "Chavez"
                },
                new Employee
                {
                    FirstName = "Aria",
                    LastName = "Ghazanchyan"
                }
            });
    }
}
