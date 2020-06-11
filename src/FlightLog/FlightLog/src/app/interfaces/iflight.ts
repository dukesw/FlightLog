import { IModel } from './imodel';

export interface IFlight { 
    Id: number; 
    Date: Date;
    ModelId: number;
    FieldId: number;
    FlightMinutes: number;
    Details: string;
}
    