import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, switchMap, Subject } from 'rxjs';
import { enviroment } from '../enviroments/enviroment'; 
import { TutorDto } from '../models/tutor.model';
import { ActivatedRoute, Router } from '@angular/router';
import { TutorFilterDto } from '../models/tutor-filter.model';
@Injectable({
  providedIn: 'root'
})
export class TutorService {
  private readonly apiUrl = enviroment.baseApiUrl + '/api/tutors';

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  getTutors(): Observable<{tutors: TutorDto[], allFoundedCount: number }> {
    return this.route.queryParams.pipe(
      map(params => {
        const filters = {
          Subject: params['Subject'] || null,
          GradeLevel: params['GradeLevel'] || null,
          MinPrice: params['MinPrice'] || null,
          MaxPrice: params['MaxPrice'] || null,
          Page: params['Page'] || null
        };
  
        const queryParams = Object.keys(filters)
          .filter(key => filters[key] !== null)
          .map(key => `${key}=${filters[key]}`)
          .join('&');

        return this.http.get<{tutors: TutorDto[], allFoundedCount: number }>(this.apiUrl+`?${queryParams}`);
      }),
      switchMap(observable => observable),
      map(response => response as {tutors: TutorDto[], allFoundedCount: number})
    );
  }
}
