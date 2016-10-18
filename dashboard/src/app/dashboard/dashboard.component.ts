import { Component, OnInit } from '@angular/core';

import { WeatherService } from '../services/weather.service';
import { WeatherInfo } from '../shared/weather-info';

@Component({
  selector: 'devinmotion-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public weatherInfo: WeatherInfo;

  constructor(private weatherService: WeatherService) {
    this.weatherInfo = weatherService.fetchWeatherInfo();
  }

  ngOnInit() {
  }

}
