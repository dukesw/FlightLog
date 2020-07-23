import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, Form, Validators } from '@angular/forms';
import { ModelService } from '../model.service';
import { LocationService } from '../location.service';
import { IModel } from '../interfaces/imodel';
import { FlightService } from '../flight.service';
import { IFlight } from '../interfaces/iflight';
import { Flight } from '../models/flight';
import { ILocation } from '../interfaces/ilocation';
import { IPilot } from '../interfaces/ipilot';
import { PilotService } from '../pilot.service';


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
      private pilotService: PilotService) {
    
        // Get the list of models
    modelService.getModels().subscribe((data: IModel[]) => {
      this.models = data;
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

  onSubmit() {
    console.warn(this.flightForm.value)

    this.flight.Date = this.flightForm.value.date;
    this.flight.ModelId = this.flightForm.value.modelId;
    this.flight.FlightMinutes = this.flightForm.value.flightMinutes;
    this.flight.Details = this.flightForm.value.details;
    this.flight.FieldId = this.flightForm.value.locationId;
    this.flight.PilotId = this.flightForm.value.pilotId;

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

}