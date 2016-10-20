namespace Devinmotion.Dashboard.Model.Weather.Types
{
    public class WeatherInfo
    {
        public string Location { get; }

        public Temperature Temperature { get; }

        public WeatherCondition WeatherCondition { get; }

        public string Description { get; }

        public WeatherInfo(string location, Temperature temperature, string description, WeatherCondition weatherCondition)
        {
            Location = location;
            Temperature = temperature;
            Description = description;
            WeatherCondition = weatherCondition;
        }
    }
}
