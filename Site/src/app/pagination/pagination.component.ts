import { Component, OnInit, ViewChild } from '@angular/core';
import { MobilePhonesService } from '../service/mobile-phones.service';
import { PageDTO } from '../../app/model/page-mobile';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MobilePhones } from '../model/mobile-phone';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css'],
  providers: [MobilePhonesService]
})

export class PaginationComponent implements OnInit {
  public displayedColumns = [];
  dataSource;
  phones:MobilePhones[];
  pageIndex: any = 1;
  pageSize: any = 10;
  totalPhonesCount: any;
  minPriceMobile: number=null;
  maxPriceMobile:number=null;
  columnName: string = "category";
  pageEvent: PageEvent;
  ascendingOrDescendingSorting: boolean;
  columnNames = [{
    id: 'category',
    value: 'Category',

  }, {
    id: 'name',
    value: 'Name',
  },
  {
    id: 'price',
    value: 'Price',
  },
  {
    id: 'colour',
    value: 'Colour',
  }];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(public service: MobilePhonesService) {
  }

  ngOnInit() {
    this.displayedColumns = this.columnNames.map(x => x.id);
    this.getColName(this.columnName);
  }
  getColName(colName: string) {
    this.columnName = colName;
    this.getMobiles(this.pageEvent);
  }
  getMobiles(pageEvent: PageEvent) {
    
    if (pageEvent?.pageSize == undefined) {
      this.pageSize = this.pageSize;
      this.pageIndex=this.pageIndex;
    }
    else {
      this.pageSize = pageEvent.pageSize;
      this.pageIndex=pageEvent.pageIndex+1;
    }
    this.ascendingOrDescendingSorting = this.sort.direction === 'asc';
    this.service.getMobile(
      this.minPriceMobile, 
      this.maxPriceMobile,
       this.pageIndex, 
       this.pageSize, 
       this.columnName,
       this.ascendingOrDescendingSorting ?? false )
       .subscribe((data: PageDTO) => {
        this.totalPhonesCount = data.phonesCount;
        this.dataSource = new MatTableDataSource(data.phones);
        this.dataSource.sort = this.sort;
      })
  }
}