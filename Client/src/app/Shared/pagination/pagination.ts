import { Component, EventEmitter, input, output, ViewEncapsulation } from '@angular/core';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pagination',
  imports: [PaginationModule],
  templateUrl: './pagination.html',
  styleUrl: './pagination.css',
  encapsulation: ViewEncapsulation.None,
})
export class Pagination {
  pagesize = input.required<number>();
  totalcount = input.required<number>();
  pagechange = output<number>();
  OnChangePage(event: any) {
    this.pagechange.emit(event);
  }
}
