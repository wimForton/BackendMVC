import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MidiListComponent } from './gui/midi-list/midi-list.component';

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
    styleUrl: './app.component.css',
    standalone: true,
    imports: [MidiListComponent]
})
export class AppComponent implements OnInit {

  public midifiles: MidiTrack[] = [];
  private rootPath: string = "https://localhost:7296/";
  public testMidiPath: string = "https://localhost:7296/MidiData/2018/MIDI-Unprocessed_Chamber3_MID--AUDIO_10_R3_2018_wav--1.midi";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getForecasts();
    this.getMidiData();
  }
  getMidiData(){
    this.http.get<MidiTrack[]>(this.rootPath + 'api/MidiDataApi/getpage').subscribe(
      (result) => {
        this.midifiles = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getMidiFile(){
    
  }

  play(MidiTrack: MidiTrack){
    console.log(this.rootPath + "MidiData/maestro/" + MidiTrack.filePath);
  }

  title = 'FrontendANG';
}
