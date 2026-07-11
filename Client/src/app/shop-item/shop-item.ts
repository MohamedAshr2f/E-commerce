import { CurrencyPipe } from '@angular/common';
import { Component, Input, input, OnInit } from '@angular/core';
import { Product } from '../Models/ProductDto';

@Component({
  selector: 'app-shop-item',
  imports: [CurrencyPipe],
  templateUrl: './shop-item.html',
  styleUrl: './shop-item.css',
})
export class ShopItem {
  product = input.required<Product>();
}
