import { Component, OnInit, Input, OnDestroy, Inject } from '@angular/core';
import { Subscription } from 'rxjs';

//import { AuthService } from '../auth.service';
import { AuthService } from '@auth0/auth0-angular';

// import { MDCTopAppBar } from '@material/top-app-bar';
import {MDCMenu} from '@material/menu';
//import { AuthButtonComponent } from '../auth-button/auth-button.component';
import { DOCUMENT } from '@angular/common';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  @Input()
  title: string;
  name: string; 
  // isAuthenticated: boolean; 
  // subscription: Subscription;
  // userLoadedSubscription: Subscription;



  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService) {
    // const topAppBarElement = document.querySelector('.mdc-top-app-bar');
    // const topAppBar = new MDCTopAppBar(topAppBarElement);
   }

  ngOnInit(): void {
    // this.subscription = this.authService.user$.subscribe(status => { 
    //   this.isAuthenticated = status.;
    // }); 
    // console.log('Called header...init()');
    // console.log(this.authService);
    // // //this.name = this.authService.getClaims();
    // // console.log(this.authService.getUser());
    // // console.log(this.authService.authorizationHeaderValue);

    // this.userLoadedSubscription = this.authService.userNameChange$.subscribe(userName => {
    //     console.log('header - userName loaded');
    //     this.name = userName;
    //     });
  }



  ngOnDestroy(): void {
    // this.subscription.unsubscribe(); 
    // this.userLoadedSubscription.unsubscribe();
  }
  
}
