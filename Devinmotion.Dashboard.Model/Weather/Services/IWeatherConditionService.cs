using Devinmotion.Dashboard.Model.Weather.Types;

namespace Devinmotion.Dashboard.Model.Weather.Services
{
    public interface IWeatherConditionService
    {
        WeatherCondition ConvertKeyToWeatherCondition(string key);
    }
}
