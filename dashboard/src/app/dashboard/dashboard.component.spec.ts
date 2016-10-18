/* tslint:disable:no-unused-variable */

import { TestBed, async } from '@angular/core/testing';
import { DashboardComponent } from './dashboard.component';
import { WeatherComponent } from '../weather/weather.component';
import { WeatherService } from '../services/weather.service';

describe('Component: Dashboard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [
        DashboardComponent,
        WeatherComponent
      ],
      providers: [ { provide: WeatherService, useValue: {
        fetchWeatherInfo() { return []; }
      } }]
    });
  });

  it('should create an instance', () => {
    let component = TestBed.createComponent(DashboardComponent);
    expect(component).toBeTruthy();
  });
});
