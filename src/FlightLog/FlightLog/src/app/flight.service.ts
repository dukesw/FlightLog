import { Injectable } from '@angular/core';
import { Flight } from './interfaces/flight';
import { HttpClient } from '@angular/common/http'
import { Observable, throwError, of } from 'rxjs'
import { catchError, retry } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  flightUrl = 'https://localhost:5001/api/flights';

  constructor(private http: HttpClient) { }

  addFlight(flight: Flight): Observable<Flight> {
    return this.http.post<Flight>(this.flightUrl, flight)
      .pipe(
        catchError(this.handleError<Flight>('addFlight'))
      )
  }

    /** 
   * Handle Http operation that failed, letting the app continue. 
   * @param operation - the name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send to centralised logging
      console.error(error);
      this.log(`${operation} failed with error: ${error.message}`);
      return of(result as T);
    }
  }

  private log(message: string) {
    console.info(`ModelService: ${message}`);
  }

}
