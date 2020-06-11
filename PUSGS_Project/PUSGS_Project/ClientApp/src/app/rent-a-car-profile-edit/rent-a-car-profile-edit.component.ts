import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Car } from '../entities/car';
import { CarService } from '../services/car.service';
import { Branch } from '../entities/branch';
import { BranchService } from '../services/branch.service';
import { BackendService } from '../services/backend.service';

@Component({
  selector: 'app-rent-a-car-profile-edit',
  templateUrl: './rent-a-car-profile-edit.component.html',
  styleUrls: ['./rent-a-car-profile-edit.component.css']
})
export class RentACarProfileEditComponent implements OnInit {
  rentACar: RentACar = new RentACar();
  editGroup: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
  });

  formGroup = new FormGroup({
    name: new FormControl('Cool car', Validators.required),
    passengerNumber: new FormControl(4, Validators.required),
    type: new FormControl('Cool', Validators.required),
    brand: new FormControl('Cool brand', Validators.required),
    model: new FormControl('Cool model', Validators.required),
    buildDate: new FormControl(1969, Validators.required),
    costPerDay: new FormControl(69, Validators.required),
  });

  formGroupEditCar = new FormGroup({
    name: new FormControl('', Validators.required),
    passengerNumber: new FormControl(0, Validators.required),
    type: new FormControl('', Validators.required),
    brand: new FormControl('', Validators.required),
    model: new FormControl('', Validators.required),
    buildDate: new FormControl(0, Validators.required),
    costPerDay: new FormControl(0, Validators.required),
  });

  formGroupAddBranch = new FormGroup({
    name: new FormControl('Cool branch', Validators.required),
    address: new FormControl('London', Validators.required),
  });

  agencyId: number;

  constructor(private rentACarService: RentACarService, private route: ActivatedRoute, private modalService: NgbModal, private carService: CarService, private branchService: BranchService, public backend: BackendService) {
    route.params.subscribe(params => { this.agencyId = params['id']; });
    rentACarService.getAgency(this.agencyId).then(result => {
      this.rentACar = result;
      this.editGroup.setValue({
        name: result.name,
        address: result.address,
        description: result.description,
      });
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    this.rentACar.id = this.agencyId;
    this.rentACar.name = this.editGroup.get("name").value;
    this.rentACar.address = this.editGroup.get("address").value;
    this.rentACar.description = this.editGroup.get("description").value;

    this.rentACarService.updateAgency(this.rentACar).then(() => {
      this.refreshAgency();
    });
  }

  removeCar(index: number) {
    this.carService.removeCar(index).then(() => {
      this.refreshAgency();
    }, err => {
      if (err.status === 400) {
        alert(err.error.message);
      }
    });
  }

  editCar(id: number, content) {
    this.carService.getCar(id).then((car: Car) => {
      this.formGroupEditCar.setValue({
        name: car.name,
        passengerNumber: car.passengerNumber,
        type: car.type,
        brand: car.brand,
        model: car.model,
        buildDate: car.buildDate,
        costPerDay: car.costPerDay
      });
    });

    this.modalService.open(content, { ariaLabelledBy: 'modal-edit-car' }).result.then(result => {
      const car = new Car(
        this.formGroupEditCar.get("name").value,
        this.formGroupEditCar.get("passengerNumber").value,
        this.formGroupEditCar.get("type").value,
        this.formGroupEditCar.get("brand").value,
        this.formGroupEditCar.get("model").value,
        this.formGroupEditCar.get("buildDate").value,
        this.formGroupEditCar.get("costPerDay").value,
      );
      car.id = id;
      this.carService.updateCar(car).then(() => {
        this.refreshAgency();
      }, err => {
        if (err.status === 400) {
          alert(err.error.message);
        }
      });
    }, err => { });
  }

  private refreshAgency() {
    this.rentACarService.getAgency(this.agencyId).then(result => {
      this.rentACar = result;
    });
  }

  addCar(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-add-car' }).result.then((result) => {
      const car = new Car(
        this.formGroup.get("name").value,
        this.formGroup.get("passengerNumber").value,
        this.formGroup.get("type").value,
        this.formGroup.get("brand").value,
        this.formGroup.get("model").value,
        this.formGroup.get("buildDate").value,
        this.formGroup.get("costPerDay").value,
      );
      this.carService.addCar(car).then(result => {
        this.rentACarService.addCarToAgency(result.id, parseInt(this.agencyId.toString())).then(() => {
          this.refreshAgency();
        })
      })
    }, (reason) => { });
  }

  removeBranch(index: number) {
    this.branchService.removeBranch(index).then(() => {
      this.refreshAgency();
    });
  }

  addBranch(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-add-branch' }).result.then(result => {
      const branch = new Branch();
      branch.name = this.formGroupAddBranch.get('name').value;
      branch.address = this.formGroupAddBranch.get('address').value;
      // branch service
      this.branchService.addBranch(branch).then(result => {
        this.rentACarService.addBranchToAgency(result.id, parseInt(this.agencyId.toString())).then(() => {
          this.refreshAgency();
        })
      })
    }, reason => { });
  }
}
