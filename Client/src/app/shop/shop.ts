import {
  Component,
  DestroyRef,
  ElementRef,
  inject,
  OnInit,
  signal,
  viewChild,
} from '@angular/core';
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
  searchinput = viewChild.required<ElementRef<HTMLInputElement>>('search');
  sortinput = viewChild.required<ElementRef<HTMLInputElement>>('sortedselected');

  selectcatgoryid?: number;
  sortselected: string = '';
  Searchterm: string = '';

  SortingOption = [
    { name: 'Name', value: 'Name_Asc' },
    { name: 'Price:min-max', value: 'Price_Asc' },
    { name: 'Price:max-min', value: 'Price_Desc' },
  ];

  ngOnInit() {
    this.getproducts();
    this.getcategories();
  }

  // Single method for all product fetching: no filter, category only, sort only, or both
  getproducts() {
    this.isFetching.set(true);
    this.error.set('');

    const subscription = this.shopservice
      .GetProductPagination(
        0,
        10,
        this.sortselected || undefined,
        this.Searchterm,
        this.selectcatgoryid,
      )
      .subscribe({
        next: (products) => {
          this.products.set(products);
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
    this.getproducts();
  }

  SortinByPrice(sort: Event) {
    this.sortselected = (sort.target as HTMLInputElement).value;
    this.getproducts();
  }
  OnSearch(search: string) {
    this.Searchterm = search;
    this.getproducts();
  }
  ResetValue() {
    this.selectcatgoryid = undefined;
    this.Searchterm = '';
    this.sortselected = '';
    this.searchinput().nativeElement.value = '';
    this.sortinput().nativeElement.value = 'Name_Asc';
    this.getproducts();
  }
}
