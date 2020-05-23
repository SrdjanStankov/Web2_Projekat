import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BackendService } from '../services/backend.service';
import { User } from '../entities/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    passwordGroup: new FormGroup({
      password: new FormControl('', [Validators.required, Validators.minLength(3)]),
      passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(3)]),
    }, { validators: passwordMatchValidator }),
    name: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
  });

  invalidUser: boolean;

  get passwordRepeated() { return this.registerGroup.get('passwordGroup').get('passwordRepeated'); }

  get password() { return this.registerGroup.get('passwordGroup').get('password'); }

  constructor(public activeModal: NgbActiveModal, private backend: BackendService) { }

  ngOnInit(): void {
    this.invalidUser = false;
  }

  onSubmit() {
    this.backend.register(new User({
      name: this.registerGroup.get('name').value,
      lastName: this.registerGroup.get('lastName').value,
      city: this.registerGroup.get('city').value,
      phone: this.registerGroup.get('phone').value,
      email: this.registerGroup.get('email').value,
      password: this.password.value
    })).then(() => {
      this.invalidUser = false;
      this.activeModal.close();
    });
  }
}

export function passwordMatchValidator(passwordControll: FormGroup) {
  if (passwordControll.get('password').value != passwordControll.get('passwordRepeated').value) {
    return { passwordsMatch: true };
  }
  return null;
}
