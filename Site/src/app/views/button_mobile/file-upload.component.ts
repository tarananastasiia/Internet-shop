import {Component } from '@angular/core';
import {FileUploadService} from './../../service/file-upload.service';

@Component({
    selector: 'button-mobile',
    templateUrl: './file-upload.component.html',
    styleUrls: ['./file-upload.component.css'],
    providers: [FileUploadService]
})
export class FileUploadComponent{
    fileToUpload: File = null;

constructor(public serviceUploadFile:FileUploadService)
{}
    handleFileInput(files: FileList) {
        this.fileToUpload = files.item(0);
    }
    uploadFile() {
        this.serviceUploadFile.postFile(this.fileToUpload).subscribe(data => {
          // do something, if upload success
          }, error => {
            console.log(error);
          });
      }
}