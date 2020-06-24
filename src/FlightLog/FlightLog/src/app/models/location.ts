import { ILocation } from '../interfaces/ilocation'

export class Location implements ILocation {
    Id: number;
    Name: string;
    Lattitude: number;
    Longitude: number;
    Notes: string;
    WeatherStationLink: string;
}
