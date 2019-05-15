using DesignPatterns.Facade.Entities;
using DesignPatterns.Facade.Services;

namespace DesignPatterns.Facade.Facades
{
    public class TemperatureLookupFacade
    {
        private readonly WeatherService _weatherService;
        private readonly GeoLookupService _geoLookupService;
        private readonly EnglishMetricConverter _converter;

        public TemperatureLookupFacade() : 
            this(
                new WeatherService(), 
                new GeoLookupService(), 
                new EnglishMetricConverter()) { }

        public TemperatureLookupFacade(
            WeatherService weatherService, 
            GeoLookupService geoLookupService, 
            EnglishMetricConverter converter)
        {
            _weatherService = weatherService;
            _geoLookupService = geoLookupService;
            _converter = converter;
        }

        public LocalTemperature GetTemperature(string zipCode)
        {
            var coords = _geoLookupService.GetCoordinatesForZipCode(zipCode);
            var city = _geoLookupService.GetCityForZipCode(zipCode);
            var state = _geoLookupService.GetStateForZipCode(zipCode);

            var fahrenheit = _weatherService.GetTempFahrenheit(coords.Latitude, coords.Longitude);
            var celsius = _converter.FahrenheitToCelsius(fahrenheit);

            return new LocalTemperature
            {
                Fahrenheit = fahrenheit,
                Celsius = celsius,
                City = city,
                State = state
            };
        }
    }
}
