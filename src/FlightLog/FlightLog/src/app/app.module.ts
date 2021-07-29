import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select'
import { HttpClientModule } from '@angular/common/http'
import { MatButtonModule } from '@angular/material/button';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlightsComponent } from './flights/flights.component';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightEditorComponent } from './flight-editor/flight-editor.component';
import { LoginComponent } from './login/login.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthGuard } from './auth-guard';
import { HeaderComponent } from './header/header.component';
import { TokenInterceptor } from './token.interceptor';
import { ErrorsHandler } from './errors-handler';
import { NotificationService } from './notification.service';
//import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MAT_DATE_LOCALE } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    AddFlightComponent,
    FlightEditorComponent,
    LoginComponent,
    AuthCallbackComponent,
    HeaderComponent
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
    MatSelectModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
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
