import { Pipe, PipeTransform } from '@angular/core';
import { Gender } from '../enums/gernder.enum';

@Pipe({ name: 'genderPipe' })
export class GenderPipeToUa implements PipeTransform {
  transform(value: Gender | null): string {
    if (value === null) return 'N/A';
    switch (value) {
      case Gender.Male: return 'Male';
      case Gender.Female: return 'Female';
      case Gender.Other: return 'Other';
      default: return 'N/A';
    }
  }
}
