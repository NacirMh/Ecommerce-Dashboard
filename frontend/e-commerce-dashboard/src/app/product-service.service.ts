import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { throwError } from 'rxjs'; // Import throwError

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  private apiUrl = 'https://localhost:7086/api/Product';

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<any> {
    return this.http.get(this.apiUrl);
    
  }

  public postProduct(productData: any): Observable<any> {
    return this.http.post(this.apiUrl, JSON.stringify(productData));
  }

  public deleteAllProducts(): Observable<any> {
    return this.http.delete(this.apiUrl);
  }

  public updateProductById(productId: string, productData: any): Observable<any> {
    const updateUrl = `${this.apiUrl}/${productId}`;
    return this.http.patch(updateUrl, productData);
  }

  public deleteProductById(productId: string): Observable<any> {
    const deleteUrl = `${this.apiUrl}/${productId}`;
    return this.http.delete(deleteUrl);
  }

  public getProductById(productId: string): Observable<any> {
    const getUrl = `${this.apiUrl}/${productId}`;
    return this.http.get(getUrl);
  }

}

