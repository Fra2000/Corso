import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Iphoto } from './Models/iphoto';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  apiUrl:string='https:jsonplaceholder.typicode.com/photos'

  constructor(private http:HttpClient) { }

getAll(){

return this.http.get<Iphoto[]>(this.apiUrl)
.pipe(catchError(error=>throwError(()=>new Error('errore'))))

}

delete(id:number){
  return this.http.delete(`${this.apiUrl}/${id}`)
  .pipe(catchError(error=>throwError(()=>new Error('errore'))))
}

}
