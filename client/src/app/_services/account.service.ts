import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentuser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl +'account/login', model).pipe(
      map((Response: User ) =>
      {
        const user = Response
        if(user){
          localStorage.setItem("user", JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      }) 
    );
  }

  Register(model: any){
    return this.http.post(this.baseUrl + 'account/Register', model).pipe(
      map((Response: User ) => {
        const user = Response;
        if(user){
          localStorage.setItem("user", JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      }))
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout()
  {
    localStorage.removeItem("user");
    this.currentUserSource.next(null);
  }
}
