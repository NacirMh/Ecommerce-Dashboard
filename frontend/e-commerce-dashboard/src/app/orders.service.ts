import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private apiUrl = 'https://localhost:7086/api/Order';

  constructor(private http: HttpClient) { }

  public getOrders(): Observable<any> {
    return this.http.get(this.apiUrl);
    
  }

  

  public postProduct(productData: any): Observable<any> {
    return this.http.post(this.apiUrl, JSON.stringify(productData));
  }

  public getOrderById(id:string){
    return this.http.get(`${this.apiUrl}/${id}`);
  }

    // Delete a specific order by ID
    public deleteOrderById(id: string): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${id}`);
    }
  
    // Delete all orders
    public deleteAllOrders(): Observable<any> {
      return this.http.delete(this.apiUrl);
    }

    public updateOrderStatusById(id: string, newStatus: boolean) {
    
      
      const url = `${this.apiUrl}/updateStatus/${id}`;
    
      return this.http.put(url, newStatus);
    }
    
}
