import { IFlight } from '../interfaces/iflight'
import { FlightBattery } from './flight-battery';
import { FlightLocation } from './flight-location';
import { FlightModel } from './flight-model';
import { FlightPilot } from './flight-pilot';

export class Flight implements IFlight{
    Id: number;
    AccountId: number;
    Date: Date;
    Battery: FlightBattery = new FlightBattery();
    Model: FlightModel = new FlightModel();
    Field: FlightLocation = new FlightLocation();
    Pilot: FlightPilot = new FlightPilot();
    FlightMinutes: number;
    Details: string;
}