import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BillboardService {
  private baseUrl = 'https://localhost:7086/api/Billboard';

  constructor(private http: HttpClient) { }

  getAllBillboards(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}`);
  }

  getBillboardById(id: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  createBillboard(data: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}`, data);
  }

  updateBillboardById(id: string, data: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, data);
  }

  deleteBillboardById(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }

  deleteAllBillboards(): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}`);
  }
}
