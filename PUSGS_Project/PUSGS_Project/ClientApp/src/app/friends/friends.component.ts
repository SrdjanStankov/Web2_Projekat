import { Component, OnInit } from "@angular/core";
import { User } from "../entities/user";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-friends",
  templateUrl: "./friends.component.html",
  styleUrls: ["./friends.component.css"],
})
export class FriendsComponent implements OnInit {
  private allUsers: User[]; // cached users
  public displayedUsers: User[];
  public search = "";
  public friendsOnly = false;

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().then(users => {
      this.allUsers = users;
      this.displayedUsers = this.allUsers;
    });
  }

  onSubmit(): void {
    const searchText = this.search.toLowerCase();
    let filteredUsers = this._filterBySearchText(this.allUsers, searchText);
    if (this.friendsOnly) {
      filteredUsers = this._filterByFriends(
        filteredUsers,
        this.userService.getLoggedInUserId()
      );
    }
    this.displayedUsers = filteredUsers;
  }

  private _filterByFriends(usersToFilter: User[], loggedUserEmail: string): User[] {
    return usersToFilter.filter((user) => this._isFriend(user, loggedUserEmail));
  }

  private _isFriend(user: User, loggedUserEmail: string): boolean {
    return (
      user.email !== loggedUserEmail &&
      user.friends.some((friendEmail) => friendEmail === loggedUserEmail)
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
