import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BackendService } from '../services/backend.service';

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
    this.backend.login(this.loginGroup.get('email').value, this.loginGroup.get('password').value).then((res: any) => {
      localStorage.setItem('token', res.token);
      if (res.type === "SystemAdministrator") {
        localStorage.setItem('type', 'SystemAdmin');
      } else if (res.type === "RentACarAdministrator") {
        localStorage.setItem('type', 'RentACarAdmin');
      } else if (res.type === "User") {
        localStorage.setItem('type', 'User');
      }
      this.activeModal.close();

    }, err => {
      if (err.status == 400) {
        this.reason = err.error.message;
      }
    });
  }

}
