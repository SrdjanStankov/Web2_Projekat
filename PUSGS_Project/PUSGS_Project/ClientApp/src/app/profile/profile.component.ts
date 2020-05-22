import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  public user: User;

  constructor(public userService: UserService) {
  }

  isReadOnly(): boolean {
    // TODO: Check if current profile is not profile of logged-in user
    return false;
  }

  ngOnInit(): void {
    this.userService.getLoggedInUser().then(user => {
      this.user = user;
    })
  }
}
