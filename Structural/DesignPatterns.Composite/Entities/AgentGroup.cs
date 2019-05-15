using DesignPatterns.Composite.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DesignPatterns.Composite.Entities
{
    public class AgentGroup : IParty
    {
        public string Name { get; set; }

        public decimal Rate { get; set; }

        public decimal PayOutAmount
        {
            get { return Members.Sum(x => x.PayOutAmount); }
            set
            {
                foreach (var member in Members)
                {
                    member.PayOutAmount = value * member.Rate;
                }
            }
        }

        public IList<IParty> Members { get; set; }

        public AgentGroup()
        {
            Members = new List<IParty>();
        }

        public string Stats(int indent = 0)
        {
            var showName = !string.IsNullOrEmpty(Name);
            var stats = new StringBuilder();
            if (showName)
            {
                stats.Append(new string(' ', indent) + Name + $" ({Rate:p1})");
                indent += 8;
            }
            foreach (var member in Members)
            {
                stats.Append((stats.Length > 0 ? Environment.NewLine : "") + member.Stats(indent));
            }
            return stats.ToString();
        }

        public void Validate()
        {
            var totalRate = 0m;
            foreach (var member in Members)
            {
                member.Validate();
                totalRate += member.Rate;
            }

            if (totalRate > 1)
            {
                throw new ValidationException($"{Name} => the sum of parties' rates cannot exceed 1.0 (100%).");
            }
        }
    }
}
