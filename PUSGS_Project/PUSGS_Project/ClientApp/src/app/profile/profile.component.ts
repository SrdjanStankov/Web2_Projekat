import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { UserService } from "../services/user.service";
import { BackendService } from "../services/backend.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  public user: User;

  constructor(public userService: UserService, public authService: BackendService) {
  }

  isReadOnly(): boolean {
    // TODO: Check if current profile is not profile of logged-in user
    return false;
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
}
