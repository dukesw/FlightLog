import { IFlight } from '../interfaces/iflight'

export class Flight implements IFlight{
    Id: number;
    AccountId: number;
    Date: Date;
    ModelId: number;
    FieldId: number;
    PilotId: number;
    FlightMinutes: number;
    Details: string;
}
