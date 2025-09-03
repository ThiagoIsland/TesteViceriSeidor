import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SuperHeroi } from '../interfaces/SuperHeroi.interface';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroiService {
  private apiUrl = 'https://localhost:44346/api/SuperHeroi';

  constructor(private http: HttpClient) { }

  obterTodosSuperHerois(): Observable<SuperHeroi[]> {
    return this.http.get<SuperHeroi[]>(`${this.apiUrl}/ObterTodosSuperHerois`);
  }

  obterSuperHeroi(id: number): Observable<SuperHeroi> {
    return this.http.get<SuperHeroi>(`${this.apiUrl}/ObterSuperHeroi/${id}`);
  }

  registrarSuperHeroi(superHeroi: SuperHeroi): Observable<any> {
    return this.http.post(`${this.apiUrl}/RegistrarSuperHeroi`, superHeroi);
  }

  atualizarSuperHeroi(id: number, superHeroi: SuperHeroi): Observable<SuperHeroi> {
    return this.http.put<SuperHeroi>(`${this.apiUrl}/AtualizarSuperHeroi/${id}`, superHeroi);
  }

  deletarSuperHeroi(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/DeletarSuperHeroi/${id}`);
  }
}
