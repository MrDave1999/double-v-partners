import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { catchError, throwError } from "rxjs";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return next.handle(req).pipe(
        catchError(error => {
            if(error instanceof HttpErrorResponse && error.status === 401)
            {
                localStorage.removeItem('token');
                localStorage.removeItem('name');
                this.router.navigate(['/login']);
                return throwError(() => error);
            }
            // This will forward other errors since 
            // this interceptor code is invoked on every http request
            return next.handle(req);
        })
    );
  }
}
