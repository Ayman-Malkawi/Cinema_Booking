import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { HomeComponent } from './home/home.component';
import { MovieTicketComponent } from './movie-ticket/movie-ticket.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { LogInComponent } from './log-in/log-in.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { BookingForSeatComponent } from './booking-for-seat/booking-for-seat.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [

  { path: "", component: HomeComponent },
  { path: "movie", component: MoviesComponent },

  { path: "Ticket", component: MovieTicketComponent },

  { path: "Contact", component: ContactUsComponent },

  { path: "LogIn", component: LogInComponent },

  { path: "Checkout", component: CheckOutComponent },


  { path: "About", component: AboutUsComponent },

  { path: "Booking", component: BookingForSeatComponent },

  { path: "register", component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
