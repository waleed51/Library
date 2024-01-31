import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, startWith, switchMap } from 'rxjs/operators';
import { SearchService } from '../../services/search.service';
import { book } from '../../models/book';
import { FormControl } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { PaginationOptions } from '../../constants/PaginationOptions';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { PagedResult } from '../../models/pagedResult';


@Component({
  selector: 'app-search-books',
  templateUrl: './search-books.component.html',
  styleUrls: ['./search-books.component.css']
})
export class SearchBooksComponent {
  pageIndex: number = 0;
  pageSize: number = PaginationOptions.PageSize;
  searchControl = new FormControl();
  books: book[] = [];
  NoData: Boolean = false;
  searchText: string = '';
  data: PagedResult<book> = {
    pageIndex : 0,
    result : [],
    totalItems : 0
  };

  constructor(private service: SearchService, private changeDetection: ChangeDetectorRef, private sanitizer: DomSanitizer) { 
    this.searchControl.valueChanges.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    ).subscribe(searchText => {
      this.searchText = searchText;
      this.searchBooks(searchText);
    });
   }

  private searchBooks(searchText: string): void {
    if (searchText) {
      this.service.searchBooks(searchText, this.pageIndex, this.pageSize).subscribe((res) => {
        if (res && res.result) {
          this.books = res.result as book[];
          this.data = res;
          this.NoData = false;
        }
        else {
          this.books = [];
          this.NoData = true;
        }
        this.changeDetection.detectChanges();
      });
    }
    else {
      this.books = [];
      this.NoData = true;
    }
  }

  pageChanged(pageChangedEvent: PageEvent) {
    this.pageSize = pageChangedEvent.pageSize;
    this.pageIndex = pageChangedEvent.pageIndex;
    this.searchBooks(this.searchText);
  }
  getSafeImageUrl(unsafeImageUrl: string): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(unsafeImageUrl);
  }

}
