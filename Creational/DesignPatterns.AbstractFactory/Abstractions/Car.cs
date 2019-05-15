namespace DesignPatterns.AbstractFactory.Abstractions
{
    public abstract class Car
    {
        public string Description { get; }
        public string Engine { get; }
        public decimal Miles { get; set; }
        public int Doors { get; }
        public string Type { get; }
        public decimal Price { get; set; }
        public decimal DownPayment { get; set; }
        public bool InStack { get; set; }

        protected Car(string description, string engine, int doors, string type)
        {
            Description = description;
            Engine = engine;
            Doors = doors;
            Type = type;
        }

        public void AddMiles(decimal milesToAdd)
        {
            if (milesToAdd < 1) return;
            Miles += milesToAdd;
        }
    }
}
