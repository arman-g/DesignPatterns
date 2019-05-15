using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.SimpleFactory.Abstractions;

namespace DesignPatterns.SimpleFactory.ConcreteAutos
{
    public class Bmw : IAuto
    {
        public string Name => "BMW i3";

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
