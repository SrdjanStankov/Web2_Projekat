import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ProfileComponent } from "./profile/profile.component";
import { RentACarProfileComponent } from './rent-a-car-profile/rent-a-car-profile.component';
import { RentACarProfileEditComponent } from './rent-a-car-profile-edit/rent-a-car-profile-edit.component';
import { CarReservationComponent } from './car-reservation/car-reservation.component';
import { FriendsComponent } from "./friends/friends.component";
import { RegisterServicesComponent } from './register-services/register-services.component';
import { AddRentACarCompanyComponent } from './add-rent-a-car-company/add-rent-a-car-company.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    RentACarProfileComponent,
    RentACarProfileEditComponent,
    CarReservationComponent,
    FriendsComponent,
    RegisterServicesComponent,
    AddRentACarCompanyComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "login", component: LoginComponent },
      { path: "profile", component: ProfileComponent },
      { path: "rent-a-car", component: RentACarProfileComponent},
      { path: "rent-a-car-edit", component: RentACarProfileEditComponent },
      { path: "car-reservation", component: CarReservationComponent },
      { path: "users", component: FriendsComponent },
      { path: "services", component: RegisterServicesComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
