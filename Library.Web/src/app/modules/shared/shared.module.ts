import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StylePaginatorDirective } from './directives/StylePaginatorDirective';
import { MatPaginatorModule } from '@angular/material/paginator';



@NgModule({
  declarations: [StylePaginatorDirective],
  imports: [
    CommonModule
  ],
  exports: [StylePaginatorDirective]
})
export class SharedModule { }
