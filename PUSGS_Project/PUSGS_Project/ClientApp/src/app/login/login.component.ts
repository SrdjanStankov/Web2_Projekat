import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BackendService } from '../services/backend.service';
import { STORAGE_TOKEN_KEY, STORAGE_USER_ID_KEY, STORAGE_TYPE_KEY, STORAGE_PASSCHG_KEY } from "../constants/storage"
import userTypes from "../constants/user-types";
import { AuthService, GoogleLoginProvider } from 'angularx-social-login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    password: new FormControl('', [Validators.required, Validators.minLength(3)]),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private backend: BackendService, public oAuth: AuthService, private router: Router) { }

  ngOnInit(): void { }

  onSubmit() {
    const email = this.loginGroup.get('email').value;
    const password = this.loginGroup.get('password').value;

    this.backend.login(email, password).then((res: any) => {
      localStorage.setItem(STORAGE_PASSCHG_KEY, res.requirePasswordChange);
      localStorage.setItem(STORAGE_TOKEN_KEY, res.token);
      localStorage.setItem(STORAGE_USER_ID_KEY, email);
      if (res.type === "SystemAdministrator") {
        localStorage.setItem(STORAGE_TYPE_KEY, userTypes.SystemAdmin);
      } else if (res.type === "RentACarAdministrator") {
        localStorage.setItem(STORAGE_TYPE_KEY, userTypes.RentACarAdmin);
      } else if (res.type === "AviationAdministrator") {
        localStorage.setItem(STORAGE_TYPE_KEY, userTypes.AviationAdmin);
      } else if (res.type === "User") {
        localStorage.setItem(STORAGE_TYPE_KEY, userTypes.User);
      }

      if (res.requirePasswordChange) {
        this.router.navigate(['change-password']);
      }
      this.activeModal.close();
    }, err => {
      if (err.status === 400) {
        this.reason = err.error.message;
      }
    });
  }

  loginWithGoogle() {
    this.oAuth.signIn(GoogleLoginProvider.PROVIDER_ID).
      then(user => {
        this.backend.loginScial(user).then((res: any) => {
          localStorage.setItem(STORAGE_TOKEN_KEY, res.token);
          localStorage.setItem(STORAGE_USER_ID_KEY, user.email);
          this.activeModal.close();
        }, err => {
          if (err.status === 400) {
            this.reason = err.error.message;
          }
        })
      })
  }
}
