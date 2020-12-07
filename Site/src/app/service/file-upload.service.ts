import {Injectable} from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map,catchError } from 'rxjs/operators';
    
@Injectable()
export class FileUploadService{

    private url = "https://localhost:44395/api/mobilePhone/uploadFile";
    constructor(private httpClient: HttpClient){ }

    postFile(fileToUpload: File): Observable<boolean> {
        const endpoint = this.url;
        const formData: FormData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);
        return this.httpClient
          .post(endpoint, formData).pipe(
          map(() => { return true; })
          );
    } 



    // options = {
    //     headers: new HttpHeaders({
    //         'Content-Type': 'application/json'
    //     })
    // };

    // postFile(fileToUpload: File): Observable<boolean> {
    //     const endpoint = this.url;
    //     const formData: FormData = new FormData();
    //     formData.append('fileKey', fileToUpload, fileToUpload.name);
    //     return this.httpClient
    //       .post(endpoint, formData)
    //       .pipe(map(() => { return true; })
    //       );
    // }
}