using DesignPatterns.FactoryMethod.Products;

namespace DesignPatterns.FactoryMethod.Abstractions
{
    public abstract class CarBase : ICar
    {
        public string Description { get; }
        public string Engine { get; }
        public decimal Miles { get; set; }
        public int Doors { get; }
        public string Type { get; }
        public decimal Price { get; }

        protected CarBase(string engine, int doors, string description, string type, decimal price, decimal miles = 0)
        {
            Engine = engine;
            Doors = doors;
            Description = description;
            Type = type;
            Price = price;
            Miles = miles;
        }

        public void AddMiles(decimal milesToAdd)
        {
            if (milesToAdd < 1) return;
            Miles += milesToAdd;
        }

        #region ' Null '

        private static readonly NullCar NullCar = new NullCar();

        public static NullCar Null => NullCar;

        #endregion
    }
}
