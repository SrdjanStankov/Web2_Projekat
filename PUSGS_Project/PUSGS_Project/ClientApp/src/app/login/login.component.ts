import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    constructor() {
  }

  ngOnInit() {
  }

  onClickSubmit(formData) {
    alert('Your Email is : ' + formData.email + ' Your Password is : ' + formData.password);
  }

}
