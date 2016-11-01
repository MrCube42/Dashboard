using Devinmotion.Dashboard.Model.Weather.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Devinmotion.Dashboard.View.Converters
{
    public class WeatherConditionToWeatherIconFontKeyConverter : IValueConverter
    {
        private readonly Dictionary<WeatherType, string> IconFontKeyByWeatherTypeDay =
            new Dictionary<WeatherType, string>()
            {
                { WeatherType.ClearSky, "\uf00d" },
                { WeatherType.FewClouds, "\uf002" },
                // same in day and night
                { WeatherType.ScatteredClouds, "\uf041" },
                // same in day and night
                { WeatherType.BrokenClouds, "\uf013" },
                { WeatherType.Mist, "\uf003" },
                { WeatherType.Rain, "\uf008" },
                { WeatherType.ShowerRain, "\uf009" },
                { WeatherType.Snow, "\uf00a" },
                { WeatherType.Thunderstorm, "\uf010" }
            };

        private readonly Dictionary<WeatherType, string> IconFontKeyByWeatherTypeNight =
            new Dictionary<WeatherType, string>()
            {
                { WeatherType.ClearSky, "\uf02e" },
                { WeatherType.FewClouds, "\uf086" },
                // same in day and night
                { WeatherType.ScatteredClouds, "\uf041" },
                // same in day and night
                { WeatherType.BrokenClouds, "\uf013" },
                { WeatherType.Mist, "\uf04a" },
                { WeatherType.Rain, "\uf036" },
                { WeatherType.ShowerRain, "\uf037" },
                { WeatherType.Snow, "\uf038" },
                { WeatherType.Thunderstorm, "\uf06c" }
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            WeatherCondition condition = value as WeatherCondition;
            if (condition == null)
            {
                throw new ArgumentException($"The value must be of type '{typeof(WeatherCondition)}'.");
            }

            string iconFontKey;
            if (condition.DayTime == DayTime.Day)
            {
                iconFontKey = IconFontKeyByWeatherTypeDay[condition.Type];
            }
            else
            {
                iconFontKey = IconFontKeyByWeatherTypeNight[condition.Type];
            }
            
            return iconFontKey;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
