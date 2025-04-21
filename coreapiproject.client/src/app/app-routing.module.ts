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
import { ShowTimingComponent } from './adnan/show-timing/show-timing.component';
import { SeatSelectionComponent } from './adnan/seat-selection/seat-selection.component';
import { PaymentComponent } from './adnan/payment/payment.component';
import { ETicketComponent } from './adnan/e-ticket/e-ticket.component';


const routes: Routes = [

  { path: "", component: HomeComponent },
  { path: "movie", component: MoviesComponent },

  { path: "Ticket", component: MovieTicketComponent },

  { path: "Contact", component: ContactUsComponent },

  { path: "LogIn", component: LogInComponent },

  { path: "Checkout", component: CheckOutComponent },


  { path: "About", component: AboutUsComponent },

  { path: "Booking", component: BookingForSeatComponent },

  { path: "register", component: RegisterComponent },
  { path: "showTiming", component: ShowTimingComponent },
  { path: "seat-selection", component: SeatSelectionComponent },
  { path: "payment", component: PaymentComponent },
  { path: "ticket", component: ETicketComponent }
  


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
