import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  @Input()
  isAuthenticated: boolean; 
  subscription: Subscription;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.authNavStatus$.subscribe(status => { 
      this.isAuthenticated = status;
    });
  }

}
