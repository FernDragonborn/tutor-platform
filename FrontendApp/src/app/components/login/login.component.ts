import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LoginEnum } from 'src/app/enums/login.enum';
import { UserDto } from 'src/app/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user: UserDto = new UserDto();
  requestType: LoginEnum;
  
  loginForm = new FormGroup({
    login: new FormControl(''),
    password: new FormControl(''),
  });

  @Input() headerText: String;
  @Output() RequestEmitter = new EventEmitter<{userDto: UserDto, enum: LoginEnum }>();
  
  emitRequest(): void{
    this.RequestEmitter.emit({userDto: this.user, enum: this.requestType })
  }

  login(user: UserDto){
    this.user = user;
    this.requestType = LoginEnum.login;
    this.emitRequest()
  }

  register(user: UserDto){
    this.user = user;
    this.requestType = LoginEnum.register;
    this.emitRequest()
  }

}
