namespace DesignPatterns.Facade.Services
{
    public class EnglishMetricConverter
    {
        public float FahrenheitToCelsius(float fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
