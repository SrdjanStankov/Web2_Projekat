import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RentACarAdmin } from '../entities/RentACarAdmin';
import { BackendService } from '../services/backend.service';

@Component({
  selector: 'app-add-rent-a-car-administrator',
  templateUrl: './add-rent-a-car-administrator.component.html',
  styleUrls: ['./add-rent-a-car-administrator.component.css']
})
export class AddRentACarAdministratorComponent implements OnInit {

  rentACarAdminGroup = new FormGroup({
    name: new FormControl(null, Validators.required),
    lastName: new FormControl(null, Validators.required),
    city: new FormControl(null, Validators.required),
    phone: new FormControl(null, Validators.required),
    email: new FormControl(null, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    password: new FormControl(null, [Validators.required, Validators.minLength(3)]),
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
