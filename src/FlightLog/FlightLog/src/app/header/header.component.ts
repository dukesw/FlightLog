import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  @Input()
  title: string;
  name: string; 
  isAuthenticated: boolean; 
  subscription: Subscription;
  userLoadedSubscription: Subscription;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$.subscribe(status => { 
      this.isAuthenticated = status;
    }); 
    console.log('Called header...init()');
    console.log(this.authService);
    // //this.name = this.authService.getClaims();
    // console.log(this.authService.getUser());
    // console.log(this.authService.authorizationHeaderValue);

    this.userLoadedSubscription = this.authService.userNameChange$.subscribe(userName => {
        console.log('header - userName loaded');
        this.name = userName;
        });
  }

  login() {
    this.authService.startAuthentication();
  }
  
  async logout() {
    await this.authService.signout();     
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe(); 
    this.userLoadedSubscription.unsubscribe();
  }
  
}
