import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { TutorsComponent } from './components/tutors/tutors.component';
import { PriceSliderComponent } from './components/price-slider/price-slider.component';

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
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'slider',
    component: PriceSliderComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
