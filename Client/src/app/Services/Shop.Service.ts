import { inject, Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Category } from '../Models/CategoryDto';
import { catchError, map, throwError } from 'rxjs';
import { ApiResponse } from '../Bases/ApiResponse';
import { Product } from '../Models/ProductDto';
import { SelectorlessMatcher } from '@angular/compiler';
import { PaginationApiResponse } from '../Bases/PaginationApiResponse';
import { Productparam } from '../Models/ProductParam';
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

  GetProductsSorted(sort?: string, categoryId?: number) {
    let url = 'https://localhost:7109/Api/V1/Product/Sorted';
    let param = new HttpParams();
    if (categoryId) {
      param = param.append('CategoryId', categoryId);
    }
    if (sort) {
      param = param.append('SortBy', sort);
    }
    return this.httpClient.get<ApiResponse<Product[]>>(url, { params: param }).pipe(
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
  GetProductPagination(productParam: Productparam) {
    let url = 'https://localhost:7109/Api/V1/Product/Pagination';
    let param = new HttpParams();
    param = param.append('PageNumber', productParam.pageNumber);
    param = param.append('PageSize', productParam.pageSize);
    if (productParam.Searchterm) {
      param = param.append('SearchWord', productParam.Searchterm);
    }
    if (productParam.sortselected) {
      param = param.append('OrderBy', productParam.sortselected);
    }
    if (productParam.selectcatgoryid) {
      param = param.append('CategoryId', productParam.selectcatgoryid);
    }
    return this.httpClient.get<PaginationApiResponse<Product[]>>(url, { params: param });
  }
}
