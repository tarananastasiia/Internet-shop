import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
    
@Injectable()
export class MobilePhonesService{
      constructor(private http: HttpClient){ }
    private url = "https://localhost:44395/api/mobilePhone";
    
  
       
    getMobile(){
        return this.http.get(this.url);
    }
}