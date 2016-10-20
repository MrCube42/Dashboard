using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;

using Devinmotion.Dashboard.Model.Weather.Types;

namespace Devinmotion.Dashboard.Model.Weather.Services
{
    public class OpenWeatherMapWeatherConditionService : IWeatherConditionService
    {
        private static readonly Regex WeatherKeyGroupingRegex = new Regex(@"(\d+)(d|n)");

        private readonly Dictionary<string, WeatherType>
            WeatherTypeByKey = new Dictionary<string, WeatherType>()
            {
                { "01", WeatherType.ClearSky },
                { "02", WeatherType.FewClouds },
                { "03", WeatherType.ScatteredClouds },
                { "04", WeatherType.BrokenClouds },
                { "09", WeatherType.ShowerRain },
                { "10", WeatherType.Rain },
                { "11", WeatherType.Thunderstorm},
                { "13", WeatherType.Snow},
                { "50", WeatherType.Mist}
            };

        private readonly Dictionary<string, DayTime>
            DayTimeByKey = new Dictionary<string, DayTime>()
            {
                { "d", DayTime.Day },
                { "n", DayTime.Night },
            };

        public WeatherCondition ConvertKeyToWeatherCondition(string key)
        {
            Match match = WeatherKeyGroupingRegex.Match(key);
            if (match == null)
            {
                string message = string.Format(
                    CultureInfo.InvariantCulture,
                    "The key '{0}' seems to be an invalid weather condition key.",
                    key);

                throw new ArgumentException(message, nameof(key));
            }

            string weatherTypeKey = match.Groups[1].Value;
            string dayTimeKey = match.Groups[2].Value;

            WeatherType type = WeatherTypeByKey[weatherTypeKey];
            DayTime dayTime = DayTimeByKey[dayTimeKey];

            WeatherCondition condition = new WeatherCondition(type, dayTime);
            return condition;
        }
    }
}
