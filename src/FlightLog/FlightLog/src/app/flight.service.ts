import { Injectable } from '@angular/core';
import { IFlight } from './interfaces/iflight';
import { Flight } from './models/flight';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, throwError, of } from 'rxjs'
import { catchError, retry } from 'rxjs/operators'
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  flightUrl = environment.apiUrl + 'api/ACCOUNT_ID/flights';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private http: HttpClient) { }

  addOrUpdateFlight(accountId: number, flight: Flight): Observable<Flight> {
    var url = this.flightUrl.replace('ACCOUNT_ID', accountId.toString());
    if (flight.Id > 0) {
      return this.http.put<Flight>(url, flight, this.httpOptions)
    } else {  
      return this.http.post<Flight>(url, flight, this.httpOptions);
    }
      //.pipe(
        //catchError(this.handleError<Flight>('addFlight'))
        //catchError()
      //)
  }

  getFlight(accountId: number, flightId: number) {
    var url = this.flightUrl.replace('ACCOUNT_ID', accountId.toString());
    return this.http.get(`${url}/${flightId}`, this.httpOptions);
  }
  
  getFlightSummary(accountId: number, modelId: number) {
    var url = this.flightUrl.replace('ACCOUNT_ID', accountId.toString());
    return this.http.get(`${url}/summary/${modelId}`, this.httpOptions);
  }

  getFlightsByModel(accountId: number, modelId: number) {
      var url = this.flightUrl.replace('ACCOUNT_ID', accountId.toString());
      return this.http.get(`${url}/model/${modelId}`, this.httpOptions);
  }

    /** 
   * Handle Http operation that failed, letting the app continue. 
   * @param operation - the name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send to centralised logging
      // if (error instanceof HttpErrorResponse) {

      // }
      console.error(error);
      this.log(`${operation} failed with error: ${error.message}`);
      return of(result as T);
    }
  }

  private log(message: string) {
    console.info(`ModelService: ${message}`);
  }

}
