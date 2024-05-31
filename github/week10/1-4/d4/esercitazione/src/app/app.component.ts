import { PhotoService } from './photo.service';
import { Iphoto } from './Models/iphoto';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  Photos:Iphoto[]=[]

  constructor(private PhotoService:PhotoService){}

  ngOninit(){

  this.PhotoService.getAll().subscribe(Photos=>{
    this.Photos=Photos
  })

  }
}
