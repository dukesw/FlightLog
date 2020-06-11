import { IFlight } from '../interfaces/iflight'

export class Flight implements IFlight{
    Id: number;
    Date: Date;
    ModelId: number;
    FieldId: number;
    FlightTime: number;
    Details: string;
}
