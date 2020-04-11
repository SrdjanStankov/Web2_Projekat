import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { BackendService } from "../services/backend.service";

@Component({
  selector: "app-friends",
  templateUrl: "./friends.component.html",
  styleUrls: ["./friends.component.css"],
})
export class FriendsComponent implements OnInit {
  public users: User[];

  constructor(public backend: BackendService) {}

  ngOnInit(): void {
    this.users = this.backend.registeredUsers;
  }
}
