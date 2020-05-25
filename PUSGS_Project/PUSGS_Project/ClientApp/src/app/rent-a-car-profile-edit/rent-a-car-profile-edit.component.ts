import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Car } from '../entities/car';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-rent-a-car-profile-edit',
  templateUrl: './rent-a-car-profile-edit.component.html',
  styleUrls: ['./rent-a-car-profile-edit.component.css']
})
export class RentACarProfileEditComponent implements OnInit {

  rentACar: RentACar = new RentACar();
  editGroup: FormGroup = new FormGroup({
    name: new FormControl(null),
    address: new FormControl(null),
    description: new FormControl(null),
  });

  formGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    passengerNumber: new FormControl(0, Validators.required),
    type: new FormControl('', Validators.required),
    brand: new FormControl('', Validators.required),
    model: new FormControl('', Validators.required),
    buildDate: new FormControl(0, Validators.required),
    costPerDay: new FormControl(0, Validators.required),
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

  agencyId: number;

  constructor(private rentACarService: RentACarService, private route: ActivatedRoute, private modalService: NgbModal, private carService: CarService) {
    route.params.subscribe(params => { this.agencyId = params['id']; });
    rentACarService.getAgency(this.agencyId).then(result => {
      this.rentACar = result;
      this.editGroup.setValue({
        name: this.rentACar.name,
        address: this.rentACar.address,
        description: this.rentACar.description,
      });
    });

  }

  ngOnInit(): void {
  }

  onSubmit() {
    // check if valid

    // set all values
    this.rentACar.name = this.editGroup.get("name").value;
    this.rentACar.address = this.editGroup.get("address").value;
    this.rentACar.description = this.editGroup.get("description").value;

    //talk to backend to update values
  }

  removeCar(index: number) {
    this.carService.removeCar(index).then(() => {
      this.refreshAgency();
    })
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
    //this.rentACar.removeBranch(index);
  }

  addBranch() {
    //this.rentACar.addBranch("name 20");
  }
}
