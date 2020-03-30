import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onClickSubmit(formData) {
    alert(formData.firstName + ' ' + formData.lastName + ' ' + formData.city + ' ' + formData.telephone + ' ' + formData.email + ' ' + formData.password + ' '  + formData.passwordRepeated);
  }
}
