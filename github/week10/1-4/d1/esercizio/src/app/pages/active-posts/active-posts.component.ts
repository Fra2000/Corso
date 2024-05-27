import { Component } from '@angular/core';
import { iPost } from '../../Models/ipost';
import { IJsonContent } from '../../Models/i-json-content';

@Component({
  selector: 'app-active-posts',
  templateUrl: './active-posts.component.html',
  styleUrl: './active-posts.component.scss'
})
export class ActivePostsComponent {

  postsArr:iPost[] = [];

  ngOnInit(){

    this.getActivePosts()//lancio la chiamata e popolo l'array postsArr

  }

  async getActivePosts(){

    const res = await fetch('../../../assets/db.json')
    const jsonContent = <IJsonContent> await res.json()

    const postFiltrati = jsonContent.posts.filter(p => p.active)

    this.postsArr = postFiltrati
  }

}
