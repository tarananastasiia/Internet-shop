import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PageDTO } from '../../app/model/page-mobile';

@Injectable()
export class PlumbingService {
  constructor(private http: HttpClient) { }

  getPlumbing(minPrice: number, maxPrice: number, pageNumber: number, pageSize: number,
    columnName: string, ascendingOrDescendingSorting: boolean) {

    let params = new HttpParams()
      .append("pageNumber", `${pageNumber}`)
      .append("pageSize", `${pageSize}`)
      .append("sortingColumnName", `${columnName}`)
      .append("ascendingOrDescending", `${ascendingOrDescendingSorting}`);

    if (minPrice)
      params = params.append("minPrice", `${minPrice}`)

    if (maxPrice)
      params = params.append("maxPrice", `${maxPrice}`)

    return this.http.get<PageDTO>('https://localhost:44395/api/plumbing',
      {
        params: params
      });


  }
}