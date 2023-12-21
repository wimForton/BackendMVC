import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface MidiTrack
{
  id: number;
  fileNumber: number;
  title: string;
  year: number;
  filePath: string;
  filesize: number;
  duration: number;
  composer: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public midifiles: MidiTrack[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getForecasts();
    this.getMidiData();
  }
  getMidiData(){
    this.http.get<MidiTrack[]>('https://localhost:7296/api/MidiDataApi/getpage').subscribe(
      (result) => {
        this.midifiles = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'FrontendANG';
}
