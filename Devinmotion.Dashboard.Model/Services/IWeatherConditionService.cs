using Devinmotion.Dashboard.Model.Models;

namespace Devinmotion.Dashboard.Model.Services
{
    public interface IWeatherConditionService
    {
        WeatherCondition ConvertKeyToWeatherCondition(string key);
    }
}
