export interface PaginationApiResponse<T> {
  data: T;
  currentPage: number;
  totalPages: number;
  totalCount: number;
  meta: any;
  pageSize: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
  messages: any[];
  succeeded: boolean;
}
