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
  private currentUserId: string;
  public displayedUsers: User[];
  public search = "";
  public friendsOnly = false;

  constructor(public userService: UserService) { }

  ngOnInit(): void {
    this.currentUserId = this.userService.getLoggedInUserId();
    this.refresh();
  }

  refresh() {
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
        this.currentUserId
      );
    }
    this.displayedUsers = filteredUsers;
  }

  addFriend(friend: User) {
    this.userService.addFriend(this.currentUserId, friend.email).then(() => {
      this.refresh();
    });
  }

  unfriend(friend: User) {
    this.userService.unfriend(this.currentUserId, friend.email).then(() => {
      this.refresh();
    });
  }

  isCurrentUser(user: User): boolean {
    return this.currentUserId === user.email;
  }

  isFriendToCurrentUser(potentialFriend: User): boolean {
    return potentialFriend.friends.some(friendEmail => friendEmail === this.currentUserId);
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
