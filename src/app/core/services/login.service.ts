import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DommunConstants } from "src/app/common/constants.class";
import { LoginModel } from "../models/login-model.class";

const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json' })};

@Injectable({
    providedIn: 'root'
  })
export class LoginService {

    emailBackOffice:string = '';
    passwordBackOffice:string = '';

    constructor(private http: HttpClient) { }
    
    LogIn(login: LoginModel){
        return this.http.post<any>(DommunConstants.pathApi.vLogIn, login);
      }
}