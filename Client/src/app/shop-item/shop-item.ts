import { CurrencyPipe } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-shop-item',
  imports: [CurrencyPipe],
  templateUrl: './shop-item.html',
  styleUrl: './shop-item.css',
})
export class ShopItem {}
