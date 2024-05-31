import { Pipe, PipeTransform } from '@angular/core';
import { SubjectType } from '../enums/subject-type.enum';

@Pipe({
  name: 'subjectToUa'
})
export class SubjectToUaPipe implements PipeTransform {
  private readonly subjectNamesUa: { [key in SubjectType]: string } = {
    [SubjectType.Junior]: 'Молодші класи',
    [SubjectType.Maths]: 'Математика',
    [SubjectType.WorldHistory]: 'Всесвітня історія',
    [SubjectType.UkrainianHistory]: 'Історія України',
    [SubjectType.WorldLiterature]: 'Зарубіжна література',
    [SubjectType.UkrainianLiterature]: 'Українська література',
    [SubjectType.Geography]: 'Географія',
    [SubjectType.ComputerScience]: 'Інформатика',
    [SubjectType.Chemistry]: 'Хімія',
    [SubjectType.Physics]: 'Фізика',
    [SubjectType.Ukrainian]: 'Українська мова',
    [SubjectType.English]: 'Англійська мова',
    [SubjectType.German]: 'Німецька мова',
    [SubjectType.French]: 'Французька мова',
    [SubjectType.Polish]: 'Польська мова',
    [SubjectType.Spanish]: 'Іспанська мова'
  };

  transform(value: SubjectType): string {
    return this.subjectNamesUa[value] || 'Unknown Subject';
  }
}
