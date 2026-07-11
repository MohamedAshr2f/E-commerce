import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { ShopService } from '../Services/Shop.Service';
import { Product } from '../Models/ProductDto';

@Component({
  selector: 'app-shop',
  imports: [],
  templateUrl: './shop.html',
  styleUrl: './shop.css',
})
export class Shop implements OnInit {
  isFetching = signal(false);
  products = signal<Product[] | undefined>(undefined);
  private destroyRef = inject(DestroyRef);
  private shopservice = inject(ShopService);
  error = signal('');

  ngOnInit() {
    this.isFetching.set(true);
    const subscription = this.shopservice.GetProductsList().subscribe({
      next: (products) => {
        this.products.set(products);
        console.log(products);
      },
      error: (error: Error) => {
        this.error.set(error.message);
      },
      complete: () => {
        this.isFetching.set(false);
      },
    });
    this.destroyRef.onDestroy(() => {
      subscription.unsubscribe();
    });
  }
}
