import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators, FormGroupDirective } from '@angular/forms';
import { ModelService } from '../model.service';
import { LocationService } from '../location.service';
import { IModel } from '../interfaces/imodel';
import { FlightService } from '../flight.service';
import { IFlight } from '../interfaces/iflight';
import { Flight } from '../models/flight';
import { ILocation } from '../interfaces/ilocation';
import { IPilot } from '../interfaces/ipilot';
import { PilotService } from '../pilot.service';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../notification.service';


@Component({
  selector: 'app-flight-editor',
  templateUrl: './flight-editor.component.html',
  styleUrls: ['./flight-editor.component.css']
})
export class FlightEditorComponent implements OnInit {

  constructor(
      private formBuilder: FormBuilder, 
      private modelService: ModelService, 
      private flightService: FlightService, 
      private locationService: LocationService, 
      private pilotService: PilotService, 
      private notificationService: NotificationService) {
    
        // Get the list of models
    modelService.getModels().subscribe((data: IModel[]) => {
      this.models = data;
    }, 
    error => {
      this.message = `Error getting model data: ${error.message}`;
    });
    

    // Location
    locationService.getLocations().subscribe((data: ILocation[]) => {
      this.locations = data;
    })

    // Pilot
    pilotService.getPilots().subscribe((data: IPilot[]) => {
      this.pilots = data;
    });
  }

  ngOnInit(): void {
  }

  flight: IFlight = new Flight();
  savedFlight: IFlight;
  message: string;

  models: IModel[];
  selectedModel: IModel;

  locations: ILocation[]; 
  selectedLocation: ILocation;

  pilots: IPilot[];
  selectedPilot: IPilot;

  flightForm = this.formBuilder.group({
    date: [new Date(), Validators.required],
    flightMinutes: ['', Validators.required],
    modelId: ['', Validators.required],
    locationId: ['', Validators.required],
    pilotId: ['', Validators.required],
    details: ['']
  });

  onSubmit(formDirective: FormGroupDirective): void {
    console.warn(this.flightForm.value)

    this.flight.Date = this.flightForm.value.date;
    this.flight.ModelId = this.flightForm.value.modelId;
    this.flight.FlightMinutes = this.flightForm.value.flightMinutes;
    this.flight.Details = this.flightForm.value.details;
    this.flight.FieldId = this.flightForm.value.locationId;
    this.flight.PilotId = this.flightForm.value.pilotId;

    this.flightService.addFlight(this.flight)
    // .pipe(
    //   catchError(err => of([]))
    // )
    .subscribe(
      (data: IFlight) => {  
        if (data instanceof HttpErrorResponse) {
          this.message = "Not able to save. Try again later"
          return;
        } 
        this.savedFlight = data;
        console.log(this.savedFlight);
        this.message = `Saved flight with Id ${this.savedFlight.Id}.`;
        this.notificationService.notify(`Saved flight with Id ${this.savedFlight.Id}.`);
        this.clearForm(formDirective);
        
      }, 
      error => {
        if (error instanceof HttpErrorResponse) {
          console.log('Caught an HttpErrorResponse');
          if (error.status === 401) 
          {
            this.message = 'User not authenticated';
          }
          if (error.status === 403) 
          {
            this.message = 'User not authorised to save flights';
          }
        } 
        else {
          this.message = `Error: ${error.message}`;
        }
      });
  }

  // TODO Next. Better error handling - use the HeroApp components as an example with messages passed about...

  
  clearForm(formDirective: FormGroupDirective) {
    this.flightForm.reset();
    formDirective.resetForm();
    this.flightForm.patchValue({ date: new Date() });
  }

}