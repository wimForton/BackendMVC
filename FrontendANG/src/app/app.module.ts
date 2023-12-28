import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadComponent } from './api/upload/upload.component';
import { DownloadComponent } from './api/download/download.component';
import { MidiplayComponent } from './bll/audio/midiplay/midiplay/midiplay.component';
import { MidiListComponent } from './gui/midi-list/midi-list.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    DownloadComponent,
    MidiplayComponent,
    MidiListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
