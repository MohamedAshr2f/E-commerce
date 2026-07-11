export interface Product {
  productId: number;
  name: string;
  description: string;
  newPrice: number;
  oldPrice: number;
  rating: number;
  CategoryName: string;
  images: Image[];
}

export interface Image {
  Id: number;
  ImageName: string;
}
