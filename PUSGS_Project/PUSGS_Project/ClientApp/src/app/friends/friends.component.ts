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
    let filteredUsers = this._filterBySearchText(this.allUsers, searchText);
    if (this.friendsOnly) {
      filteredUsers = this._filterByFriends(
        filteredUsers,
        this.backend.getLoggedInUser()
      );
    }
    this.displayedUsers = filteredUsers;
  }

  private _filterByFriends(usersToFilter: User[], loggedUser: User): User[] {
    return usersToFilter.filter((user) => this._isFriend(user, loggedUser));
  }

  private _isFriend(user: User, loggedUser: User): boolean {
    return (
      user.email !== loggedUser.email &&
      user.friends.some((friend) => friend.email === loggedUser.email)
    );
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
