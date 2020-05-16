import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Car } from '../entities/car';

@Component({
  selector: 'app-rent-a-car-profile-edit',
  templateUrl: './rent-a-car-profile-edit.component.html',
  styleUrls: ['./rent-a-car-profile-edit.component.css']
})
export class RentACarProfileEditComponent implements OnInit {

  public rentACar: RentACar;
  public editGroup: FormGroup;

  constructor(private service: RentACarService) {
    this.rentACar = service.getAgency(0);

    this.editGroup = new FormGroup({
      name: new FormControl(this.rentACar.name),
      address: new FormControl(this.rentACar.address),
      description: new FormControl(this.rentACar.description),
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
    //this.rentACar.removeCar(index);
  }

  addCar() {
    //this.rentACar.addCar(new Car("name 20", 4, "Suv", "Brand 1", "Model 1", 2009, 20));
  }

  removeBranch(index: number) {
    //this.rentACar.removeBranch(index);
  }

  addBranch() {
    //this.rentACar.addBranch("name 20");
  }
}
