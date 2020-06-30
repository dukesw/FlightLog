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

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$.subscribe(status => this.isAuthenticated = status); 
    this.name = this.authService.name;
  }

  login() {
    this.authService.login();
  }
  
  async logout() {
    await this.authService.signout();     
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe(); 
  }
  
}
