using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.SimpleFactory.Abstractions;

namespace DesignPatterns.SimpleFactory.ConcreteAutos
{
    public class NullAutomobile : IAuto
    {
        public string Name => string.Empty;

        public CarStatus Status { get; private set; }

        public virtual void TurnOn()
        {
        }

        public virtual void TurnOff()
        {
        }

        public virtual string GetStatus()
        {
            return string.Empty;
        }
    }
}
