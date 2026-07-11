import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from './Core/nav-bar/nav-bar';
import { ShopService } from './Services/Shop.Service';
import { Category } from './Models/CategoryDto';
import { Shop } from './shop/shop';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBar, Shop],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  title = signal('EcommerceClient');
}
