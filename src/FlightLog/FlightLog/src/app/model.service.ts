import { Injectable } from '@angular/core';
import { Model } from './interfaces/model'
import { HttpClient } from '@angular/common/http'
import { Observable, throwError, of } from 'rxjs'
import { catchError, retry } from 'rxjs/operators'



@Injectable({
  providedIn: 'root'
})

export class ModelService {

  constructor(private http: HttpClient) {  }

  modelUrl = 'https://localhost:5002/api/models';
  
  getModels(): Observable<Model[]> {
    return this.http.get<Model[]>(this.modelUrl)
      .pipe(
        catchError(this.handleError<Model[]>('getModels', []))
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
