import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators, FormGroupDirective } from '@angular/forms';
import { ModelService } from '../model.service';
import { IModel } from '../interfaces/imodel';
import { FlightService } from '../flight.service';
import { IFlightSummary } from '../interfaces/iflight-summary';
import { IFlight } from '../interfaces/iflight';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { formatDate } from '@angular/common';
import { AuthService } from '@auth0/auth0-angular';

//import * as _moment from 'moment';

// import { default as _rollupMoment} from 'moment';

//const moment = _moment;

//const moment = require('moment');

@Component({
  selector: 'app-flights',
  templateUrl: './flight-find.component.html',
  styleUrls: ['./flight-find.component.css']
})
export class FlightFindComponent implements OnInit {

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
    private auth: AuthService ) {
      this.isLoadingModels = true;
      this.modelLoadingError = false;
      // Get the accountId

      // TODO get the correct user and account id from the Auth0 user$

      this.accountId = 1;//this.auth.getAccountId();
      console.log(`Got Account ID ${this.accountId}`);

    // Get the list of models
      // If both dates are provided, include them
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
    dateFrom: [], 
    dateTo: [], 
    modelId: ['', Validators.required]
  });

  onSubmit(FormGroupDirective): void {
    // TODO check the date and include if specified. 
    console.log(`Start Date: ${this.flightFilterForm.value.dateFrom}`);
    console.log(`End Date: ${this.flightFilterForm.value.dateTo}`);
    var dateFrom = this.flightFilterForm.value.dateFrom;
    var dateTo = this.flightFilterForm.value.dateTo; 

    // If only a from date is specified, search from the start to current date. 
    // If only a to date is specified, search all until the to date
    if (dateFrom == null && dateTo != null) { 
      dateFrom = new Date(0)
    } else if (dateTo == null && dateFrom != null) {
      dateTo = new Date();
    }

    console.log(`Calculated From Date: ${dateFrom}`);
    console.log(`Calculated To Date: ${dateTo}`);

    // TODO Add some more date validation here... to allow only one to be specified
    if (dateFrom != null && dateTo != null) {
      this.flightService.getFlightSummaryByModelAndDateRange(this.accountId, this.flightFilterForm.value.modelId, this.formatDateForUri(dateFrom), this.formatDateForUri(dateTo)).subscribe((data: IFlightSummary) => {
        this.flightSummary = data;
      },
        error => {
          console.log(`Error getting flight summary: ${error.message}`);
        });
      this.flightService.getFlightsbyModelAndDateRange(this.accountId, this.flightFilterForm.value.modelId, this.formatDateForUri(dateFrom), this.formatDateForUri(dateTo)).subscribe((data: IFlight[]) => {
        this.flights = data;
        console.log(this.flights);
      },
        error => {
          console.log(`Error getting flights: ${error.message}`);
        });
    } else {

      this.flightService.getFlightSummaryByModel(this.accountId, this.flightFilterForm.value.modelId).subscribe((data: IFlightSummary) => {
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
    }
    console.info(this.flightFilterForm.value);
  }

  resetForm() {
    this.flightSummary = null;
    this.flights = null;
    // this.flightFilterForm.reset();
    // this.flightFilterForm.clearValidators();
  }

  // Formats a date so that it can be passed to a REST service unambiguously
  formatDateForUri(date: Date): string {
    var d = new Date(date);
    var month = '' + (d.getMonth() + 1);
    var day = '' + d.getDate(); 
    var year = '' + d.getFullYear();
    if (month.length < 2) {
      month = '0' + month;
    }
    if (day.length < 2) {
      day = '0' + day;
    }
    return `${year}-${month}-${day}`;
  }
}
