using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.SimpleFactory.Abstractions;

namespace DesignPatterns.SimpleFactory.ConcreteAutos
{
    public class Audi : IAuto
    {
        public string Name => "Audi A5";

        public CarStatus Status { get; private set; }

        public virtual void TurnOn()
        {
            Status = CarStatus.On;
        }

        public virtual void TurnOff()
        {
            Status = CarStatus.Off;
        }

        public virtual string GetStatus()
        {
            return $"{Name} is {Status}{(Status == CarStatus.On ? " and running." : ".")}";
        }
    }
}
