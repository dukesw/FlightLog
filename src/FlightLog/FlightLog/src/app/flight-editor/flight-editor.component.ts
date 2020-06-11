import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form } from '@angular/forms';
import { ModelService } from '../model.service'; 
import { Model } from '../interfaces/model';
import { FlightService } from '../flight.service';
import { Flight } from '../interfaces/flight'


@Component({
  selector: 'app-flight-editor',
  templateUrl: './flight-editor.component.html',
  styleUrls: ['./flight-editor.component.css']
})
export class FlightEditorComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private modelService: ModelService, private flightService: FlightService) { 
    // Get the list of models
    modelService.getModels().subscribe((data: Model[]) => {
      this.models = data;
    });
    console.log(this.models);
  }

  ngOnInit(): void {
  }
  
  flight: Flight;

  flightForm = this.formBuilder.group({
    date: [new Date()],
    flightTime: [''], 
    model: [''],
    details: ['']
  });

  onSubmit() {
    console.warn(this.flightForm.value)
    
    this.flight.Date = this.flightForm.value.date;
    this.flight.ModelId = this.flightForm.value.model;
    this.flight.FlightTime = this.flightForm.value.flightTime;
    this.flight.Details = this.flightForm.value.details;

    var result = this.flightService.addFlight(this.flight);
  }

  models: Model[];

  selectedValue: Model;

}