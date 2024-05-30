import { LoginTutorComponent } from './../components/login-tutor/login-tutor.component';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { enviroment } from '../enviroments/enviroment';
import { UserDto } from '../models/user.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  constructor(private http: HttpClient, private router: Router) { }

  baseApiUrl: string = enviroment.baseApiUrl;

  loginStudent(user: UserDto): Observable<UserDto>{
    return this.http.post<UserDto>(this.baseApiUrl + '/api/auth/loginStudent', user);
  }

  registerStudent(user: UserDto): Observable<UserDto>{
    return this.http.post<UserDto>(this.baseApiUrl + '/api/auth/registerStudent', user);
  }
  
  loginTutor(user: UserDto): Observable<UserDto>{
    debugger
    return this.http.post<UserDto>(this.baseApiUrl + '/api/auth/loginTutor', user);
  }

  registerTutor(user: UserDto): Observable<UserDto>{
    return this.http.post<UserDto>(this.baseApiUrl + '/api/auth/registerTutor', user);
  }
  
  
  //renewToken(user: UserDto): Observable<UserDto>{
  //  return this.http.post<UserDto>(this.baseApiUrl + '/api/auth/renewToken', user);
  //}


  public static isLoggedIn(): boolean {
    const token = localStorage.getItem('jwtToken');
    if (token) {
      // Optionally, you can check if the token is expired
      const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
      return (Math.floor((new Date).getTime() / 1000)) < expiry;
    }
    return false;
  }

  logout(): void {
    localStorage.removeItem('jwtToken');
    this.router.navigate(['/login']);
  }
}
