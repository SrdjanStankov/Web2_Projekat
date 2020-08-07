import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { STORAGE_TOKEN_KEY } from '../constants/storage';
import { getRequirePassChange } from '../util/storage';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (state.url !== '/change-password' && getRequirePassChange()) {
      this.router.navigate(['change-password']);
      return false;
    }
    const token = localStorage.getItem(STORAGE_TOKEN_KEY);
    if (token != null)
      return true;
    else {
      this.router.navigate(['']);
      return false;
    }
  }
}
