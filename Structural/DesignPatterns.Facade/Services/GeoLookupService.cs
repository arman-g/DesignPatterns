using DesignPatterns.Facade.Entities;

namespace DesignPatterns.Facade.Services
{
    public class GeoLookupService
    {
        public Coordinate GetCoordinatesForZipCode(string zipCode)
        {
            // some implementation to call an api and return coordinates.

            var coordinate = new Coordinate
            {
                Latitude = "34.1489719",
                Longitude = "-118.451357"
            };
            return coordinate;
        }

        public string GetCityForZipCode(string zipCode)
        {
            // some implementation to call an api and return city.

            return "Sherman Oaks";
        }

        public string GetStateForZipCode(string zipCode)
        {
            // some implementation to call an api and return state.

            return "CA";
        }
    }
}
