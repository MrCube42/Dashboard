import { WeatherCondition } from './weather-condition';

export class WeatherInfo {
    constructor(
        public location: string,
        public temperature: string,
        public description: string,
        public weatherCondition: WeatherCondition) { }
}
