import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { Iuser } from '../../models/iuser';
import { Imovie } from '../../models/imovie';
import { Ifavourite } from '../../models/favourite';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  user!:Iuser
  movie:Imovie[]=[]
  favourite:Ifavourite[]=[]

  constructor(
    private authsvc:AuthService
  ){}

  ngOnInit(){
    this.authsvc.user$.subscribe(user=>{
      if(user) this.user=user
    })

    this.authsvc.getAll().subscribe(movie=>{
      this.movie=movie

      this.authsvc.getAllFav().subscribe(favourite=>{
        this.favourite=favourite

      })
    })

  }

}
