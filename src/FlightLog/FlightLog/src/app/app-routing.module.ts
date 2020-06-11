import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightsComponent } from './flights/flights.component';
import { AddFlightComponent } from './add-flight/add-flight.component';

const routes: Routes = [
  { path: 'flights', component: FlightsComponent }, 
  { path: 'add-flight', component: AddFlightComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
