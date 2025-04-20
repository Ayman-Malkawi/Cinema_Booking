import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MoviesComponent } from './movies/movies.component';
import { TicketBookingComponent } from './ticket-booking/ticket-booking.component';
import { HomeComponent } from './home/home.component';
import { BookingForSeatComponent } from './booking-for-seat/booking-for-seat.component';
import { MoviesDetailedComponent } from './movies-detailed/movies-detailed.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { MovieTicketComponent } from './movie-ticket/movie-ticket.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { LogInComponent } from './log-in/log-in.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { RegisterComponent } from './register/register.component';
import { FaqComponent } from './faq/faq.component';
import { TermsComponent } from './terms/terms.component';

@NgModule({
  declarations: [
    AppComponent,

    MoviesComponent,
    TicketBookingComponent,
    HomeComponent,
    BookingForSeatComponent,
    MoviesDetailedComponent,
    NavBarComponent,
    FooterComponent,
    MovieTicketComponent,
    ContactUsComponent,
    LogInComponent,
    CheckOutComponent,
    AboutUsComponent,
    RegisterComponent,
    FaqComponent,
    TermsComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
