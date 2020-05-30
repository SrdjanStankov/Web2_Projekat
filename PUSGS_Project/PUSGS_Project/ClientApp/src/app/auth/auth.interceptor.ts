import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { STORAGE_TOKEN_KEY } from '../constants/storage';
import { tap } from "rxjs/operators";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var jwt = localStorage.getItem(STORAGE_TOKEN_KEY);

    if (jwt != null) {
      const clonedReq = request.clone({
        headers: request.headers.set('Authorization', 'Bearer ' + localStorage.getItem(STORAGE_TOKEN_KEY))
      });

      return next.handle(clonedReq).pipe(
        tap(
          succ => { },
          err => {
            if (err.status == 401) {
              localStorage.removeItem('token');
              this.router.navigateByUrl('/login');
            }
          }
        )
      )
    }
    else {
      return next.handle(request.clone());
    }


  }
}
