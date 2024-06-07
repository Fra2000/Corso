import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { Iuser } from '../models/iuser';
import { HttpClient } from '@angular/common/http';
import { Route, Router } from '@angular/router';
import { Iauthdata } from '../models/iauthdata';
import { Iaccessresponse } from '../models/iaccessresponse';
import { Imovie } from '../models/imovie';
import { Ifavourite } from '../models/favourite';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper:JwtHelperService= new JwtHelperService()

  authSubject= new BehaviorSubject<null|Iuser>(null)

  syncIsloggedin:boolean=false

  user$= this.authSubject.asObservable()

  apiUrl:string='http://localhost:3000/movies'
  apiUrlFav:string='http://localhost:3000/favourite'

  isLoggedIn$=this.user$.pipe(map(user=>!!user),
  tap(user=>this.syncIsloggedin=user)
)

  constructor(
    private http:HttpClient,
    private router:Router
  ) {this.restoreUser()}

  loginUrl:string= 'http://localhost:3000/login'
  registerUrl:string= 'http://localhost:3000/register'

  register(newUser:Partial<Iuser>):Observable<Iaccessresponse>{
   return this.http.post<Iaccessresponse>(this.registerUrl,newUser)
  }

  login(authdata:Iauthdata){
    return this.http.post<Iaccessresponse>(this.loginUrl,authdata)
    .pipe(tap(data=>{
      this.authSubject.next(data.user)
      localStorage.setItem('accessData',JSON.stringify(data))

      this.autoLogout()
    }))}

  logout(){
    this.authSubject.next(null)
    localStorage.removeItem('accessData')
    this.router.navigate(['/auth/login'])
  }

  autoLogout(){

    const accessData=this.getAccessData()
    if(!accessData) return
    const expDate=this.jwtHelper.getTokenExpirationDate(accessData.accessToken) as Date
    const expMs=expDate.getTime()-new Date().getTime()
    setTimeout(this.logout,expMs)

  }

  getAccessData():Iaccessresponse|null{

    const accessDataJson= localStorage.getItem('accessData')
    if(!accessDataJson) return null
    const accessData:Iaccessresponse=JSON.parse(accessDataJson)


   return accessData

  }

  restoreUser(){

    const accessToken= this.getAccessData()
    if(!accessToken) return
    if(this.jwtHelper.isTokenExpired(accessToken.accessToken)) return
    this.authSubject.next(accessToken.user)
    this.autoLogout()


  }

  getAll(){
    return this.http.get<Imovie[]>(this.apiUrl)
  }

  getById(id:number){
    return this.http.get<Imovie>(`${this.apiUrl}/${id}`)
  }

  create(newMovie:Partial<Imovie>){
    return this.http.post<Imovie>(this.apiUrl, newMovie)
  }

  delete(id:number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }


  getAllFav(){
    return this.http.get<Ifavourite[]>(this.apiUrl)
  }

  getByIdFav(id:number){
    return this.http.get<Ifavourite>(`${this.apiUrl}/${id}`)
  }

  getFavouriteByUserId(userId:number){
    return this.http.get<Ifavourite[]>(`${this.apiUrl}?userId=${userId}`)
  }

  createFav(newFav:Partial<Ifavourite>){
    return this.http.post<Ifavourite>(this.apiUrlFav, newFav)
  }

  deleteFav(id:number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }

}
