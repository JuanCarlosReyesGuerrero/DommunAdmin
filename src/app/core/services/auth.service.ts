import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { DommunConstants } from "src/app/common/constants.class";
import { getFirebaseBackend } from "../../authUtils";
import { ApiTokenModel } from "../models/api-token.models";
import { User } from "../models/auth.models";

const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json' })};

@Injectable({ providedIn: "root" })

/**
 * Auth-service Component
 */
export class AuthenticationService {
  user!: User;
  currentUserValue: any;

  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public currentUserSubject: BehaviorSubject<string>;

  get isLoggedIn() {
    console.log(this.loggedIn);
    return this.loggedIn.asObservable();
  }

  constructor(
    private http: HttpClient, 
    private router: Router
    ) {
    this.currentUserSubject = new BehaviorSubject<string>(localStorage.getItem('session') || "")
    //this.currentUser = this.currentUserSubject.asObservable();
  }
  
  /**
   * Performs the register
   * @param email email
   * @param password password
   */
  register(email: string, password: string) {
    return getFirebaseBackend()!
      .registerUser(email, password)
      .then((response: any) => {
        const user = response;
        return user;
      });
  }

  /**
   * Performs the auth
   * @param email email of user
   * @param password password of user
   */
  /*
    login(email: string, password: string) {
        return getFirebaseBackend()!.loginUser(email, password).then((response: any) => {
            const user = response;
            return user;
        });
    }
*/
  /**
   * Returns the current user
   */
  public currentUser(): any {
    return getFirebaseBackend()!.getAuthenticatedUser();
  }

  /**
   * Logout the user
   */
  logout() {
    // logout the user
    return getFirebaseBackend()!.logout();
  }

  /**
   * Reset password
   * @param email email
   */
  resetPassword(email: string) {
    return getFirebaseBackend()!
      .forgetPassword(email)
      .then((response: any) => {
        const message = response.data;
        return message;
      });
  }

  login(sesion: any) {
    if (sesion) {
      this.loggedIn.next(true);
      this.router.navigate(["/"]);
    } else {
      sessionStorage.clear();
    }
  }

  getToken() {
    const keyModel = new ApiTokenModel();
    keyModel.key = DommunConstants.TokenHash.key;
    keyModel.apiKey = DommunConstants.TokenHash.apiKey;
    return this.http.post<any>(
      DommunConstants.pathApi.vGetToken,
      keyModel,
      httpOptions
    );
  }
}
