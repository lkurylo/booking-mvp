import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BarbersService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5005';

  getBarbers() {
    return this.http.get(`${this.apiUrl}/barbers/load`);
  }
}
