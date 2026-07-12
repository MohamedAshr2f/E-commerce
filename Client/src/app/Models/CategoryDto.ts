import { Product } from './ProductDto';

export interface Category {
  categoryId: number;
  name: string;
  description: string;
  products: Product[];
}
