import { Pipe, PipeTransform } from '@angular/core';
import { SubjectType } from '../enums/subject-type.enum';

@Pipe({
  name: 'uaToSubject'
})
export class UaToSubjectPipe implements PipeTransform {
  private readonly subjectTypesUa: { [key: string]: SubjectType } = {
    'Молодші класи': SubjectType.Junior,
    'Математика': SubjectType.Maths,
    'Всесвітня історія': SubjectType.WorldHistory,
    'Історія України': SubjectType.UkrainianHistory,
    'Зарубіжна література': SubjectType.WorldLiterature,
    'Українська література': SubjectType.UkrainianLiterature,
    'Географія': SubjectType.Geography,
    'Інформатика': SubjectType.ComputerScience,
    'Хімія': SubjectType.Chemistry,
    'Фізика': SubjectType.Physics,
    'Українська мова': SubjectType.Ukrainian,
    'Англійська мова': SubjectType.English,
    'Німецька мова': SubjectType.German,
    'Французька мова': SubjectType.French,
    'Польська мова': SubjectType.Polish,
    'Іспанська мова': SubjectType.Spanish
  };

  transform(value: string): SubjectType {
    return this.subjectTypesUa[value] || 'Unknown Subject';
  }
}
