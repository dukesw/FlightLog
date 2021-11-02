import { IModel } from './imodel';
import { ILocation } from './ilocation'
import { ILookup } from './ilookup';

export interface IFlight { 
    Id: number; 
    AccountId: number;
    Date: Date;
    Battery: ILookup;
    Model: ILookup;
    Field: ILookup;
    Pilot: ILookup;
    FlightMinutes: number;
    Details: string;
}
    