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
import { ProfileComponent } from './profile/profile.component';
import { AddRatingForMoviesComponent } from './add-rating-for-movies/add-rating-for-movies.component';
import { FaqComponent } from './faq/faq.component';
import { TermsComponent } from './terms/terms.component';
import { DashBoardComponent } from './Admin/dash-board/dash-board.component';
import { AdminLayoutComponent } from './Admin/admin-layout/admin-layout.component';
import { UsersComponent } from './Admin/users/users.component';
import { CategoryComponent } from './Admin/category/category.component';
import { EditCategoryComponent } from './Admin/edit-category/edit-category.component';
import { AddCategoryComponent } from './Admin/add-category/add-category.component';
import { ManageMovieComponent } from './Admin/manage-movie/manage-movie.component';
import { EditMoviesComponent } from './Admin/edit-movies/edit-movies.component';
import { AddMoviesComponent } from './Admin/add-movies/add-movies.component';
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
  { path: "profile", component: ProfileComponent },
  { path: 'addRatingFormovies/:id', component:AddRatingForMoviesComponent },

  { path: "register", component: RegisterComponent },

  { path: "faq", component: FaqComponent },

  { path: "Terms", component: TermsComponent },
  { path: "register", component: RegisterComponent },


  {
    path: "admin", component: AdminLayoutComponent,
    children: [
     
      { path: "dashboard", component: DashBoardComponent },
      { path: "users", component: UsersComponent },
      { path: "cat", component: CategoryComponent },
      { path: "add-category", component: AddCategoryComponent },
      { path: "edit-category/:id", component: EditCategoryComponent },
      { path: "ManageMovie", component: ManageMovieComponent },
      { path: "add-movie", component: AddMoviesComponent },
      { path: "edit-movie/:id", component: EditMoviesComponent },
      { path: "Contact", component: ShowFeedBackComponent },
      { path: "AddRoom", component: AddRoomsComponent },
      { path: "ShowAllRoom", component: ShowAllRoomsComponent },
      { path: "RoomAvailability/:id", component: RoomAvailabilityComponent }
      //{ path: "privateRoomBook", component: PrivateRoomComponent },
     , { path: "addRooms", component: AddPrivateBookComponent },
      { path: "privateRooms", component: PrivateRoomsComponent },
      { path: "AddPrivateRooms", component: AddPrivateRoomComponent },
      { path: 'manage-availability/:id', component: ManageRoomAvailabilityComponent },
      { path: 'privateRoomBook', component: PrivateBookingListComponent }



    ]
  }




 , { path: "register", component: RegisterComponent },
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
