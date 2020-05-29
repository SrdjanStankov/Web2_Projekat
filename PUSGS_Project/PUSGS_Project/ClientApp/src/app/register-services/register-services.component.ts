import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BackendService } from '../services/backend.service';
import { AddRentACarCompanyComponent } from '../add-rent-a-car-company/add-rent-a-car-company.component';
import { AddRentACarAdministratorComponent } from '../add-rent-a-car-administrator/add-rent-a-car-administrator.component';
import { AddAviationCompanyComponent } from '../add-aviation-company/add-aviation-company.component';

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
    this.modalService.open(AddAviationCompanyComponent);
  }

  AddRentACarCompany() {
    this.modalService.open(AddRentACarCompanyComponent);
  }

  AddRentACarAdministrator() {
    this.modalService.open(AddRentACarAdministratorComponent);
  }

  AddAviationAdministrator() {
    alert('Not Implemented');
  }
}
