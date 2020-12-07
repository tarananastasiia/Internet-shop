import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppComponent }   from './app.component';
import { HttpClientModule } from '@angular/common/http';
import {FileUploadComponent} from './views/button_mobile/file-upload.component';
import {MobilePhonesComponent} from './views/mobile-phone/mobile-phone.component'


@NgModule({
    imports:      [ HttpClientModule,BrowserModule,FormsModule],
    declarations: [ AppComponent, FileUploadComponent,MobilePhonesComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }