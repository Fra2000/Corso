import { Component } from '@angular/core';
import { Iuser } from '../../models/iuser';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  newUser:Partial<Iuser>={}

  constructor(private authsvc:AuthService){}

  register(){
    this.authsvc.register(this.newUser).subscribe()
  }

}
