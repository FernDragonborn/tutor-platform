import { Experience } from 'src/app/enums/experience.enum';
import { Component, OnInit } from '@angular/core';
import { TutorDto } from 'src/app/models/tutor.model';
import { SubjectType } from 'src/app/enums/subject-type.enum';
import { SubjectDto } from 'src/app/models/subject.model';
import { GradeLevelsDto } from 'src/app/models/grade-level.model';
import { GradeLevel } from 'src/app/enums/grade-level.enum';

@Component({
  selector: 'app-profile-tutor',
  templateUrl: './profile-tutor.component.html',
  styleUrl: './profile-tutor.component.scss'
})
export class ProfileTutorComponent implements OnInit {
  
  tutor: TutorDto = new TutorDto();
  email: String;
  isChangingName: boolean = true;
  isChangingPassword: boolean = true;
  isAddingSubject: boolean = false;
  experiences = Object.values(Experience);
  subjects = Object.values(SubjectType);
  gradeLevels = Object.values(GradeLevel);
  selectedGrades: GradeLevel[] = [];
  subjectToAdd: SubjectDto | null;
  isDropdownVisible = false;


  prices: number[] = [
    120, 140, 150, 170, 200, 220, 250, 270, 300, 350, 400, 450, 500, 600,
    700, 800, 900, 1000, 1200, 1400, 1500, 1600, 1800,
    2000, 2500
  ];

  ngOnInit(){
    this.tutor.firstName = "Fern"
    this.tutor.lastName = "Dragonborn"
  }


  addGrade(selectedGrade: GradeLevel) {
    if (!this.selectedGrades.includes(selectedGrade)) {
      this.selectedGrades.push(selectedGrade);
    }
    this.isDropdownVisible = false; // Закриваємо випадаючий список після вибору
  }

  removeGrade(grade: GradeLevel) {
    const index = this.selectedGrades.indexOf(grade);
    if (index >= 0) {
      this.selectedGrades.splice(index, 1);
    }
  }

  addToSubjects(subject: SubjectType) {
    this.tutor.subjects.push(new SubjectDto(
      subject,0,new GradeLevelsDto[0],'' 
    ));
    this.subjectToAdd = null;
  }

  onEnter(){

  }

  changePassword(){

  }

  onAddingSubject(){
    this.isAddingSubject = !this.isAddingSubject
  }

  toggleNameMenu(): void{
    this.isChangingName = !this.isChangingName;
  }

  togglePasswordMenu(): void{
    this.isChangingPassword = !this.isChangingPassword;
  }

  toggleDropdown() {
    this.isDropdownVisible = !this.isDropdownVisible;
  }
}