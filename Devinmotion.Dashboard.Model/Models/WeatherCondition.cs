namespace Devinmotion.Dashboard.Model.Models
{
    public class WeatherCondition
    {
        public WeatherType Type { get; }

        public DayTime DayTime { get; }

        public WeatherCondition(WeatherType type)
            : this(type, DayTime.Day) { }

        public WeatherCondition(WeatherType type, DayTime dayTime)
        {
            Type = type;
            DayTime = dayTime;
        }
    }
}
