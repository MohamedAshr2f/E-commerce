import { Component, inject, input, output } from '@angular/core';
import { Category } from '../Models/CategoryDto';
import { ShopService } from '../Services/Shop.Service';

@Component({
  selector: 'app-categories',
  imports: [],
  templateUrl: './categories.html',
  styleUrl: './categories.css',
})
export class Categories {
  category = input.required<Category>();
  selected = input<boolean>();
  categoryid = output<number>();

  onselectcategory(categoryid: number) {
    this.categoryid.emit(categoryid);
  }
}
