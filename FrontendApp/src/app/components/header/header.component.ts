import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'header-component',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  userName: string | null;

  isUsernameNotNull(): boolean{
    return this.userName !== " .";
  }

  constructor(private authService: AuthService){}

  LogOut(){
    this.authService.logout();
  }

  OnInit(){
  }
  
  isLoggedIn(){
    this.userName = localStorage.getItem('userName');
    return AuthService.isLoggedIn();
  }
}
