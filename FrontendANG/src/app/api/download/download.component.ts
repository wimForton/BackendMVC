import { Component, OnInit } from '@angular/core';
import { FileTransferService } from '../_services/filetransfer.service';

@Component({
    selector: 'app-download',
    templateUrl: './download.component.html',
    styleUrls: ['./download.component.css'],
})
export class DownloadComponent implements OnInit {
  message: string = "";
  progress: number = 0;
  
  constructor(private transferService: FileTransferService) {}
  
    ngOnInit(): void {}
    download = () => {
        this.transferService.download()
        .subscribe((response) => {
            this.message = "todo";//response['message'];
        });
    }
}
