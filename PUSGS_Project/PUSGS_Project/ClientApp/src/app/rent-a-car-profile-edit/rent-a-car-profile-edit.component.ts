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
      name: new FormControl(this.rentACar.Name),
      address: new FormControl(this.rentACar.Address),
      description: new FormControl(this.rentACar.Description),
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    // check if valid

    // set all values
    this.rentACar.Name = this.editGroup.get("name").value;
    this.rentACar.Address = this.editGroup.get("address").value;
    this.rentACar.Description = this.editGroup.get("description").value;

    //talk to backend to update values
  }

  removeCar(index: number) {
    this.rentACar.removeCar(index);
  }

  addCar() {
    this.rentACar.addCar(new Car("name 20", 4, "Suv"));
  }

  removeBranch(index: number) {
    this.rentACar.removeBranch(index);
  }

  addBranch() {
    this.rentACar.addBranch("name 20");
  }
}
