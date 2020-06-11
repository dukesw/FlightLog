import { IModel } from './imodel';

export interface IFlight { 
    Id: number; 
    Date: Date;
    ModelId: number;
    FieldId: number;
    FlightTime: number;
    Details: string;
}
    