import { Component } from '@angular/core';
import { SubjectType, SubjectNamesUa } from '../../enums/subject-type.enum';
import { GradeLevel, GradeNamesUa } from 'src/app/enums/grade-level.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { TutorService } from 'src/app/services/tutor.service';
import { TutorDto } from 'src/app/models/tutor.model';

@Component({
  selector: 'app-tutors',
  templateUrl: './tutors.component.html',
  styleUrls: ['./tutors.component.css']
})
export class TutorsComponent {
  subjects = Object.values(SubjectType);
  grades = Object.values(GradeLevel);
  selectedSubject: SubjectType | null = null;
  selectedGrade: GradeLevel | null = null;
  tutors: TutorDto[] = [];
  isSubjectsMenuCollapsed = false;
  isGradesMenuCollapsed = false;
  allFoundedCount : number = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tutorService: TutorService
  ) {}

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      const subject = params.get('subject') as SubjectType;
      const grade = params.get('grade') as GradeLevel;
      if (subject) {
        this.fetchTutors();
      }
    });
  }

  getSubjectName(subject: SubjectType): string {
    return SubjectNamesUa[subject];
  }

  getGradeName(grade: GradeLevel): string {
    return GradeNamesUa[grade];
  }

  generateId(item: string): string {
    return `item-${item}`;
  }

  onSubjectSelected(subject: SubjectType): void {
    this.selectedSubject = subject;
    this.toggleSubjectsMenu();
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { subject },
      queryParamsHandling: 'merge'
    });
  }

  onGradeSelected(grade: GradeLevel): void {
    this.selectedGrade = grade;
    this.toggleGradesMenu();
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { grade },
      queryParamsHandling: 'merge'
    });
  }

  toggleSubjectsMenu(): void {
    this.isSubjectsMenuCollapsed = !this.isSubjectsMenuCollapsed;
  }

  toggleGradesMenu(): void {
    this.isGradesMenuCollapsed = !this.isGradesMenuCollapsed;
  }
  private fetchTutors(): void {
    this.tutorService.getTutors().subscribe(data => {
      this.allFoundedCount = data.allFoundedCount
      this.tutors = data.tutors;
    });
  }
}
