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

  constructor(private _url: AUrlService) { }


  ngOnInit(): void {
  }

  addBooking() {
    this._url.add(this.booking).subscribe({
      next: () => {
        console.log('Booking added successfully');
        // Redirect to the bookings page (optional)
      },
      error: (err) => console.error('Error adding booking', err)
    });
  }



}
