namespace DesignPatterns.Flyweight.Abstractions
{
    public interface IAuto
    {
        decimal CalculatePrice(int year, double miles, decimal manufacturePrice);
    }
}
