using DesignPatterns.Flyweight.Abstractions;
using System;

namespace DesignPatterns.Flyweight.DomainObjects
{
    public class Bmw : IAuto
    {
        private const double AnnualDepreciationRate = 0.017;
        private const double PerMileDepreciationRate = 0.00001;

        public decimal CalculatePrice(int year, double miles, decimal manufacturePrice)
        {
            var yearsOld = DateTime.Now.Year - year;
            var totalAnnualDepreciationAmount = (manufacturePrice * (decimal)AnnualDepreciationRate) * yearsOld;
            var totalMileDepreciationAmount = manufacturePrice * (decimal)miles * (decimal)PerMileDepreciationRate;

            return manufacturePrice - totalAnnualDepreciationAmount - totalMileDepreciationAmount;
        }
    }
}
