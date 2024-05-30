import { Component } from '@angular/core';
import { iPhotos } from '../../models/iphotos';
import { PhotosService } from '../../photos.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

AllPhotos:iPhotos[]=[]

constructor(private getPhotos:PhotosService){}

ngOninit(){

this.getPhotos.getAllPhotos().subscribe(AllPhotos=>{
  this.AllPhotos=AllPhotos
})

}

}
