import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MidiTrack } from 'src/app/api/_models/midiTrack';
import { GetmididetailsService } from 'src/app/api/_services/getmididetails.service';

@Component({
  selector: 'app-mididetail',
  templateUrl: './mididetail.component.html',
  styleUrl: './mididetail.component.css'
})
export class MididetailComponent implements OnInit {

  public Id: number = 1;
  public miditrack!: MidiTrack;

  constructor(private route: ActivatedRoute, private getmididetailsService: GetmididetailsService) {}
  ngOnInit(): void {
    this.setProporties();
    //this.getdetails();
  }
  setProporties(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.Id = id;
    console.log("this.Id", this.Id);
  }
  getdetails(){
    this.getmididetailsService.getmididetails(this.Id)
    .subscribe(
      (response: MidiTrack) =>{
          if (response) {
            this.miditrack = response;
          }
      }
  )
  }
}
