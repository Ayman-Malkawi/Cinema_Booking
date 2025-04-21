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
import { ShowTimingComponent } from './adnan/show-timing/show-timing.component';
import { SeatSelectionComponent } from './adnan/seat-selection/seat-selection.component';
import { PaymentComponent } from './adnan/payment/payment.component';
import { ETicketComponent } from './adnan/e-ticket/e-ticket.component';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule } from '@angular/forms';
import { AddRatingForMoviesComponent } from './add-rating-for-movies/add-rating-for-movies.component';
import { FaqComponent } from './faq/faq.component';
import { TermsComponent } from './terms/terms.component';
import { SideBarComponent } from './Admin/side-bar/side-bar.component';
import { DashBoardComponent } from './Admin/dash-board/dash-board.component';
import { AdminLayoutComponent } from './Admin/admin-layout/admin-layout.component';
import { UsersComponent } from './Admin/users/users.component';
import { CategoryComponent } from './Admin/category/category.component';
import { AddCategoryComponent } from './Admin/add-category/add-category.component';
import { EditCategoryComponent } from './Admin/edit-category/edit-category.component';
import { RouterModule } from '@angular/router';
import { ManageMovieComponent } from './Admin/manage-movie/manage-movie.component';
import { AddMoviesComponent } from './Admin/add-movies/add-movies.component';
import { EditMoviesComponent } from './Admin/edit-movies/edit-movies.component';
import { ShowFeedBackComponent } from './Admin/show-feedback/show-feed-back.component';
import { AddRoomsComponent } from './Admin/add-rooms/add-rooms.component';
import { ShowAllRoomsComponent } from './Admin/show-all-rooms/show-all-rooms.component';
import { RoomAvailabilityComponent } from './Admin/room-availability/room-availability.component';

import { PrivateRoomComponent } from './Admin/private-room/private-room.component';
import { AddPrivateBookComponent } from './Admin/add-private-book/add-private-book.component';
import { PrivateRoomsComponent } from './Admin/private-rooms/private-rooms.component';
import { AddPrivateRoomComponent } from './Admin/add-private-room/add-private-room.component';
import { ManageRoomAvailabilityComponent } from './Admin/manage-room-availability/manage-room-availability.component';
import { PrivateBookingListComponent } from './Admin/private-booking-list/private-booking-list.component';



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
    ShowTimingComponent,
    SeatSelectionComponent,
    PaymentComponent,
    ETicketComponent,
    
    
    ProfileComponent,
    AddRatingForMoviesComponent,
    FaqComponent,
    TermsComponent,
    SideBarComponent,
    DashBoardComponent,
    AdminLayoutComponent,
    UsersComponent,
    CategoryComponent,
    AddCategoryComponent,
    EditCategoryComponent,
    ManageMovieComponent,
    AddMoviesComponent,
    EditMoviesComponent,
    ShowFeedBackComponent,
    AddRoomsComponent,
    ShowAllRoomsComponent,
    RoomAvailabilityComponent,
    PrivateRoomComponent,
    AddPrivateBookComponent,
    PrivateRoomsComponent,
    AddPrivateRoomComponent,
    ManageRoomAvailabilityComponent,
    PrivateBookingListComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
   , RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
