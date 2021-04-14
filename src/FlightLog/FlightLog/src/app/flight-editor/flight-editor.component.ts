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
import { AuthService } from '../auth.service';
import { ActivatedRoute } from '@angular/router';
//import * as dayjs from 'dayjs'
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

export const DATE_FORMATS = {
  parse: {
    dateInput: 'LL',
  },
  display: {
    dateInput: 'LL',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-flight-editor',
  templateUrl: './flight-editor.component.html',
  styleUrls: ['./flight-editor.component.css'],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: DATE_FORMATS },
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } }  // Does not seem to make any difference...
  ]
})
export class FlightEditorComponent implements OnInit {

  isLoadingModels: boolean;
  modelLoadingError: boolean;
  isLoadingLocations: boolean;
  locationLoadingError: boolean;
  isLoadingPilots: boolean;
  pilotLoadingError: boolean;
  flightId: number;

  constructor(
      private formBuilder: FormBuilder, 
      private modelService: ModelService, 
      private flightService: FlightService, 
      private locationService: LocationService, 
      private pilotService: PilotService, 
      private notificationService: NotificationService,
      private authService: AuthService, 
      private route: ActivatedRoute) {
    
        this.isLoadingModels = true;
        this.modelLoadingError = false;
        this.isLoadingLocations = true;
        this.locationLoadingError = false;
        this.isLoadingPilots = true;
        this.pilotLoadingError = false;

    this.accountId = this.authService.getAccountId();

    this.flightId = Number(this.route.snapshot.paramMap.get('id'));
    console.log(`FlightID: ${this.flightId}`);
        // Get the list of models
    modelService.getModels(this.accountId).subscribe((data: IModel[]) => {
      this.isLoadingModels = false;
      this.models = data;
    },
    error => {
      this.isLoadingModels = false;
      this.modelLoadingError = true;
      this.flightForm.setErrors({"modelId": error});
      this.flightForm.markAllAsTouched(); // So that the mat-error shows without needing any input.
      this.message = `Error getting model data: ${error.message}`;
    });
    

    // Location
    locationService.getLocations(this.accountId).subscribe((data: ILocation[]) => {
      this.isLoadingLocations = false;
      this.locations = data;
    },
    error => {
      this.isLoadingLocations = false;
      this.locationLoadingError = true;
      this.flightForm.setErrors({"locationId": error});
      this.flightForm.markAllAsTouched();
      this.message = `Error getting location data: ${error.message}`;
    });

    // Pilot
    pilotService.getPilots(this.accountId).subscribe((data: IPilot[]) => {
      this.isLoadingPilots = false;
      this.pilots = data;
    }, 
    error => {
        this.isLoadingPilots = false;
        this.pilotLoadingError = true;
        this.flightForm.setErrors({"pilotId": error});
        this.flightForm.markAllAsTouched();
        this.message = `Error getting pilot data: ${error.message}`;
      });

      if (!isNaN(this.flightId) && this.flightId > 0) {
        console.log(`Getting flight id ${this.flightId}`);
        flightService.getFlight(this.accountId, this.flightId).subscribe((data: IFlight) => {
          this.flight = data;
          console.log(`Loaded model with date: ${this.flight.Date}`);
          var localDate = `${this.flight.Date}Z`;
          console.log(localDate); 
          // Fix the date before patching the form
          
          this.flightForm.patchValue({
            //date: this.flight.Date,
            date: localDate,
            flightMinutes: this.flight.FlightMinutes, 
            modelId: this.flight.ModelId,
            locationId: this.flight.FieldId, 
            pilotId: this.flight.PilotId,
            details: this.flight.Details
          });
          this.flightForm.markAsUntouched();
          console.log(this.flight);
        }, 
        error => {
          this.message = `Error loading flight`;
        
        });
      }
    }

  ngOnInit(): void {
  }

  flight: IFlight = new Flight();
  savedFlight: IFlight;
  message: string;
  accountId: number = 0;

  models: IModel[];
  selectedModel: IModel;

  locations: ILocation[]; 
  selectedLocation: ILocation;

  pilots: IPilot[];
  selectedPilot: IPilot;

  flightForm = this.formBuilder.group({
    date: [moment(), Validators.required],
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
    this.flight.AccountId = this.accountId;

    this.flightService.addOrUpdateFlight(this.accountId, this.flight)
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
    this.flightForm.patchValue({ date: moment() });
  }

}