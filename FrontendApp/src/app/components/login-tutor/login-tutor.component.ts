import { HttpErrorResponse } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginEnum } from 'src/app/enums/login.enum';
import { UserDto } from 'src/app/models/user.model';

@Component({
  selector: 'login-tutor',
  templateUrl: './login-tutor.component.html',
  styleUrls: ['./login-tutor.component.css']
})

export class LoginTutorComponent {
  constructor(private authService: AuthService, private router: Router){}

  headerText: String = 'Увійти як репетитор'; 
  user: UserDto = new UserDto();

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
    this.authService.loginTutor(this.user)
      .subscribe((userDto) => {
        this.user = userDto;
        this.SetLocalStorage()
        this.router.navigate(['tutors'])
      },
      (error: HttpErrorResponse) => {
        console.error(error)
        alert(error.error)       
      })
  }


  register(): void {
    this.authService.registerTutor(this.user)
      .subscribe((userDto) => {
        this.user = userDto;
        this.SetLocalStorage()
        this.router.navigate(['tutors'])
      },
      (error: HttpErrorResponse) => {
        console.error(error)
        alert(error.error)       
      })
  }

  SetLocalStorage(){
    localStorage.setItem('jwtToken', this.user.jwtToken);
    localStorage.setItem('userId', this.user.id);
    localStorage.setItem('userName', `${this.user.firstName} ${this.user.lastName.charAt(0)}.`)
  }

}
