import { Component, OnInit } from '@angular/core';
import { FileTransferService } from '../_services/filetransfer.service';
///import {MidiParser} from 'midi-parser-js';
//const midiParser = require('midi-parser-js');
//const midiParser  = require('midi-parser-js');
//const fs = require('fs');
//import * as midiManager from 'midi-file';
//import {MidiParser} from 'midi-parser-js';
//import * as fs from 'fs';
//import * as promises from 'node:fs/promises';
import { Midi } from '@tonejs/midi';
//import { Tone } from 'tone/build/esm/core/Tone';
import * as Tone from "Tone";
import {inputById, MIDI_INPUT, MIDI_OUTPUT, outputByName, MIDI_SUPPORT} from '@ng-web-apis/midi';


@Component({
    selector: 'app-download',
    templateUrl: './download.component.html',
    styleUrls: ['./download.component.css'],
})
export class DownloadComponent implements OnInit {
  message: string = "";
  progress: number = 0;
  binaryData: any = [];
  myBlob!: Blob;
  myMidi!: Midi;
  
  
  constructor(private transferService: FileTransferService) {}
  
    ngOnInit(): void {
    }
    download = () => {
        let filename: string = "filename";
        this.transferService.download()
        .subscribe(
            (response: ArrayBuffer) =>{
                if (response) {
                console.log("arrayBuffer", response);
                const midi = new Midi(response);
                this.myMidi = new Midi(response);
                midi.tracks.forEach(track => {
                    const notes = track.notes
                    notes.forEach(note => {
                        console.log(note.name);
                      //note.midi, note.time, note.duration, note.name
                    })
                  })
                // byteArray.forEach((element, index) => {
                //     // do something with each byte in the array
                // });
                }
            }
        )
    }
    testmidi(){
        const synths = [];
        const now = Tone.now() + 0.5;
        this.myMidi.tracks.forEach((track) => {
            //create a synth for each track
            const synth = new Tone.PolySynth(Tone.Synth, {
                envelope: {
                    attack: 0.02,
                    decay: 0.1,
                    sustain: 0.3,
                    release: 0.1,
                },
            }).toDestination();
            synths.push(synth);
            //schedule all of the events
            track.notes.forEach((note) => {
                synth.triggerAttackRelease(
                    note.name,
                    note.duration,
                    note.time + now,
                    note.velocity
                );
            });
        });
    }

    
}
