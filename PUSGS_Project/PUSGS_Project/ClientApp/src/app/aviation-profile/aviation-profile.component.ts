import { Component, OnInit } from '@angular/core';
import { AviationCompany } from '../entities/aviation-company';
import { AviationService } from '../services/aviation.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-aviation-profile',
  templateUrl: './aviation-profile.component.html',
  styleUrls: ['./aviation-profile.component.css']
})
export class AviationProfileComponent implements OnInit {
  public company: AviationCompany;
  public id: number;

  constructor(private service: AviationService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(result => {
      this.company = result;
    });
  }
}
