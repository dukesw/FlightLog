export interface IFlightSummary {
    TotalFlightTimeMinutes: number; 
    TotalNumberOfFlights: number;
    AverageFlightTimeMinutes: number;
    FirstFlight: Date;
    LastFlight: Date;
    AccountId: number;
}
