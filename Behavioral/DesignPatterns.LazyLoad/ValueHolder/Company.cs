using DesignPatterns.LazyLoad.DomainObjects;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class Company<T>
    {
        public string CompanyName { get; set; }

        public Company(string companyName)
        {
            CompanyName = companyName;
        }

        private ValueHolder<List<T>> _employees;

        public List<T> Employees => _employees.Value;

        internal void SetEmployees(ValueHolder<List<T>> valueHolder)
        {
            _employees = valueHolder;
        }
    }
}
