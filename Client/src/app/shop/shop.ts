import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { ShopService } from '../Services/Shop.Service';
import { Product } from '../Models/ProductDto';
import { CurrencyPipe } from '@angular/common';
import { ShopItem } from '../shop-item/shop-item';
import { Category } from '../Models/CategoryDto';
import { Categories } from '../categories/categories';

@Component({
  selector: 'app-shop',
  imports: [CurrencyPipe, ShopItem, Categories],
  templateUrl: './shop.html',
  styleUrl: './shop.css',
})
export class Shop implements OnInit {
  isFetching = signal(false);
  products = signal<Product[] | undefined>(undefined);
  categories = signal<Category[] | undefined>(undefined);
  private destroyRef = inject(DestroyRef);
  private shopservice = inject(ShopService);
  error = signal('');
  selectcatgoryid?: number;

  ngOnInit() {
    this.getproducts();
    this.getcategories();
  }

  getproducts() {
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

  getcategories() {
    this.isFetching.set(true);

    const subscription = this.shopservice.GetCategoriesList().subscribe({
      next: (categories) => {
        this.categories.set(categories);
        console.log(categories);
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
  getproductsbycategory(categoryId: number) {
    this.isFetching.set(true);
    this.error.set('');

    const subscription = this.shopservice.GetCategoryById(categoryId).subscribe({
      next: (category) => {
        this.products.set(category.products);
        console.log(category.products);
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
  selectcategory(categoryid: number) {
    if (this.selectcatgoryid === categoryid) {
      // clicked the already-selected category -> clear filter
      this.selectcatgoryid = undefined;
      this.getproducts();
      return;
    }

    this.selectcatgoryid = categoryid;
    this.getproductsbycategory(categoryid);
  }
}
