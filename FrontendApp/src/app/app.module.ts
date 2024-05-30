import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FileUploadModule } from 'ng2-file-upload';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

import { AppComponent } from './app.component';
import { LoginStudentComponent } from './components/login-student/login-student.component';
import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { DragNDropUploadComponent } from './components/drag-n-drop-upload/drag-n-drop-upload.component';
import { DialogConfirmComponent } from './components/dialog-confirm/dialog-confirm.component';
import { FileDragNDropDirective } from './components/drag-n-drop-upload/file-drag-n-drop.directive';
import { TutorsComponent } from './components/tutors/tutors.component';
import { NgxSliderModule } from '@angular-slider/ngx-slider';
import { PriceSliderComponent } from './components/price-slider/price-slider.component';
import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { GenderPipe } from './pipes/gender.pipe';
import { ExperiencePipe } from './pipes/experience.pipe';
import { HeaderComponent } from './components/header/header.component';
import { LoginTutorComponent } from './components/login-tutor/login-tutor.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileTutorComponent } from './components/profile-tutor/profile-tutor.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LoginStudentComponent,
    LoginTutorComponent,
    DragNDropUploadComponent,
    DialogConfirmComponent,
    FileDragNDropDirective,
    TutorsComponent,
    PriceSliderComponent,
    TutorCardComponent,
    ProfileTutorComponent,
    ExperiencePipe,
    GenderPipe,
    HeaderComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    NgxSliderModule
  ],
  providers: [AuthService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,   
  } ],
  bootstrap: [AppComponent]
})
export class AppModule { }

