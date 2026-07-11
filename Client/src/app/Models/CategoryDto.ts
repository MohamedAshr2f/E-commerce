export interface ProductDto {
  productId: number;
  name: string;
  description: string;
  newPrice: number;
  oldPrice: number;
  rating: number;
}

export interface Category {
  categoryId: number;
  name: string;
  description: string;
  products: ProductDto[];
}
