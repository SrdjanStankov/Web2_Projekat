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
    const loginTuple = this.backend.login(this.loginGroup.get('email').value, this.loginGroup.get('password').value);
    if (loginTuple[0]) {
      this.reason = '';
      this.activeModal.close();
    }
    else {
      this.reason = loginTuple[1];
    }
  }

}
