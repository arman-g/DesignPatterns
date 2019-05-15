using DesignPatterns.LazyLoad.DomainObjects;
using System;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.LazyInitialization
{
    public class CompanyDotNetLazy
    {
        private readonly Lazy<List<Employee>> _employeesInitializer;

        public CompanyDotNetLazy()
        {
            _employeesInitializer = new Lazy<List<Employee>>(() =>
                    new List<Employee>
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
                    },
                true // <= thread safe
                );
        }

        public List<Employee> Employees => _employeesInitializer.Value;
        public bool IsEmployeesInitialized => _employeesInitializer.IsValueCreated;
    }
}
