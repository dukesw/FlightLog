// import { Injectable, EventEmitter } from '@angular/core';
// //import { UserManager, UserManagerSettings, User } from 'oidc-client';
// import { HttpClient } from '@angular/common/http';
// import { BehaviorSubject } from 'rxjs';
// import { environment } from 'src/environments/environment';
// //import { EventEmitter } from 'protractor';
// import { AuthService } from '@auth0/auth0-angular';
// // In progress: moving to auth0 from identity server

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthHelperService {
//   //private webAuth = getAuthSettings();

//   private user: User;
//   userLoadedEvent: EventEmitter<User> = new EventEmitter<User>();
//   private manager = new UserManager(getClientSettings());

//   // Observable navItem source
//   private _authNavStatusSource = new BehaviorSubject<boolean>(false);
//   private _userNameChangeSource = new BehaviorSubject<string>("");

//   // Observable navItem stream
//   authNavStatus$ = this._authNavStatusSource.asObservable();
//   userNameChange$ = this._userNameChangeSource.asObservable();
  
//   constructor(private http: HttpClient) {
//     this.manager.getUser()
//       .then(user => {
//         this.user = user;
//         //this.userLoadedEvent.emit(user);
//         this._authNavStatusSource.next(this.isAuthenticated());
//         this._userNameChangeSource.next(user?.profile.name);
//       })
//       .catch((err) => {
//         this.user = null;
//       });

//       this.manager.events.addUserLoaded((user) => {
//         this.user = user;
//         if (!environment.production) {
//           console.log('authService addUserLoaded:', user);
//         }
//       });

//       this.manager.events.addUserUnloaded(() => {
//         if (!environment.production) {
//           console.log('authService user unloaded');
//         }
//       });
      
//       this.manager.events.addSilentRenewError(() => {
//         console.log('Caught a addSilentRenewError event'); 
//       });

      
//    }

//    isAuthenticated(): boolean {
//     return this.user != null && !this.user.expired;
//   }
 
//   startAuthentication(): Promise<void> {
//     // return this.manager.signinRedirect();
//     //return this.webAuth.authorize()
// return null;
//     // todo
//   }

//   getUser(): any {
//      return this.manager.getUser();
//       // .then(user => {
//       //   this.user = user;
//       //   this.userLoadedEvent.emit(user);
//       //   this._authNavStatusSource.next(this.isAuthenticated());
//       // })
//       // .catch((err) => {
//       //   this.user = null;
//       // });

//   }

//   async completeAuthentication(): Promise<void> {
//     return this.manager.signinRedirectCallback().then(user => {
//       console.log('Running: completeAuthentication');
//       this.user = user;
//       console.log(this.user);
//       this._authNavStatusSource.next(this.isAuthenticated()); 
//       this._userNameChangeSource.next(user?.profile.name);
//     });
//     // this.user = await this.manager.signinRedirectCallback();
//     // this._authNavStatusSource.next(this.isAuthenticated());      
//   }
  
//   getClaims(): any {
//     return this.user.profile;
//   }

//   getAuthourizationHeaderValue(): string {
//     if (this.user != null) {
//       return `${this.user.token_type} ${this.user.access_token}`;
//     }
//   }

//   // get authorizationHeaderValue(): string {
//   //   return `${this.user.token_type} ${this.user.access_token}`;
//   // }

//   getName(): string {
//     return this.user != null ? this.user.profile.name : '';
//   }

//   getAccountId(): number {
//     console.log("Running GetAccountID");
//    // console.log(this.user.profile.accountid);
//    if (this.user != null && this.user.profile != null) {
//     return this.user.profile.accountid;
//    }
//    else{
//      if (this.isAuthenticated()) {
//        console.log(`retrying isAuthenticated`); 
//        console.log(`Now the account is ${this.user.profile.accountid}`);
//      }
//      return 0;
//    }

//   }

//   async signout() {
//     await this.manager.signoutRedirect();
//   }
// }

// // export function getAuthSettings(): WebAuth {
// //   return new WebAuth ({ 
// //     domain: 'dev-flightlog.au.auth0.com', 
// //     clientId: 'K4yvPKBlTCzvhmVSsjPiZCEIGBGbDr8n', 
// //     redirectUri: environment.identityServerRedirectUri, 
// //   });
// // }

// export function getClientSettings(): UserManagerSettings {
//   return {
//     authority: environment.identityServerAuthority, 
//     client_id: 'flightlog-app', 
//     client_secret: 'passwordtochange',
//     redirect_uri: environment.identityServerRedirectUri, 
//     post_logout_redirect_uri: environment.identityServerPostLogoutRedirectUri,
//     response_type: "code", 
//     loadUserInfo: true,
//     scope: "openid profile email flightlog-api.read flightlog-api.write",
//     filterProtocolClaims: true,
//     automaticSilentRenew: true,
//     silent_redirect_uri: environment.silentRedirectUri
//   }
//   // This is the previous attempt
//   // return {
//   //   authority: 'https://localhost:5001', 
//   //   client_id: 'flightlog-app-client', 
//   //   //client_secret: 'appsecret',
//   //   redirect_uri: 'http://localhost:4200/auth-callback', 
//   //   post_logout_redirect_uri: 'http://localhost:4200/',
//   //   response_type: "id_token token", 
//   //   loadUserInfo: true,
//   //   //response_type: "code",
//   //   scope: "openid profile email flightlog-api",
//   //   filterProtocolClaims: true
//   // }

//   // This works using the example auth server
// //   return {
// //     authority: 'https://localhost:5001',
// //     client_id: 'angular_spa',
// //     redirect_uri: 'http://localhost:4200/auth-callback',
// //     post_logout_redirect_uri: 'http://localhost:4200/',
// //     response_type:"id_token token",
// //     scope:"openid profile email api.read",
// //     filterProtocolClaims: true,
// //     loadUserInfo: true,
// //     automaticSilentRenew: true,
// //     silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
// // };

// }
