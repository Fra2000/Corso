import { Component } from '@angular/core';
import { Icar } from '../../models/icar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  randomCars:Icar[]=[]
  carArr:Icar[]=[]

  ngOnInit(){

this.getCars()

  }

  async getCars():Promise<void>{
let response=await fetch('../../../assets/db.json')
let cars=<Icar[]>await response.json()
this.carArr=cars
this.randomCars=this.getRandomCars()
console.log(this.randomCars)
  }

  getRandomCars(): Icar[] {
    const shuffled=[...this.carArr].sort(()=>0.5 - Math.random())
    return shuffled.slice(0,2)
  }
}
