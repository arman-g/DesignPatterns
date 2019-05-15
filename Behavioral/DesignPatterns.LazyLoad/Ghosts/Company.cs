using DesignPatterns.LazyLoad.DomainObjects;
using DesignPatterns.LazyLoad.Ghosts.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.Ghosts
{
    public class Company : GhostObject
    {
        private Lazy<List<Employee>> _employees;
        private string _address;

        public List<Employee> Employees
        {
            get
            {
                Load();
                return _employees.Value;
            }
        }

        public int CompanySize
        {
            get
            {
                Load();
                return _employees.Value.Count;
            }
        }

        public string Address
        {
            get
            {
                Load();
                return _address;
            }
            set
            {
                Load();
                _address = value;
            }
        }

        public Company(string companyName) : base(companyName)
        {
        }

        protected override void DoLoadLine(ArrayList dataRow)
        {
            Address = (string) dataRow[0];
            _employees = new Lazy<List<Employee>>(() => new List<Employee>
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

        protected override ArrayList GetDataRow()
        {
            var row = new ArrayList
            {
                "123 Main Street"
            };
            return row;
        }
    }
}
