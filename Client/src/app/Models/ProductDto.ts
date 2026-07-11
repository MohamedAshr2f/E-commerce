export interface Product {
  id: number;
  name: string;
  description: string;
  newPrice: number;
  oldPrice: number;
  rating: number;
  categoryName: string;
  images: Image[];
}
export interface Image {
  id: number;
  imageName: string;
}
