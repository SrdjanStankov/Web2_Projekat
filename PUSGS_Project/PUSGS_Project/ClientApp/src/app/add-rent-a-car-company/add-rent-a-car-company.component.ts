import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';

@Component({
  selector: 'app-add-rent-a-car-company',
  templateUrl: './add-rent-a-car-company.component.html',
  styleUrls: ['./add-rent-a-car-company.component.css']
})
export class AddRentACarCompanyComponent implements OnInit {

  rentACarGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private service: RentACarService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    let rentacar = new RentACar();
    rentacar.Name = this.rentACarGroup.get('name').value;
    rentacar.Address = this.rentACarGroup.get('address').value;
    rentacar.Description = this.rentACarGroup.get('description').value;
    this.service.addAgency(rentacar).then(() => {
      this.activeModal.close();
    });
  }

}
