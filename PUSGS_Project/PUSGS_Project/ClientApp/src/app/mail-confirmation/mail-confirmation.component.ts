import { Component, OnInit } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-mail-confirmation',
  templateUrl: './mail-confirmation.component.html',
  styleUrls: ['./mail-confirmation.component.css']
})
export class MailConfirmationComponent implements OnInit {

  result: string;
  email: string;

  constructor(private backend: BackendService, private route: ActivatedRoute, private router: Router) {
    route.params.subscribe(params => { this.email = params['email']; });
    console.log(this.email);
    this.result = "default";
  }

  ngOnInit(): void {
    this.backend.confirmEmail(this.email).then(() => {
      this.result = "Verified";
      setTimeout(() => {
        this.router.navigateByUrl("");
      }, 1500);
      
    }, err => {
        this.result = err.error.message;
    });
  }

}
