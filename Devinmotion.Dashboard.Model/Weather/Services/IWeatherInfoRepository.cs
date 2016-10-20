using System.Collections.ObjectModel;

using Devinmotion.Dashboard.Model.Weather.Types;

namespace Devinmotion.Dashboard.Model.Weather.Services
{
    public interface IWeatherInfoRepository
    {
        ReadOnlyObservableCollection<WeatherInfo> LoadWeatherInfos();
    }
}
