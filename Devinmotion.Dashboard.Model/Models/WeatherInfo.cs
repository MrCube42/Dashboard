namespace Devinmotion.Dashboard.Model.Models
{
    public class WeatherInfo
    {
        public string Location { get; }

        public string Temperature { get; }

        public WeatherCondition WeatherCondition { get; }

        public string Description { get; }

        public WeatherInfo(string location, string temperature, string description, WeatherCondition weatherCondition)
        {
            Location = location;
            Temperature = temperature;
            Description = description;
            WeatherCondition = weatherCondition;
        }
    }
}
