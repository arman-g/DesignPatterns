using System.ComponentModel.DataAnnotations;
using DesignPatterns.Composite.Abstractions;

namespace DesignPatterns.Composite.Entities
{
    public class Agent : IParty
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal PayOutAmount { get; set; }

        public string Stats(int indent = 0)
        {
            return $"{new string(' ', indent)}{Name} should be paid {PayOutAmount:C2} with the rate of {Rate:P1}.";
        }

        public void Validate()
        {
            if (Rate > 1)
            {
                throw new ValidationException($"{Name} => The value of rate cannot exceed 1.0 (100%).");
            }
        }
    }
}
