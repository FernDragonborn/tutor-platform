import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginStudentComponent } from './components/login-student/login-student.component';
import { TutorsComponent } from './components/tutors/tutors.component';
import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { LoginTutorComponent } from './components/login-tutor/login-tutor.component';
import { ProfileTutorComponent } from './components/profile-tutor/profile-tutor.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'tutors',
    pathMatch: 'full'
  },
  {
    path: 'tutors',
    component: TutorsComponent
  },
  {
    path: 'login-student',
    component: LoginStudentComponent
  },
  {
    path: 'login-tutor',
    component: LoginTutorComponent
  },
  {
    path: 'profile-tutor',
    component: ProfileTutorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
