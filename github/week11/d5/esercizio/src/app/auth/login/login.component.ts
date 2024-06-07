import { Component } from '@angular/core';
import { Iauthdata } from '../../models/iauthdata';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  authData:Iauthdata={
    email:'',
    password:''
  }

  constructor(
    private authsvc:AuthService,
    private router:Router
  ){}

  login(){
    this.authsvc.login(this.authData)
    .subscribe(()=>{
      this.router.navigate(['/dashboard'])
    })
  }

}
