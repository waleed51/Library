import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBooksComponent } from './components/search-books/search-books.component';
import { RouterModule, Routes } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../shared/shared.module';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { StylePaginatorDirective } from '../shared/directives/StylePaginatorDirective';

export const routes: Routes = [
  {
    path: '',
    component: SearchBooksComponent
  }
];

@NgModule({
  declarations: [SearchBooksComponent
  ],
  imports: [
    MatInputModule,
    MatListModule,
    MatCardModule,
    NoopAnimationsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    RouterModule.forChild(routes),
  ],
  exports: [RouterModule],
})
export class BookModule { }
