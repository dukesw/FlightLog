import { IModel } from './imodel';
import { ILocation } from './ilocation'

export interface IFlight { 
    Id: number; 
    Date: Date;
    ModelId: number;
    FieldId: number;
    FlightMinutes: number;
    Details: string;
}
    