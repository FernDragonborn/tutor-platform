import { Component } from '@angular/core';
import { SubjectType, SubjectNamesUa } from '../../enums/subject-type.enum';
import { GradeLevel, GradeNamesUa } from 'src/app/enums/grade-level.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { TutorService } from 'src/app/services/tutor.service';
import { TutorDto } from 'src/app/models/tutor.model';
import { Experience } from 'src/app/enums/experience.enum';
import { Gender } from 'src/app/enums/gernder.enum';
import { Degree } from 'src/app/enums/degree.enum';
import { GradeLevelsDto } from 'src/app/models/grade-level.model';

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
  minPrice : number = 100;
  maxPrice : number = 2500;

  exampleTutor: TutorDto = {
    firstName: 'John',
    lastName: 'Doe',
    email: 'john.doe@example.com',
    phoneNumber: '1234567890',
    viber: '',
    telegram: '',
    isVerified: true,
    isProfileActive: true,
    experience: Experience.FivePlus,
    subjects: [
      { subjectName: 'Mathematics', price: 200,  gradeLevels: new Array<GradeLevelsDto>, description: 'Algebra and Calculus' }
    ],
    educations: [
      { universityName: 'University of Example', degree: Degree.Bachelor, graduationYear: 2010 }
    ],
    shortDescription: 'Experienced Mathematics Tutor',
    longDescription: 'I have over 5 years of experience in teaching Mathematics...',
    profilePic: null,
    priceToShow: 200,
    ageGroup: null,
    gender: Gender.Male,
    youtubeVideoLink: 'https://www.youtube.com/watch?v=dQw4w9WgXcQ',
    schedule: [],
    reviews: []
  };


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tutorService: TutorService,
    
  ) {  }

  ngOnInit(): void {
    this.fetchTutors();
    this.route.queryParams.subscribe(params => {
      this.minPrice = params['minPrice'];
      this.maxPrice = params['maxPrice'];
      this.fetchTutors();
    });
  }

  onSubjectSelected(subject: SubjectType): void {
    this.selectedSubject = subject;
    this.toggleSubjectsMenu();
    this.fetchTutors();
    
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: { subject },
        queryParamsHandling: 'merge'
      });
    
  }

  onGradeSelected(grade: GradeLevel): void {
    this.selectedGrade = grade;
    this.toggleGradesMenu();
    this.fetchTutors();
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { grade },
      queryParamsHandling: 'merge'
    });
  }

  private fetchTutors(): void {
    this.tutorService.getTutors().subscribe(data => {
      if(data === null){
        this.allFoundedCount = 0;
        this.tutors = [];
        return;    
      }
      this.allFoundedCount = data.allFoundedCount;
      this.tutors = data.tutors;
    });
  }


  removeSubjectFilter(): void{
    this.toggleSubjectsMenu()
    this.selectedSubject = null;
    this.router.navigate([],{
      relativeTo: this.route,
      queryParams: { ['subject']: null},
      queryParamsHandling: 'merge'
    })
  }

  removeGradeFilter(): void{
    this.toggleGradesMenu()
    this.selectedGrade = null;
    this.router.navigate([],{
      relativeTo: this.route,
      queryParams: { ['grade']: null},
      queryParamsHandling: 'merge'
    })
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
}


