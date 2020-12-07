import {Component, OnInit } from '@angular/core';
import { MobilePhones} from '../../model/mobile-phone';
import {MobilePhonesService} from '../../service/mobile-phones.service';

@Component({
    selector: 'all-mobile',
    templateUrl: './mobile-phone.component.html',
    styleUrls: ['./mobile-phone.component.css'],
    providers: [MobilePhonesService]
})
export class MobilePhonesComponent implements OnInit{
    phones: Array<MobilePhones>;

    constructor(private serv: MobilePhonesService) {
        this.phones = new Array<MobilePhones>();
    }
       
    ngOnInit() {

            this.serv.getMobile().subscribe((data: MobilePhones[]) => {
                    this.phones = data; 
                });
    }

}