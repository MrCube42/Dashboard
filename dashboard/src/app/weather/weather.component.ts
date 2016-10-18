import { Component, OnInit, Input } from '@angular/core';

import { WeatherInfo } from '../shared/weather-info';

@Component({
  selector: 'devinmotion-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  @Input() weatherInfo: WeatherInfo;

  constructor() { }

  ngOnInit() {
  }

}
