export interface ApiResponse<T> {
  data: T;
  type: string;
  title: string;
  status: number;
  traceId: string;
  error: string;
}
