import { Pipe, PipeTransform } from '@angular/core';
import { GradeLevel } from '../enums/grade-level.enum';

@Pipe({
  name: 'gradeToUa',
})
export class GradeToUaPipe implements PipeTransform {

  transform(value: GradeLevel | null): string {
    if (value === null) return 'N/A';
    switch (value) {
      case GradeLevel.University: return 'Університетські курси';
      case GradeLevel.Olympiads: return 'Олімпіадна підготовка';
      case GradeLevel.ZNO: return 'ЗНО';
      case GradeLevel.Grades10_11: return '10-11й класи';
      case GradeLevel.DPA: return 'ДПА';
      case GradeLevel.Grades7_9: return '7-9й класи';
      case GradeLevel.Grades5_6: return '5-6й класи';
      case GradeLevel.Grades1_4: return '1-4й класи';
      default: return 'N/A';
    }
  }

}
