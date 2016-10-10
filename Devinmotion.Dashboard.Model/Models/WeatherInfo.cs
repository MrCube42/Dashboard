namespace Devinmotion.Dashboard.Model.Models
{
    public class WeatherInfo
    {
        public string Location { get; }

        public string Temperature { get; }

        public string IconKey { get; }

        public string Description { get; }

        public WeatherInfo(string location, string temperature, string description, string iconKey)
        {
            Location = location;
            Temperature = temperature;
            Description = description;
            IconKey = iconKey;
        }
    }
}
