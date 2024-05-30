import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginEnum } from 'src/app/enums/login.enum';
import { UserDto } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'login-student',
  templateUrl: './login-student.component.html',
  styleUrls: ['./login-student.component.css']
})

export class LoginStudentComponent {
  constructor(private authService: AuthService, private router: Router){}
  
  headerText: String = 'Увійти як учень'; 
  user: UserDto;

  ObtainRequest(data:{userDto: UserDto, enum: LoginEnum }){
    this.user = data.userDto;
    if(data.enum === LoginEnum.login){
      this.login();
    }
    else if(data.enum === LoginEnum.register){
      this.register();
    }
    else{
      console.error(`Component do not contain method for: ${data.enum}`)
    }
  }

  login(): void {
    this.authService.loginStudent(this.user)
    .subscribe((userDto) => {
        this.user = userDto;
        this.router.navigate(['tutors'])
        this.SetLocalStorage()
      },
      (error: HttpErrorResponse) => {
        console.error(error)
        alert(error.error)       
      })
  }

  register(): void {
    this.authService.registerStudent(this.user)
      .subscribe(
        (userDto) => {
        this.user = userDto;
        this.SetLocalStorage()
        this.router.navigate(['tutors'])
      },
      (error: HttpErrorResponse) => {
        console.error(error)
        alert(error.error)       
      }
    )
  }

  SetLocalStorage(){
    localStorage.setItem('jwtToken', this.user.jwtToken);
    localStorage.setItem('userId', this.user.id);
    localStorage.setItem('userName', `${this.user.firstName} ${this.user.lastName.charAt(0)}.`)
  }
}
