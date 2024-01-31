export interface PagedResult<T> {
    result: T[];
    pageIndex: number;
    totalItems: number;
  }