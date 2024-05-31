import { Component } from '@angular/core';
import { iUsers } from '../../models/i-users';
import { iTodos } from '../../models/i-todos';
import { TodosService } from '../../todos.service';
import { UsersService } from '../../users.service';

@Component({
  selector: 'app-completed',
  templateUrl: './completed.component.html',
  styleUrl: './completed.component.scss'
})
export class CompletedComponent {
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
