import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PriceService {
  private minValueSubject = new BehaviorSubject<number>(100);
  private maxValueSubject = new BehaviorSubject<number>(2500);

  minValue$ = this.minValueSubject.asObservable();
  maxValue$ = this.maxValueSubject.asObservable();

  setMinValue(value: number): void {
    this.minValueSubject.next(value);
  }

  setMaxValue(value: number): void {
    this.maxValueSubject.next(value);
  }
}
