import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BackendService } from '../services/backend.service';
import { STORAGE_TOKEN_KEY, STORAGE_USER_ID_KEY } from "../constants/storage"

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

  constructor(public activeModal: NgbActiveModal, private backend: BackendService) { }

  ngOnInit(): void { }

  onSubmit() {
    const email = this.loginGroup.get('email').value;
    const password = this.loginGroup.get('password').value;

    this.backend.login(email, password).then((res: any) => {
      localStorage.setItem(STORAGE_TOKEN_KEY, res.token);
      localStorage.setItem(STORAGE_USER_ID_KEY, email);

      this.activeModal.close();
    }, err => {
      if (err.status === 400) {
        this.reason = err.error.message;
      }
    });
  }
}
