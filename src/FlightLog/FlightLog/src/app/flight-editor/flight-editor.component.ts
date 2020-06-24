import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form } from '@angular/forms';
import { ModelService } from '../model.service';
import { IModel } from '../interfaces/imodel';
import { FlightService } from '../flight.service';
import { IFlight } from '../interfaces/iflight';
import { Flight } from '../models/flight';


@Component({
  selector: 'app-flight-editor',
  templateUrl: './flight-editor.component.html',
  styleUrls: ['./flight-editor.component.css']
})
export class FlightEditorComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private modelService: ModelService, private flightService: FlightService) {
    // Get the list of models
    modelService.getModels().subscribe((data: IModel[]) => {
      this.models = data;
    });
    console.log(this.models);
  }

  ngOnInit(): void {
  }

  // TODO set up a class that implements flight (type=model) 
  flight: IFlight = new Flight();
  savedFlight: IFlight;
  message: string;

  flightForm = this.formBuilder.group({
    date: [new Date()],
    flightMinutes: [''],
    modelId: [''],
    details: ['']
  });

  onSubmit() {
    console.warn(this.flightForm.value)

    this.flight.Date = this.flightForm.value.date;
    this.flight.ModelId = this.flightForm.value.modelId;
    this.flight.FlightMinutes = this.flightForm.value.flightMinutes;
    this.flight.Details = this.flightForm.value.details;
    this.flight.FieldId = 1;  // TODO look it up

    this.flightService.addFlight(this.flight).subscribe((data: IFlight) => {
      this.savedFlight = data;
      console.log(this.savedFlight);
      this.message = `Saved flight with Id ${this.savedFlight.Id}.`;
      this.clearForm();
    });
  }

  // TODO Next. Better error handling - use the HeroApp components as an example with messages passed about...

  
  clearForm() {
    this.flightForm.reset();
    this.flightForm.patchValue({ date: new Date() });
  }

  models: IModel[];

  selectedValue: IModel;

}