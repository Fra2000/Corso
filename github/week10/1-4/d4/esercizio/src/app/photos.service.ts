import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { iPhotos } from './models/iphotos';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {

  apiUrl:string='https://jsonplaceholder.typicode.com/photos'

  constructor(private http:HttpClient) { }

getAllPhotos(){
  return this.http.get<iPhotos[]>(this.apiUrl)
  .pipe(catchError(error=>throwError(()=>new Error('errore'))))
}

delete(id:number)
{return this.http.delete<iPhotos>(`${this.apiUrl}/${id}`)
.pipe(catchError(error=>throwError(()=>new Error('errore'))))
}

}
