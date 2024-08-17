import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CostumersService {

  private apiUrl = 'https://localhost:7086/api/Customer';

  constructor(private http: HttpClient) { }

  public getCostumer(): Observable<any> {
    return this.http.get(this.apiUrl);
    
  }
  
  public getCostumerByID(id:string): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
    
  }

  public deleteCostumerById(id:string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
    
  }

}
