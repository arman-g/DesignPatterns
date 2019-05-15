using DesignPatterns.LazyLoad.DomainObjects;
using DesignPatterns.LazyLoad.ValueHolder.Abstractions;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class EmployeeLoader : IValueLoader<List<Employee>>
    {
        // based on this flag you can load objects.
        private readonly string _companyName;

        public EmployeeLoader(string companyName)
        {
            _companyName = companyName;
        }

        public List<Employee> Load()
        {
            switch (_companyName)
            {
                case "Microsoft":
                    return new List<Employee>
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
                    };
                default:
                    return new List<Employee>();
            }
        }
    }
}
