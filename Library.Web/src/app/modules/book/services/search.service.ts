import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiCallerService } from '../../shared/services/api-caller-service.service';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  constructor(private service: ApiCallerService) {}

  searchBooks(searchText : string, pageIndex:number, pageSize: number): Observable<any> {
    return this.service.Search(pageIndex, pageSize, searchText,"/Book/SearchBooks");
    }
}

