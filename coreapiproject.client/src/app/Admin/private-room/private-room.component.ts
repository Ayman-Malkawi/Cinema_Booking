import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

export interface PrivateBookingDTO {
  id: number;
  userId: number;
  privateRoomId: number;
  movieId: number;
  startTime: string;
  endTime: string;
  totalPrice: number;
  paymentMethod: string;
}


@Component({
  selector: 'app-private-room',
  templateUrl: './private-room.component.html',
  styleUrl: './private-room.component.css'
})
export class PrivateRoomComponent {

  bookings: PrivateBookingDTO[] = [];
  newBooking: PrivateBookingDTO = {
    id: 0,
    userId: 0,
    privateRoomId: 0,
    movieId: 0,
    startTime: '',
    endTime: '',
    totalPrice: 0,
    paymentMethod: ''
  };
  constructor(private _url: AUrlService) { }

  ngOnInit(): void {
    this.loadBookings();
  }


  loadBookings() {
    this._url.getAll().subscribe({
      next: (data) => {
        console.log(data);  // Add this line to see the data in the console
        this.bookings = data;
      },
      error: (err) => console.error('Error loading bookings', err)
    });
  }





  deleteBooking(id: number) {
    this._url.delete(id).subscribe(() => {
      this.bookings = this.bookings.filter(b => b.id !== id);
    });
  }

}
