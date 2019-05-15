using DesignPatterns.LazyLoad.DomainObjects;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.VirtualProxy
{
    public class CompanyProxy : Company
    {
        public override List<Employee> Employees
        {
            get => base.Employees ?? (base.Employees = new List<Employee>
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
            set => base.Employees = value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Company other)) return false;
            return other.CompanyName == CompanyName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
