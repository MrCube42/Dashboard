using System;

using RestSharp;

using Devinmotion.Dashboard.Model.Weather.Services;
using Devinmotion.Dashboard.Model.Weather.Types;
using System.Linq;

namespace Devinmotion.Dashboard.Model.Weather.Serialization
{
    public class OpenWeatherMapWeatherInfoSerializerStrategy : IJsonSerializerStrategy
    {
        private const string LocationKey = "name";

        private const string WeatherArrayKey = "weather";

        private const string DescriptionKey = "description";

        private const string WeatherConditionKey = "icon";

        private const string MainJsonKey = "main";

        private const string TemperatureKey = "temp";

        private IWeatherConditionService WeatherConditionService { get; }

        public OpenWeatherMapWeatherInfoSerializerStrategy(IWeatherConditionService weatherConditionService)
        {
            WeatherConditionService = weatherConditionService;
        }

        public object DeserializeObject(object value, Type type)
        {
            JsonObject json = value as JsonObject;

            JsonArray weatherArray = GetJsonArrayFromJson(json, WeatherArrayKey);
            JsonObject weatherJson = GetFirstJsonObjectFromJsonArray(weatherArray);
            JsonObject mainJson = GetJsonObjectFromJson(json, MainJsonKey);

            string location = GetValueFromJson<string>(json, LocationKey);
            double temperatureValue = GetValueFromJson<double>(mainJson, TemperatureKey);
            string description = GetValueFromJson<string>(weatherJson, LocationKey);
            string weatherConditionId = GetValueFromJson<string>(weatherJson, WeatherConditionKey);

            Temperature temperature = new Temperature(temperatureValue, TemperatureUnit.Celius);
            WeatherCondition weatherCondition = WeatherConditionService.ConvertKeyToWeatherCondition(weatherConditionId);
            WeatherInfo weatherInfo = new WeatherInfo(location, temperature, description, weatherCondition);

            return weatherInfo;
        }

        private static JsonArray GetJsonArrayFromJson(JsonObject json, string key)
        {
            object obj = null;
            json.TryGetValue(key, out obj);
            JsonArray value = obj as JsonArray;
            return value;
        }

        private static JsonObject GetFirstJsonObjectFromJsonArray(JsonArray jsonArray)
        {
            return jsonArray.FirstOrDefault() as JsonObject;
        }

        private static JsonObject GetJsonObjectFromJson(JsonObject json, string key)
        {
            object obj = null;
            json.TryGetValue(key, out obj);
            JsonObject value = obj as JsonObject;
            return value;
        }

        private static T GetValueFromJson<T>(JsonObject json, string key)
        {
            object obj = null;
            json.TryGetValue(key, out obj);
            T value = (T)obj;
            return value;
        }

        /// <summary>
        /// Is not supported and used at the moment.
        /// </summary>
        public bool TrySerializeNonPrimitiveObject(object input, out object output)
        {
            throw new NotSupportedException();
        }
    }
}
