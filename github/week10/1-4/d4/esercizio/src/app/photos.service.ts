import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iPhotos } from './models/iphotos';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {

  apiUrl:string='https://jsonplaceholder.typicode.com/photos'

  constructor(private http:HttpClient) { }

getAllPhotos():Observable<iPhotos[]>{
  return this.http.get<iPhotos[]>(this.apiUrl)
}
}
