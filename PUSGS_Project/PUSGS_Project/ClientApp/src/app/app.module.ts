import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider } from "angularx-social-login";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ProfileComponent } from "./profile/profile.component";
import { RentACarProfileComponent } from './rent-a-car-profile/rent-a-car-profile.component';
import { RentACarProfileEditComponent } from './rent-a-car-profile-edit/rent-a-car-profile-edit.component';
import { CarReservationComponent } from './car-reservation/car-reservation.component';
import { FriendsComponent } from "./friends/friends.component";
import { CLIENT_ID } from "./constants/storage";
import { MailConfirmationComponent } from './mail-confirmation/mail-confirmation.component';
import { AddRentACarAdministratorComponent } from './add-rent-a-car-administrator/add-rent-a-car-administrator.component';
import { AddRentACarCompanyComponent } from './add-rent-a-car-company/add-rent-a-car-company.component';
import { RegisterServicesComponent } from './register-services/register-services.component';
import { AddAviationCompanyComponent } from "./add-aviation-company/add-aviation-company.component";
import { AviationProfileComponent } from './aviation-profile/aviation-profile.component';
import { AuthInterceptor } from "./auth/auth.interceptor";
import { AuthGuard } from "./auth/auth.guard";
import { FlightsComponent } from './flights/flights.component';
import { FlightDetailsComponent } from './flight-details/flight-details.component';
import { FlightSeatsComponent } from './flight-seats/flight-seats.component';
import { FlightSeatComponent } from './flight-seat/flight-seat.component';
import { FlightReservationFormComponent } from './flight-reservation-form/flight-reservation-form.component';
import { TicketHistoryComponent } from './ticket-history/ticket-history.component';
import { AddFlightFormComponent } from './add-flight-form/add-flight-form.component';
import { AddFlightRequest } from "./entities/requests/add-flight-request";
import { ChangePasswordComponent } from './change-password/change-password.component';
import { QuickTicketReservationComponent } from './quick-ticket-reservation/quick-ticket-reservation.component';
import { AddQuickTicketComponent } from './add-quick-ticket/add-quick-ticket.component';
import { QuickCarReservationComponent } from './quick-car-reservation/quick-car-reservation.component';
import { AviationCompaniesComponent } from './aviation-companies/aviation-companies.component';
import { AcceptInvitationComponent } from './accept-invitation/accept-invitation.component';
import { AddAviationAdministratorComponent } from './add-aviation-administrator/add-aviation-administrator.component';

let config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider(CLIENT_ID)
  }
]);

export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    RentACarProfileComponent,
    RentACarProfileEditComponent,
    CarReservationComponent,
    FriendsComponent,
    MailConfirmationComponent,
    AddRentACarAdministratorComponent,
    AddRentACarCompanyComponent,
    AddAviationCompanyComponent,
    RegisterServicesComponent,
    AviationProfileComponent,
    FlightsComponent,
    FlightDetailsComponent,
    FlightSeatsComponent,
    FlightSeatComponent,
    FlightReservationFormComponent,
    TicketHistoryComponent,
    AddFlightFormComponent,
    ChangePasswordComponent,
    QuickTicketReservationComponent,
    AddQuickTicketComponent,
    AviationCompaniesComponent,
    AcceptInvitationComponent,
    AddAviationAdministratorComponent,
    QuickCarReservationComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    SocialLoginModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "profile", component: ProfileComponent, canActivate: [AuthGuard] },
      { path: "aviation/:id", component: AviationProfileComponent },
      { path: "aviation/:id/add-flight", component: AddFlightFormComponent, canActivate: [AuthGuard] },
      { path: "aviation/:id/quick-reservations", component: QuickTicketReservationComponent, canActivate: [AuthGuard] },
      { path: "aviation/:id/add-quick-ticket", component: AddQuickTicketComponent, canActivate: [AuthGuard] },
      { path: "rent-a-car/:id", component: RentACarProfileComponent },
      { path: "rent-a-car/:id/quick-reservations", component: QuickCarReservationComponent },
      { path: "rent-a-car-edit/:id", component: RentACarProfileEditComponent, canActivate: [AuthGuard] },
      { path: "car-reservation", component: CarReservationComponent, canActivate: [AuthGuard] },
      { path: "users", component: FriendsComponent, canActivate: [AuthGuard] },
      { path: "change-password", component: ChangePasswordComponent, canActivate: [AuthGuard] },
      { path: "flights", component: FlightsComponent, canActivate: [AuthGuard] },
      { path: "flight/:id", component: FlightDetailsComponent },
      { path: "flight/:id/reservation", component: FlightReservationFormComponent, canActivate: [AuthGuard] },
      { path: "flight-ticket/:id/accept", component: AcceptInvitationComponent },
      { path: "ConfirmEmail/:email", component: MailConfirmationComponent },
      { path: "services", component: RegisterServicesComponent, canActivate: [AuthGuard] },
    ]),
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
