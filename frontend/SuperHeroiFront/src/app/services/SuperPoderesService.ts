import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SuperPoder } from '../interfaces/superpoder.interface';

@Injectable({
  providedIn: 'root'
})
export class SuperPoderesService {
  private apiUrl = 'https://localhost:44346/api/SuperPoderes';

  constructor(private http: HttpClient) { }

  obterTodosSuperPoderes(): Observable<SuperPoder[]> {
    return this.http.get<SuperPoder[]>(`${this.apiUrl}/ObterTodosSuperPoderes`);
  }

  registrarSuperPoder(superPoder: SuperPoder): Observable<any> {
    return this.http.post(`${this.apiUrl}/RegistrarSuperPoder`, superPoder);
  }
}
