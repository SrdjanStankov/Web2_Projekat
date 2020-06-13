import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BackendService } from '../services/backend.service';
import { AviationAdmin } from '../entities/AviationAdmin';

@Component({
  selector: 'app-add-aviation-administrator',
  templateUrl: './add-aviation-administrator.component.html',
  styleUrls: ['./add-aviation-administrator.component.css']
})
export class AddAviationAdministratorComponent implements OnInit {
  adminGroup = new FormGroup({
    name: new FormControl('Giorno', Validators.required),
    lastName: new FormControl('Giovanna', Validators.required),
    city: new FormControl('JOJO', Validators.required),
    phone: new FormControl('I-HAVE-A-DREAM', Validators.required),
    email: new FormControl('giorno@gmail.com', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    password: new FormControl('123', [Validators.required, Validators.minLength(3)]),
  });

  reason: string;

  constructor(public activeModal: NgbActiveModal, private service: BackendService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const admin = new AviationAdmin();
    admin.name = this.adminGroup.get('name').value;
    admin.lastName = this.adminGroup.get('lastName').value;
    admin.city = this.adminGroup.get('city').value;
    admin.phone = this.adminGroup.get('phone').value;
    admin.email = this.adminGroup.get('email').value;
    admin.password = this.adminGroup.get('password').value;
    this.service.addAviationAdmin(admin).then(() => {
      this.activeModal.close();
    }, err => {
      this.reason = err.error.message;
    });
  }
}
