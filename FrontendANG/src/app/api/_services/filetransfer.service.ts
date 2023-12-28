import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
//import * as midiManager from 'midi-file';

@Injectable({
  providedIn: 'root'
})
export class FileTransferService {
  private url: string = 'https://localhost:7296/api/DownloadUpload';
  constructor(private http: HttpClient) { }

  public upload(formData: FormData) {
    console.log(this.url + '/upload/' + formData);
    return this.http.post(this.url + '/upload/', formData, {
        reportProgress: true,
        observe: 'events',
    });
  }

  public download() {
    var testUrl: string = "https://localhost:7296/api/DownloadUpload/download?fileUrl=Resources\\images\\screengrab_A.jpg";//test works
    var testUrl2: string = this.url + "/download?fileUrl=Resources\\images\\" + "Stronger.mid";
    console.log("testUrl", testUrl2);
    return this.http.get(testUrl2, {responseType: 'arraybuffer'});
  }
  public downloadArrayBufferUrl(url: string) {
    console.log("downloadbyurl", url);
    return this.http.get(url, {responseType: 'arraybuffer'});
  }
}
