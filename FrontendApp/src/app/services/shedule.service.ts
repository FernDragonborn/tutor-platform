import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from '../enviroments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  private apiUrl = enviroment.baseApiUrl + 'api/student-schedule';

  constructor(private http: HttpClient) { }

  getLessons(): Observable<boolean[][]> {
    return this.http.get<boolean[][]>(this.apiUrl);
  }

  updateLessons(lessons: boolean[][]): Observable<void> {
    return this.http.put<void>(this.apiUrl, lessons);
  }

  bookLesson(lesson: boolean[][]): Observable<void> {
    return this.http.put<void>(this.apiUrl, lesson);
  }

  getSchedule(): Observable<boolean[][]> {
    return this.http.get<boolean[][]>(this.apiUrl);
  }

  updateSchedule(schedule: boolean[][]): Observable<void> {
    return this.http.put<void>(this.apiUrl, schedule);
  }
}
