import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BackendService } from '../services/backend.service';
import { RentACarAdmin } from '../entities/RentACarAdmin';

@Component({
  selector: 'app-add-rent-a-car-administrator',
  templateUrl: './add-rent-a-car-administrator.component.html',
  styleUrls: ['./add-rent-a-car-administrator.component.css']
})
export class AddRentACarAdministratorComponent implements OnInit {
  rentACarAdminGroup = new FormGroup({
    name: new FormControl('Dio', Validators.required),
    lastName: new FormControl('Brando', Validators.required),
    city: new FormControl('JOJO', Validators.required),
    phone: new FormControl('WRYYYYYY', Validators.required),
    email: new FormControl('dio@gmail.com', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    password: new FormControl('123', [Validators.required, Validators.minLength(3)]),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private service: BackendService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    var a = this.rentACarAdminGroup.valid;

    let rentacaradmin = new RentACarAdmin();
    rentacaradmin.name = this.rentACarAdminGroup.get('name').value;
    rentacaradmin.lastName = this.rentACarAdminGroup.get('lastName').value;
    rentacaradmin.city = this.rentACarAdminGroup.get('city').value;
    rentacaradmin.phone = this.rentACarAdminGroup.get('phone').value;
    rentacaradmin.email = this.rentACarAdminGroup.get('email').value;
    rentacaradmin.password = this.rentACarAdminGroup.get('password').value;
    this.service.addRentACarAdmin(rentacaradmin).then(() => {
      this.activeModal.close();
    }, err => {
      this.reason = err.error.message;
    });
  }
}
