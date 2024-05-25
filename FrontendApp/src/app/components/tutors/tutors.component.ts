import { Component, OnInit } from '@angular/core';
import { SubjectType, SubjectNamesUa } from '../../enums/subject-type.enum';
import { GradeLevel, GradeNamesUa } from 'src/app/enums/grade-level.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { TutorService } from 'src/app/services/tutor.service';

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
  tutors: any[] = [];
  isSubjectsMenuCollapsed = false;
  isGradesMenuCollapsed = false;

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
        this.selectedSubject = subject;
        this.fetchTutorsBySubject(subject);
      }
      if (grade) {
        this.selectedGrade = grade;
        this.fetchTutorsByGrade(grade);
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

  toggleSubjectsMenu(): void {
    this.isSubjectsMenuCollapsed = !this.isSubjectsMenuCollapsed;
  }

  toggleGradesMenu(): void {
    this.isGradesMenuCollapsed = !this.isGradesMenuCollapsed;
  }

  onSubjectSelected(subject: SubjectType): void {
    this.selectedSubject = subject;
    this.selectedGrade = null;
    this.isSubjectsMenuCollapsed = true;
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { subject },
      queryParamsHandling: 'merge'
    });
  }

  onGradeSelected(grade: GradeLevel): void {
    this.selectedGrade = grade;
    this.selectedSubject = null;
    this.isGradesMenuCollapsed = true;
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { grade },
      queryParamsHandling: 'merge'
    });
  }

  private fetchTutorsBySubject(subject: SubjectType): void {
    this.tutorService.getTutorsBySubject(subject).subscribe(data => {
      this.tutors = data;
    });
  }

  private fetchTutorsByGrade(grade: GradeLevel): void {
    this.tutorService.getTutorsByGrade(grade).subscribe(data => {
      this.tutors = data;
    });
  }
}
