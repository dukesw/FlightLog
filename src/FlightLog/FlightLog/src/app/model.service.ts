import { Injectable } from '@angular/core';
import { IModel } from './interfaces/imodel'
import { HttpClient } from '@angular/common/http'
import { Observable, throwError, of } from 'rxjs'
import { catchError, retry } from 'rxjs/operators'
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})

export class ModelService {

  constructor(private http: HttpClient) {  }

  baseModelUrl = `${environment.apiUrl}api/ACCOUNT_ID/models/`;
  
  getModels(accountId: string): Observable<IModel[]> {
    var url = this.baseModelUrl.replace('ACCOUNT_ID', accountId);
    return this.http.get<IModel[]>(url)
      .pipe(
        catchError(err => {
          this.handleError<IModel[]>('getModels', [])
          return throwError(err);
        })
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
