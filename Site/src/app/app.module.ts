import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppComponent }   from './app.component';
import { HttpClientModule } from '@angular/common/http';
import {FileUploadComponent} from './views/button_mobile/file-upload.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { PaginationComponent } from './pagination/pagination.component';
import { MatTableModule } from '@angular/material/table'  
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    imports: [ HttpClientModule,BrowserModule,FormsModule,NgxPaginationModule,MatTableModule,MatSortModule,MatPaginatorModule
    ,BrowserAnimationsModule],
    declarations: [ AppComponent, FileUploadComponent,PaginationComponent],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }