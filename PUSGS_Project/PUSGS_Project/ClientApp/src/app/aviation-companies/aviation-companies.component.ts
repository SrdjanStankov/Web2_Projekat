import { Component, OnInit } from '@angular/core';
import { AviationCompany } from '../entities/aviation-company';
import { AviationService } from '../services/aviation.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-aviation-companies',
  templateUrl: './aviation-companies.component.html',
  styleUrls: ['./aviation-companies.component.css']
})
export class AviationCompaniesComponent implements OnInit {
  private aviationCompanies: AviationCompany[];
  displayedCompanies: AviationCompany[];
  search = "";

  constructor(private aviationService: AviationService, private router: Router) { }

  ngOnInit(): void {
    this.aviationService.getAll().then(result => {
      this.aviationCompanies = result;
      this.onApplyFilter();
    });
  }

  onApplyFilter() {
    let query = this.aviationCompanies;

    this.search.split(',').forEach(str => {
      const search = str.toLowerCase().trim();
      if (search) {
        query = this.filterBySearchText(query, search);
      }
    });

    this.displayedCompanies = query;
  }

  aviationDetails(id: number) {
    this.router.navigateByUrl("aviation/" + id);
  }

  private filterBySearchText(query: AviationCompany[], search = ""): AviationCompany[] {
    return query.filter(company => {
      return company.name.toLowerCase().includes(search)
        || company.address.cityName.toLowerCase().includes(search)
        || company.description.toLowerCase().includes(search);
    });
  }
}
