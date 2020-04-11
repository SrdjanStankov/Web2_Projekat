import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { BackendService } from "../services/backend.service";

@Component({
  selector: "app-friends",
  templateUrl: "./friends.component.html",
  styleUrls: ["./friends.component.css"],
})
export class FriendsComponent implements OnInit {
  private allUsers: User[]; // cached users
  public displayedUsers: User[];
  public search: string = "";
  public friendsOnly: boolean = false;

  constructor(public backend: BackendService) {}

  ngOnInit(): void {
    this.allUsers = this.backend.getAllUsers();
    this.displayedUsers = this.allUsers;
  }

  onSubmit(): void {
    const searchText = this.search.toLowerCase();
    const filtered = this._filterBySearchText(this.allUsers, searchText);

    this.displayedUsers = filtered;
  }

  private _filterBySearchText(
    usersToFilter: User[],
    searchText: string
  ): User[] {
    return usersToFilter.filter((user) => {
      if (user.name.toLowerCase().includes(searchText)) {
        return true;
      }
      if (user.lastName.toLowerCase().includes(searchText)) {
        return true;
      }
      return false;
    });
  }
}
