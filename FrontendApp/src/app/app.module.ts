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
import { LoginComponent } from './components/login/login.component';
import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { DragNDropUploadComponent } from './components/drag-n-drop-upload/drag-n-drop-upload.component';
import { DialogConfirmComponent } from './components/dialog-confirm/dialog-confirm.component';
import { FileDragNDropDirective } from './components/drag-n-drop-upload/file-drag-n-drop.directive';
import { TutorsComponent } from './components/tutors/tutors.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DragNDropUploadComponent,
    DialogConfirmComponent,
    FileDragNDropDirective,
    TutorsComponent,
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
    MatInputModule
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

