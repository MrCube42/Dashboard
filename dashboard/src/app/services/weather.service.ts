import { Injectable } from '@angular/core';

import { WeatherInfo } from '../shared/weather-info';
import { WeatherCondition } from '../shared/weather-condition';
import { WeatherType } from '../shared/weather-type';

@Injectable()
export class WeatherService {

  public CurrentWeatherInfo;

  constructor() {

    this.CurrentWeatherInfo =
      new WeatherInfo(
        'Köln',
        '21°C',
        'bewölkt',
        new WeatherCondition(WeatherType.ShowerRain)
      );
  }

}
