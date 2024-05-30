import { Component, OnInit } from '@angular/core';
import { UserDto } from 'src/app/models/user.model';

@Component({
  selector: 'app-profile-tutor',
  templateUrl: './profile-tutor.component.html',
  styleUrl: './profile-tutor.component.css'
})
export class ProfileTutorComponent {
  user: UserDto;
  email: String;
  isChangingName: boolean = false;
  isChangingPassword: boolean = false;

  OnInit(){

  }

  toggleNameMenu(): void{
    this.isChangingName = !this.isChangingName;
  }

  togglePasswordMenu(): void{
    this.isChangingPassword = !this.isChangingPassword;
  }
}