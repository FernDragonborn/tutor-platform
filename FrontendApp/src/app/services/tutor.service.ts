import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from '../enviroments/enviroment'; 

@Injectable({
  providedIn: 'root'
})
export class TutorService {
  private apiUrl = enviroment.baseApiUrl + '/tutors';

  constructor(private http: HttpClient) {}

  getTutorsBySubject(subject: string): Observable<any> {
    return this.http.get(`${this.apiUrl}?subject=${subject}`);
  }

  getTutorsByGrade(grade: string): Observable<any> {
    return this.http.get(`${this.apiUrl}?grade=${grade}`);
  }
}
