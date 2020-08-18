import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators, FormGroupDirective } from '@angular/forms';
import { ModelService } from '../model.service';
import { IModel } from '../interfaces/imodel';

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
    private modelService: ModelService) {
      this.isLoadingModels = true;
      this.modelLoadingError = false;
    // Get the list of models
    modelService.getModels().subscribe((data: IModel[]) => {
      this.isLoadingModels = false;
      this.models = data;
    },
      error => {
        this.isLoadingModels = false;
        this.modelLoadingError = true;
        this.message = `Error getting model data: ${error.message}`;
        console.log("Error");
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
