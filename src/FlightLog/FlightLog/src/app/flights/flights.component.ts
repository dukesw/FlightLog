import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators, FormGroupDirective } from '@angular/forms';
import { ModelService } from '../model.service';
import { IModel } from '../interfaces/imodel';
import { AuthService } from '../auth.service';

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

  constructor(private formBuilder: FormBuilder,
    private modelService: ModelService, 
    private authService: AuthService ) {
      this.isLoadingModels = true;
      this.modelLoadingError = false;
      // Get the accountId
      var accountId = this.authService.getAccountId();
      console.log(`Got Account ID ${accountId}"`);

    // Get the list of models
    modelService.getModels(accountId).subscribe((data: IModel[]) => {
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
    console.info(this.flightFilterForm.value);
  }
}
