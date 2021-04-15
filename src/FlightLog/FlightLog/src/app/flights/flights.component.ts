import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators, FormGroupDirective } from '@angular/forms';
import { ModelService } from '../model.service';
import { IModel } from '../interfaces/imodel';
import { AuthService } from '../auth.service';
import { FlightService } from '../flight.service';
import { IFlightSummary } from '../interfaces/iflight-summary';
import { IFlight } from '../interfaces/iflight';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';


//import * as _moment from 'moment';

// import { default as _rollupMoment} from 'moment';

//const moment = _moment;

//const moment = require('moment');

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {

  models: IModel[];
  selectedModel: IModel;
  message: string;
  isLoadingModels: boolean;
  modelLoadingError: boolean;
  accountId: number;
  flightSummary: IFlightSummary;
  flights: IFlight[];

  constructor(private formBuilder: FormBuilder,
    private modelService: ModelService, 
    private flightService: FlightService,
    private authService: AuthService ) {
      this.isLoadingModels = true;
      this.modelLoadingError = false;
      // Get the accountId

      this.accountId = this.authService.getAccountId();
      console.log(`Got Account ID ${this.accountId}`);

    // Get the list of models
    modelService.getModels(this.accountId).subscribe((data: IModel[]) => {
      this.isLoadingModels = false;
      this.models = data;
    },
      error => {
        this.isLoadingModels = false;
        this.modelLoadingError = true;
        this.flightFilterForm.setErrors({'modelId': error});
        this.flightFilterForm.markAllAsTouched(); // So that the mat-error shows without needing any input.
        // this.message = `Error getting model data: ${error.message}`;  // Debugging only
        console.log(`Error getting model data: ${error.message}`);
      });
  }

  ngOnInit(): void {
  }

  flightFilterForm = this.formBuilder.group({
    dateFrom: [new Date()], 
    dateTo: [new Date()], 
    modelId: ['', Validators.required]
  });

  onSubmit(FormGroupDirective): void {
    this.flightService.getFlightSummary(this.accountId, this.flightFilterForm.value.modelId).subscribe((data: IFlightSummary) => {
      this.flightSummary = data;
    }, 
    error => {
      console.log(`Error getting flight summary: ${error.message}`);
    });

    this.flightService.getFlightsByModel(this.accountId, this.flightFilterForm.value.modelId).subscribe((data: IFlight[]) => {
      this.flights = data;
      console.log(this.flights);
    }, 
    error => {
      console.log(`Error getting flights: ${error.message}`);
    });

    console.info(this.flightFilterForm.value);
  }

  resetForm() {
    this.flightSummary = null;
    // this.flightFilterForm.reset();
    // this.flightFilterForm.clearValidators();
  }
}
