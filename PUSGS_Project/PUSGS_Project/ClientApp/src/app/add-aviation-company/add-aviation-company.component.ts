import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AddOrUpdateAviationCompanyRequest } from '../entities/requests/add-or-update-aviation-company-request';
import { AviationService } from '../services/aviation.service';

@Component({
  selector: 'app-add-aviation-company',
  templateUrl: './add-aviation-company.component.html',
  styleUrls: ['./add-aviation-company.component.css']
})
export class AddAviationCompanyComponent implements OnInit {
  aviationGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    x: new FormControl(0, Validators.required),
    y: new FormControl(0, Validators.required),
    cityName: new FormControl('', Validators.required),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private service: AviationService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const request = new AddOrUpdateAviationCompanyRequest();
    request.name = this.aviationGroup.get('name').value;
    request.description = this.aviationGroup.get('description').value;
    request.x = this.aviationGroup.get('x').value;
    request.y = this.aviationGroup.get('y').value;
    request.cityName = this.aviationGroup.get('cityName').value;

    this.service.add(request).then(() => {
      this.activeModal.close();
    });
  }
}
