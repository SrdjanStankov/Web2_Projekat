import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { UserService } from "../services/user.service";
import { BackendService } from "../services/backend.service";
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, Validators, FormControl } from "@angular/forms";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  public user: User;
  public tempUser: User;

  formGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
  })

  constructor(public userService: UserService, public authService: BackendService, private modalService: NgbModal) {
  }

  isReadOnly(): boolean {
    // TODO: Check if current profile is not profile of logged-in user
    return false;
  }

  open(content) {
    this.setGroup(this.user);

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      console.log(`Closed with: ${result}`);
      this.onUpdate();
    }, (reason) => {
      console.log(`Dismissed ${this.getDismissReason(reason)}`);
    });
  }

  onUpdate() {
    const tempUser = this.getUserFromGroup();
    console.log(tempUser);
    this.userService.updateUser(tempUser).then(() => {
      window.location.reload();
    })
  }

  onDelete() {
    this.userService.deleteUser(this.user.email).then(() => {
      this.authService.logout();
    })
  }

  ngOnInit(): void {
    this.userService.getLoggedInUser().then(user => {
      this.user = user;
    })
  }

  private setGroup(user: User) {
    this.formGroup.setValue({ name: user.name, lastName: user.lastName, city: user.city, phone: user.phone });
  }
  private getUserFromGroup(): User {
    return new User({
      name: this.formGroup.get("name").value,
      lastName: this.formGroup.get('lastName').value,
      city: this.formGroup.get('city').value,
      phone: this.formGroup.get('phone').value,
      email: this.user.email
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
