import { Component, OnInit } from '@angular/core';
import { MidiTrack } from 'src/app/api/_models/midiTrack';
import { GetMidiListService } from 'src/app/api/_services/get-midi-list.service';
import { NgIf, NgFor } from '@angular/common';
import { NgbPagination } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-midi-list',
    templateUrl: './midi-list.component.html',
    styleUrl: './midi-list.component.css',
    standalone: true,
    imports: [NgbPagination, NgIf, NgFor]
})
export class MidiListComponent implements OnInit {
  public midifiles: MidiTrack[] = [];
  private rootPath: string = "https://localhost:7296/";
  public currentpage = 1;
  public totalmidifiles = 1270;
  public itemsperpage = 60;

  constructor(private getMidiListService: GetMidiListService) {}

  ngOnInit() {
    //this.getForecasts();
    this.getMidiList();
  }
  getMidiList(){
    this.getMidiListService.getlistpage(this.currentpage,this.itemsperpage)
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
