import { Component, OnInit, Input } from '@angular/core';
import { Subscription } from 'rxjs';

import { AuthService } from '@auth0/auth0-angular';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  @Input()
  isAuthenticated: boolean; 
  subscription: Subscription;

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.auth.isAuthenticated$.subscribe(status => { 
      this.isAuthenticated = status;
      console.log(`Home.ngOnInit: this.isAuthenticated == ${this.isAuthenticated}`)
    });
  }

}
