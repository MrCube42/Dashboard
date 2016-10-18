import { WeatherType } from './weather-type';
import { Daytime } from './daytime';

export class WeatherCondition {

    constructor(
        public type: WeatherType,
        public dayTime: Daytime = Daytime.Day) { }
}
