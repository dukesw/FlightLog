import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightFindComponent } from './flight-find/flight-find.component';
//import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightEditorComponent } from './flight-editor/flight-editor.component';
import { LoginComponent } from './login/login.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { AuthGuard } from './auth-guard';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  // { path: 'flights', component: FlightsComponent, canActivate: [!AuthGuard] },
  // { path: 'add-flight', component: AddFlightComponent, canActivate: [!AuthGuard] },
  { path: '', component : HomeComponent },
  { path: 'flights', component: FlightFindComponent },
  { path: 'add-flight', component: FlightEditorComponent},
  { path: 'edit-flight/:id', component: FlightEditorComponent },
  { path: 'login', component: LoginComponent },
  { path: 'auth-callback', component: AuthCallbackComponent },
  // Fallback when no prior route is matched
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
