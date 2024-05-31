import { Pipe, PipeTransform } from '@angular/core';
import { Experience } from '../enums/experience.enum'; 

@Pipe({ name: 'experiencePipe' })
export class ExperiencePipeToUa implements PipeTransform {
  transform(value: Experience | null): string {
    if (value === null) return 'N/A';
    switch (value) {
      case Experience.LessThan1: return '<1 year';
      case Experience.OnePlus: return '1+ years';
      case Experience.TwoPlus: return '2+ years';
      case Experience.ThreePlus: return '3+ years';
      case Experience.FivePlus: return '5+ years';
      case Experience.TenPlus: return '10+ years';
      case Experience.FifteenPlus: return '15+ years';
      case Experience.TwentyPlus: return '20+ years';
      default: return 'N/A';
    }
  }
}
