export interface Product {
  productId: number;
  name: string;
  description: string;
  newPrice: number;
  oldPrice: number;
  rating: number;
  CategoryName: string;
  images: {
    Id: number;
    ImageName: string;
  };
}
