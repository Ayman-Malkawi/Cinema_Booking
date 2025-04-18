import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProfileComponent } from './Habib/profile/profile.component';
import { NavbarComponent } from './Habib/navbar/navbar.component';
import { MoviesComponent } from './movies/movies.component';
import { TicketBookingComponent } from './ticket-booking/ticket-booking.component';
import { HomeComponent } from './home/home.component';
import { TicketsMainComponent } from './tickets-main/tickets-main.component';
import { BookingForSeatComponent } from './booking-for-seat/booking-for-seat.component';
import { MoviesDetailedComponent } from './movies-detailed/movies-detailed.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    NavbarComponent,
    MoviesComponent,
    TicketBookingComponent,
    HomeComponent,
    TicketsMainComponent,
    BookingForSeatComponent,
    MoviesDetailedComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
