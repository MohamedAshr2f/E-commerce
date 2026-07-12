import { Component, input } from '@angular/core';
import { Category } from '../Models/CategoryDto';

@Component({
  selector: 'app-categories',
  imports: [],
  templateUrl: './categories.html',
  styleUrl: './categories.css',
})
export class Categories {
  category = input.required<Category>();
}
