import { Component } from '@angular/core';
import { IJsonContent } from '../../Models/i-json-content';
import { iPost } from '../../Models/ipost';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.scss'
})
export class DetailComponent {

  currentPost!:iPost


  constructor(
    private route:ActivatedRoute
  ){}

  ngOnInit(){

    //grazie a route ottengo un oggetto params, contenente l'id del post da renderizzare
    this.route.params.subscribe((params:any) => {

      this.getActivePosts(params.id)//lancio la chiamata e popolo l'array postsArr

    })
  }

  //questo metodo si aspetta di ricevere l'id di un post
  //che userà per cercare il post copn quello specifico id
  async getActivePosts(id:number){

    const res = await fetch('../../../assets/db.json')
    const jsonContent = <IJsonContent> await res.json()


    //filtro la lista di post cercando quello che ha l'id ricercato
    const postTrovato = jsonContent.posts.find(p => p.id == id)

    //dopo aver controllato se l'elemento esiste, lo salvo nella prop currentPost
    if(postTrovato) this.currentPost = postTrovato

  }

}
