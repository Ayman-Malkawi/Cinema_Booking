import { Component } from '@angular/core';
import { PrivateBookingDTO } from '../private-room/private-room.component';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-add-private-book',
  templateUrl: './add-private-book.component.html',
  styleUrl: './add-private-book.component.css'
})
export class AddPrivateBookComponent {

  booking: PrivateBookingDTO = {
    id: 0,
    userId: 0,
    privateRoomId: 0,
    movieId: 0,
    startTime: '',
    endTime: '',
    totalPrice: 0,
    paymentMethod: ''
  };

  // New properties for dropdown data
  availableRooms: any[] = [];
  availableMovies: any[] = [];



  constructor(private _url: AUrlService) { }


  ngOnInit(): void {
    // Fetch rooms for the dropdown
    this._url.getAll().subscribe({
      next: (rooms) => {
        this.availableRooms = rooms;
      },
      error: (err) => console.error('Error fetching rooms', err)
    });

    // Fetch movies for the dropdown
    this._url.getAllMovies().subscribe({
      next: (movies) => {
        this.availableMovies = movies;
      },
      error: (err) => console.error('Error fetching movies', err)
    });
  }

  addBooking() {
    this._url.add(this.booking).subscribe({
      next: () => {
        console.log('Booking added successfully');
        // Reset form or redirect
        this.resetForm();
      },
      error: (err) => console.error('Error adding booking', err)
    });
  }

  resetForm() {
    this.booking = {
      id: 0,
      userId: 0,
      privateRoomId: 0,
      movieId: 0,
      startTime: '',
      endTime: '',
      totalPrice: 0,
      paymentMethod: ''
    };
  }



}
