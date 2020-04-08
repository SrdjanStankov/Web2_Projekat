import { Component, OnInit } from "@angular/core";
import { BackendService } from "../services/backend.service";
import { User } from "../entities/user";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  public user: User;

  constructor(public backend: BackendService) {
    this.user = backend.getLoggedInUser();
  }

  isReadOnly(): boolean {
    // TODO: Check if current profile is not profile of logged-in user
    return false;
  }

  ngOnInit(): void {}
}
