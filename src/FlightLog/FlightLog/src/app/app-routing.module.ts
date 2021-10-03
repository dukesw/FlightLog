import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightFindComponent } from './flight-find/flight-find.component';
//import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightEditorComponent } from './flight-editor/flight-editor.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component'; 

import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  // { path: 'flights', component: FlightsComponent, canActivate: [!AuthGuard] },
  // { path: 'add-flight', component: AddFlightComponent, canActivate: [!AuthGuard] },
  { path: '', component : HomeComponent },
  { path: 'flights', component: FlightFindComponent, canActivate: [AuthGuard] },
  { path: 'add-flight', component: FlightEditorComponent, canActivate: [AuthGuard]},
  { path: 'edit-flight/:id', component: FlightEditorComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  // Fallback when no prior route is matched
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
