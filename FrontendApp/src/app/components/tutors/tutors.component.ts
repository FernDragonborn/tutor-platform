import { Component, OnInit } from '@angular/core';
import { Subject, SubjectNamesUa } from '../../enums/subject.enum';
import { Grades, GradesNamesUa } from 'src/app/enums/grades.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-tutors',
  templateUrl: './tutors.component.html',
  styleUrls: ['./tutors.component.css']
})
export class TutorsComponent {
  subjects = Object.values(Subject);
  grades = Object.values(Grades);
  selectedSubject: Subject | null = null;
  selectedGrade: Grades | null = null;
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
      const subject = params.get('subject') as Subject;
      const grade = params.get('grade') as Grades;
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

  getSubjectName(subject: Subject): string {
    return SubjectNamesUa[subject];
  }

  getGradeName(grade: Grades): string {
    return GradesNamesUa[grade];
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

  onSubjectSelected(subject: Subject): void {
    this.selectedSubject = subject;
    this.selectedGrade = null;
    this.isSubjectsMenuCollapsed = true;
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { subject },
      queryParamsHandling: 'merge'
    });
  }

  onGradeSelected(grade: Grades): void {
    this.selectedGrade = grade;
    this.selectedSubject = null;
    this.isGradesMenuCollapsed = true;
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { grade },
      queryParamsHandling: 'merge'
    });
  }

  private fetchTutorsBySubject(subject: Subject): void {
    this.tutorService.getTutorsBySubject(subject).subscribe(data => {
      this.tutors = data;
    });
  }

  private fetchTutorsByGrade(grade: Grades): void {
    this.tutorService.getTutorsByGrade(grade).subscribe(data => {
      this.tutors = data;
    });
  }
}
