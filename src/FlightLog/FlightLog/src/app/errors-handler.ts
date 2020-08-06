import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorsHandler implements ErrorHandler {

constructor(private injector: Injector) {}

    handleError(error: Error | HttpErrorResponse) {        
        const notificationService = this.injector.get(NotificationService);
        const router = this.injector.get(Router);
    
        if (error instanceof HttpErrorResponse) {
        // Server error happened      
          if (!navigator.onLine) {
            // No Internet connection
            return notificationService.notify('No Internet Connection');
          }
          // Http Error
          if (error.status === 401)
          {
              console.log('Got a 401 error');
          }
          
          if (error.status === 403)
          {
              console.log('Got a 403 error');
          }
          return notificationService.notify(`${error.status} - ${error.message}`);
        } else {
          // Client Error Happend      
          router.navigate(['/error'], { queryParams: {error: error} });
        }
        // Log the error anyway
        console.error(`ERRORed:  ${error}`);
      }

}
