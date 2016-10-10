namespace Devinmotion.Dashboard.Model.Models
{
    public class WeatherInfo
    {
        private readonly string _location;

        private readonly string _temperature;

        private readonly string _description;

        private readonly string _iconKey;

        public WeatherInfo(string location, string temperature, string description, string iconKey)
        {
            _location = location;
            _temperature = temperature;
            _description = description;
            _iconKey = iconKey;
        }
    }
}
