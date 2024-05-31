import { Component } from '@angular/core';
import { UsersService } from '../../users.service';
import { TodosService } from '../../todos.service';
import { iTodos } from '../../models/i-todos';
import { iUsers } from '../../models/i-users';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  todosArr:iTodos[]=[];
  UsersArr:iUsers[]=[];

  constructor(private UsersService:UsersService, private todosService:TodosService) {}

  insieme(){
    return this.todosArr.map(i=>{
      const stessoid=this.UsersArr.find(a=>a.id===i.userId)
      if (stessoid){i.author=stessoid}
      return i
    })
  }

    ngOnInit(){
      this.todosArr=this.todosService.getTodos()
      this.UsersArr=this.UsersService.getUsers()
      this.insieme()
      console.log(this.insieme())


    }

}

