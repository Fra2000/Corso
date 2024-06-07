import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  isLoggedin:boolean=false
  constructor(private authsvc:AuthService){}

  ngOnInit(){
    this.authsvc.isLoggedIn$.subscribe(isLoggedin=>this.isLoggedin=isLoggedin)

    }

    logout(){
      this.authsvc.logout()
    }


}
