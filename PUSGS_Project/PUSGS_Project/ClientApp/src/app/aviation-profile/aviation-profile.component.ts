import { Component, OnInit } from '@angular/core';
import { AviationCompany } from '../entities/aviation-company';
import { AviationService } from '../services/aviation.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AddOrUpdateAviationCompanyRequest } from '../entities/requests/add-or-update-aviation-company-request';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-aviation-profile',
  templateUrl: './aviation-profile.component.html',
  styleUrls: ['./aviation-profile.component.css']
})
export class AviationProfileComponent implements OnInit {
  public company: AviationCompany;
  public id: number;

  constructor(private service: AviationService, private route: ActivatedRoute, private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(result => {
      this.company = result;
    });
  }

  // Edit aviation form
  aviationGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    cityName: new FormControl('', Validators.required),
  });

  editProfile(aviationForm) {
    this.setAviationGroup(this.company);
    this.modalService.open(aviationForm, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      console.log(`Closed with: ${result}`);
      this.onEditAviationSubmit();
    }, (reason) => {
      console.log(`Dismissed ${reason}`);
    });
  }

  onEditAviationSubmit() {
    const request = new AddOrUpdateAviationCompanyRequest();
    request.id = this.company.id;
    request.name = this.aviationGroup.get("name").value;
    request.description = this.aviationGroup.get("description").value;
    request.cityName = this.aviationGroup.get("cityName").value;
    request.x = this.company.address.x;
    request.y = this.company.address.y;

    this.service.update(request).then(() => {
      console.log("Successfully updated company");
      window.location.reload();
    })
  }

  private setAviationGroup(item: AviationCompany) {
    this.aviationGroup.setValue({ name: item.name, description: item.description, cityName: item.address.cityName });
  }

  // Add flight
  addFlight() {
  }
}
