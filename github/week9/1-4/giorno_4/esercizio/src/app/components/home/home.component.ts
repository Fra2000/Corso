import { Component } from '@angular/core';
import { Posts } from '../../models/posts';
import { Jsonc } from '../../models/json';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
postArr:Posts[]=[]
firstpost!:Posts

ngOnInit(){
this.getPosts().then(()=>{
let firstpost=this.getfirstpost()

if(firstpost) this.firstpost=firstpost
})
}
async getPosts(){
  const response=await fetch("../../../assets/db.json")
  const thepost=<Jsonc> await response.json()
  this.postArr=thepost.posts

}

getfirstpost(){
  return this.postArr.shift()
}



}
