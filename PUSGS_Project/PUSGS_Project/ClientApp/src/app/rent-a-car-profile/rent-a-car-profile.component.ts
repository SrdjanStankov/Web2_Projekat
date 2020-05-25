import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-rent-a-car-profile',
  templateUrl: './rent-a-car-profile.component.html',
  styleUrls: ['./rent-a-car-profile.component.css']
})
export class RentACarProfileComponent implements OnInit {

  rentACar: RentACar = new RentACar();
  id: number;

  constructor(private service: RentACarService, private route: ActivatedRoute, private router: Router) {
    route.params.subscribe(params => { this.id = params['id']; });
    service.getAgency(this.id).then(result => this.rentACar = result);
  }

  ngOnInit(): void {
  }

  edit(id: number) {
    this.router.navigateByUrl("rent-a-car-edit/" + id);
  }

}
