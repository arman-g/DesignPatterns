using System.Diagnostics;

namespace DesignPatterns.LazyLoad.DomainObjects
{
    [DebuggerDisplay("{" + nameof(FullName) + "}")]
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public Employee()
        {
            Debug.WriteLine($"Employee Initialized");
        }
    }
}
