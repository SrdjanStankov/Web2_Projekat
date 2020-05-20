import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BackendService } from '../services/backend.service';
import { AddRentACarCompanyComponent } from '../add-rent-a-car-company/add-rent-a-car-company.component';

@Component({
  selector: 'app-register-services',
  templateUrl: './register-services.component.html',
  styleUrls: ['./register-services.component.css']
})
export class RegisterServicesComponent implements OnInit {

  constructor(public modalService: NgbModal, private backend: BackendService) { }

  ngOnInit(): void {
  }

  AddAviationCompany() {
    alert('Not Implemented');
  }

  AddRentACarCompany() {
    this.modalService.open(AddRentACarCompanyComponent);
  }

  AddRentACarAdministrator() {
    alert('Not Implemented');
  }

  AddAviationAdministrator() {
    alert('Not Implemented');
  }
}
