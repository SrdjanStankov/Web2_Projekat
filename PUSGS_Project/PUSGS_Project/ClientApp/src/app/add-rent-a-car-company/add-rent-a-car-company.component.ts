import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RentACarService } from '../services/rent-a-car.service';
import { RentACar } from '../entities/rent-a-car';

@Component({
  selector: 'app-add-rent-a-car-company',
  templateUrl: './add-rent-a-car-company.component.html',
  styleUrls: ['./add-rent-a-car-company.component.css']
})
export class AddRentACarCompanyComponent implements OnInit {
  rentACarGroup = new FormGroup({
    name: new FormControl('My Car Company', Validators.required),
    address: new FormControl('London', Validators.required),
    description: new FormControl('This is the best car company ever', Validators.required),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private service: RentACarService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    let rentacar = new RentACar();
    rentacar.name = this.rentACarGroup.get('name').value;
    rentacar.address = this.rentACarGroup.get('address').value;
    rentacar.description = this.rentACarGroup.get('description').value;
    this.service.addAgency(rentacar).then(() => {
      this.activeModal.close();
    });
  }
}
