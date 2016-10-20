using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using RestSharp;

using Devinmotion.Dashboard.Model.Weather.Types;

namespace Devinmotion.Dashboard.Model.Weather.Services
{
    public class OpenWeatherMapWeatherInfoRepository : IWeatherInfoRepository
    {
        private const string OpenWeatherMapBaseUrl = @"http://api.openweathermap.org/data/2.5/weather";

        private const string LocationIdParameter = "zip";

        private const string ApiKeyParameter = "appid";

        private const string UnitsParameter = "units";

        // TODO: devinmotion: These should be provided from outside
        private const string ApiKey = "6dda99f291205bea7c0693d18c314014";
        private const string LocationId = "66763,de";
        private const string Units = "metric";

        private readonly RestClient restClient;

        private IJsonSerializerStrategy SerializerStrategy { get; }

        public OpenWeatherMapWeatherInfoRepository(IJsonSerializerStrategy serializerStrategy)
        {
            SerializerStrategy = serializerStrategy;

            restClient = new RestClient();
            restClient.BaseUrl = new Uri(OpenWeatherMapBaseUrl);
            restClient.AddDefaultParameter(LocationIdParameter, LocationId);
            restClient.AddDefaultParameter(ApiKeyParameter, ApiKey);
            restClient.AddDefaultParameter(UnitsParameter, Units);
        }

        private async Task<IRestResponse> LoadWeatherInfosAsync()
        {
            RestRequest request = new RestRequest();
            Task<IRestResponse> response = restClient.ExecuteTaskAsync(request);
            return await response;
        }

        public ReadOnlyObservableCollection<WeatherInfo> LoadWeatherInfos()
        {
            ObservableCollection<WeatherInfo> observableWeatherInfos =
                new ObservableCollection<WeatherInfo>();

            LoadWeatherInfosAsync().ContinueWith(task =>
            {
                string content = task.Result.Content;
                if (content != null)
                {
                    WeatherInfo weatherInfo = SimpleJson.DeserializeObject<WeatherInfo>(content, SerializerStrategy);
                    observableWeatherInfos.Add(weatherInfo);
                }
            });

            ReadOnlyObservableCollection<WeatherInfo> readonlyWeatherInfos =
                new ReadOnlyObservableCollection<WeatherInfo>(observableWeatherInfos);
            return readonlyWeatherInfos;
        }
    }
}
