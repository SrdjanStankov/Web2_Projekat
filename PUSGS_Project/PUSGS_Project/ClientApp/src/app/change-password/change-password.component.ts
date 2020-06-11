import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { passwordMatchValidator } from '../register/register.component';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  currUserId: string;

  formGroup = new FormGroup({
    password: new FormControl('', [Validators.required, Validators.minLength(3)]),
    passwordRepeated: new FormControl('', [Validators.required, Validators.minLength(3)]),
  }, { validators: passwordMatchValidator })

  constructor(private userService: UserService, private router: Router) { }

  get passwordRepeated() { return this.formGroup.get('passwordRepeated'); }

  get password() { return this.formGroup.get('password'); }

  ngOnInit(): void {
    this.currUserId = this.userService.getLoggedInUserId();
  }

  isInvalid(name): boolean {
    return this.formGroup.get(name).invalid && this.formGroup.get(name).touched;
  }
  onSubmit() {
    const newPassword = this.formGroup.get('password').value;

    this.userService.changePassword(this.currUserId, newPassword).then(() => {
      this.router.navigateByUrl('');
    });
  }
}
