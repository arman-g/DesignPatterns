using DesignPatterns.CommonObjects.Enums;

namespace DesignPatterns.SimpleFactory.Abstractions
{
    public interface IAuto
    {
        string Name { get; }
        CarStatus Status { get; }

        void TurnOn();
        void TurnOff();

        string GetStatus();
    }
}
