import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: User | null;
  private manager = new UserManager(getClientSettings());

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();
  
  constructor(private http: HttpClient) {
    this.manager.getUser().then(user => {
      this.user = user;
      this._authNavStatusSource.next(this.isAuthenticated());
    });
   }

   isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }
 
  login() {
    return this.manager.signinRedirect();
  }

  async completeAuthentication() {
    this.user = await this.manager.signinRedirectCallback();
    this._authNavStatusSource.next(this.isAuthenticated());      
  }
  
  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get name(): string {
    return this.user != null ? this.user.profile.givenName : '';
  }

  async signout() {
    await this.manager.signoutRedirect();
  }

}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'https://localhost:5001', 
    client_id: 'flightlog-app-client', 
    //client_secret: 'appsecret',
    redirect_uri: 'http://localhost:4200/auth-callback', 
    post_logout_redirect_uri: 'http://localhost:4200/',
    response_type: "id_token token", 
    loadUserInfo: true,
    //response_type: "code",
    scope: "openid profile email flightlog-api",
    filterProtocolClaims: true
  }

  // This works using the example auth server
//   return {
//     authority: 'https://localhost:5001',
//     client_id: 'angular_spa',
//     redirect_uri: 'http://localhost:4200/auth-callback',
//     post_logout_redirect_uri: 'http://localhost:4200/',
//     response_type:"id_token token",
//     scope:"openid profile email api.read",
//     filterProtocolClaims: true,
//     loadUserInfo: true,
//     automaticSilentRenew: true,
//     silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
// };

}