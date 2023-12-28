import { Component, OnInit } from '@angular/core';
import { MidiTrack } from 'src/app/api/_models/midiTrack';
import { GetMidiListService } from 'src/app/api/_services/get-midi-list.service';

@Component({
  selector: 'app-midi-list',
  templateUrl: './midi-list.component.html',
  styleUrl: './midi-list.component.css'
})
export class MidiListComponent implements OnInit {
  public midifiles: MidiTrack[] = [];
  private rootPath: string = "https://localhost:7296/";

  constructor(private getMidiListService: GetMidiListService) {}

  ngOnInit() {
    //this.getForecasts();
    this.getMidiList();
  }
  getMidiList(){
    this.getMidiListService.getlistpage(26,50)
    .subscribe(
      (response: MidiTrack[]) =>{
          if (response) {
            this.midifiles = response;
          }
      }
  )
  }

  play(MidiTrack: MidiTrack){
    console.log(this.rootPath + "MidiData/maestro/" + MidiTrack.filePath);
  }

  title = 'FrontendANG';
}
