import { Component, EventEmitter, input, output } from '@angular/core';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pagination',
  imports: [PaginationModule],
  templateUrl: './pagination.html',
  styleUrl: './pagination.css',
})
export class Pagination {
  pagesize = input.required<number>();
  totalcount = input.required<number>();
  pagechange = output<number>();
  OnChangePage(event: any) {
    this.pagechange.emit(event);
  }
}
