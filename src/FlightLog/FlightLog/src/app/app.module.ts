import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlightFindComponent } from './flight-find/flight-find.component';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightEditorComponent } from './flight-editor/flight-editor.component';
import { HeaderComponent } from './header/header.component';
import { ErrorsHandler } from './errors-handler';
import { NotificationService } from './notification.service';
//import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HomeComponent } from './home/home.component';

import { AuthModule } from '@auth0/auth0-angular';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';
import { AuthButtonComponent } from './auth-button/auth-button.component';
import { ProfileComponent } from './profile/profile.component';
import { environment as env } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    FlightFindComponent,
    AddFlightComponent,
    FlightEditorComponent,
    HeaderComponent,
    HomeComponent,
    AuthButtonComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, 
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatDatepickerModule, 
    MatNativeDateModule,
    //MatMomentDateModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatSelectModule, 
    AuthModule.forRoot({
      domain: env.auth0Domain,// 'dev-flightlog.au.auth0.com',
      clientId: env.auth0ClientId, //'K4yvPKBlTCzvhmVSsjPiZCEIGBGbDr8n', 
      redirectUri: env.auth0RedirectUri, 
      audience: 'https://dev-flightlog-api.flightlog.co.nz', 
      //scope: 'flightlog-api.admin flightlog-api.read flightlog-api.admin flightlog-api.write',
      httpInterceptor: {
        allowedList: [
          {
            uri: 'https://localhost:5002/api/*',
            tokenOptions: {
              audience: 'https://dev-flightlog-api.flightlog.co.nz', 
            //  scope: 'flightlog-api.admin flightlog-api.read flightlog-api.admin flightlog-api.write'
            }
          }, 
          {
            uri: 'https://flightlogapi.azurewebsites.net/api/*',
            tokenOptions: {
              audience: 'https://dev-flightlog-api.flightlog.co.nz', 
            //  scope: 'flightlog-api.admin flightlog-api.read flightlog-api.admin flightlog-api.write'
            }
          }
        ]
      }

    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true
    }, 
    {
      provide: ErrorHandler, 
      useClass: ErrorsHandler
    },
    // Does not currently include a moment date adapter
    // { 
    //   provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, 
    //   useValue: { useUtc: true } 
    // }, 
    {
        provide: MAT_DATE_LOCALE, 
        useValue: 'en-NZ'
    },

    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
