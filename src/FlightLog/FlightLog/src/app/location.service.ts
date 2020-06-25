import { Injectable } from '@angular/core';
import { ILocation } from './interfaces/ilocation'
import { HttpClient } from '@angular/common/http'
import { Observable, throwError, of } from 'rxjs'
import { catchError, retry } from 'rxjs/operators'
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})

export class LocationService {

  constructor(private http: HttpClient) {  }

  locationUrl = environment.apiUrl + 'api/locations';
  
  getLocations(): Observable<ILocation[]> {
    return this.http.get<ILocation[]>(this.locationUrl)
      .pipe(
        catchError(this.handleError<ILocation[]>('getLocationss', []))
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
    console.info(`LocationService: ${message}`);
  }

}
