using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns.LazyLoad.DomainObjects;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class CompanyFactory
    {
        public Company<Employee> CreateEmployeeFromName(string companyName)
        {
            var company = new Company<Employee>(companyName);
            company.SetEmployees(new ValueHolder<List<Employee>>(new EmployeeLoader(companyName)));
            return company;
        }
    }
}
