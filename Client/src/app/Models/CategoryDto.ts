export interface Category {
  categoryId: number;
  name: string;
  description: string;
  products: Productdto[];
}
export interface Productdto {
  productId: number;
  name: string;
  description: string;
  newPrice: number;
  oldPrice: number;
  rating: number;
}
