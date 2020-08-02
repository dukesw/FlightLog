import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone( {
      setHeaders: {
        Authorization: `${this.authService.getAuthourizationHeaderValue()}`
      }
    });
    
    return next.handle(request);
    // return next.handle(request).pipe(
    //   tap(response => {
    //     if (response instanceof HttpResponse) {
    //       console.log("Found an HttpResponse " + response.status);
    //       if (response.status === 401) {
    //         console.log(" Got a 401");
    //       }
    //       if (response.status === 403) {
    //         console.log(" Got a 403");
    //       }
    //     }    
    //   }));
    
  }
}
