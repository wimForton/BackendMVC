import { Component, OnInit } from '@angular/core';
import { FiletransferService } from './../_services/filetransfer.service';

@Component({
    selector: 'app-download',
    templateUrl: './download.component.html',
    styleUrls: ['./download.component.css'],
})
export class DownloadComponent implements OnInit {
  message: string = "";
  progress: number = 0;
  
  constructor(private filetransferService: FiletransferService) {}
  
    ngOnInit(): void {}
    download = () => {
        this.filetransferService.download()
        .subscribe((response) => {
            this.message = "todo";//response['message'];
        });
    }
}
