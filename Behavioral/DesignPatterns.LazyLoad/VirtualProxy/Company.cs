using DesignPatterns.LazyLoad.DomainObjects;
using System.Collections.Generic;
using System.Diagnostics;

namespace DesignPatterns.LazyLoad.VirtualProxy
{
    [DebuggerDisplay("Company = {" + nameof(CompanyName) + "}")]
    public class Company
    {
        public string CompanyName { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public override int GetHashCode()
        {
            return CompanyName.GetHashCode();
        }
    }
}
