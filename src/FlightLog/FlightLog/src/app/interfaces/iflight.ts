import { IModel } from './imodel';
import { ILocation } from './ilocation'

export interface IFlight { 
    Id: number; 
    AccountId: number;
    Date: Date;
    ModelId: number;
    FieldId: number;
    PilotId: number;
    FlightMinutes: number;
    Details: string;
}
    