import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from './models/person.model';
import { User } from './models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  readonly apiUrl: string = 'http://localhost:5227/api/';
  constructor(private http: HttpClient) { }

  private GetHttpOptions()
  {
    let token = "Bearer " + localStorage.getItem('token');
    return {
      headers: new HttpHeaders({
        'Authorization': token,
        'Content-Type': 'application/json'
      })
    }
  }

  createPerson(person: Person): Observable<any>
  {
    return this.http.post(this.apiUrl + 'Person', person, this.GetHttpOptions());
  }

  getPersons(): Observable<any>
  {
    return this.http.get(this.apiUrl + 'Person', this.GetHttpOptions())
  }

  createUser(user: User): Observable<any>
  {
    return this.http.post(this.apiUrl + 'User', user, this.GetHttpOptions());
  }

  login(user: User): Observable<any>
  {
    return this.http.post(this.apiUrl + 'User/login', user);
  }
}
