import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Category } from '../Models/CategoryDto';
import { catchError, map, throwError } from 'rxjs';
import { ApiResponse } from '../Bases/ApiResponse';
import { Product } from '../Models/ProductDto';
@Injectable({
  providedIn: 'root',
})
export class ShopService {
  private httpClient = inject(HttpClient);

  GetProductsList() {
    return this.fetchProducts(
      'https://localhost:7109/Api/V1/Product/List',
      'Something went wrong fetching the products. please try again later .',
    );
  }
  private fetchProducts(url: string, errorMessage: string) {
    return this.httpClient.get<ApiResponse<Product[]>>(url).pipe(
      map((resData) => resData.data),
      catchError((error) => {
        console.log(error);
        return throwError(() => new Error(errorMessage));
      }),
    );
  }
  GetCategoriesList() {
    return this.fetchCategories(
      'https://localhost:7109/Api/V1/Category/List',
      'Something went wrong fetching the categories. please try again later .',
    );
  }

  private fetchCategories(url: string, errorMessage: string) {
    return this.httpClient.get<ApiResponse<Category[]>>(url).pipe(
      map((resData) => resData.data),
      catchError((error) => {
        console.log(error);
        return throwError(() => new Error(errorMessage));
      }),
    );
  }
  GetCategoryById(categoryId: number) {
    let url = 'https://localhost:7109/Api/V1/Category/';
    return this.httpClient.get<ApiResponse<Category>>(url + categoryId).pipe(
      map((resData) => resData.data),
      catchError((error) => {
        console.log(error);
        return throwError(
          () =>
            new Error(
              'Something went wrong fetching the category products. please try again later .',
            ),
        );
      }),
    );
  }
}
