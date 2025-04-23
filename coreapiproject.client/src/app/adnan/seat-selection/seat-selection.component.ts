//import { Component, OnInit } from '@angular/core';
//import { Router } from '@angular/router';
//import { HttpClient } from '@angular/common/http';
//import { BookingService } from '../service/booking.service';

//@Component({
//  selector: 'app-seat-selection',
//  templateUrl: './seat-selection.component.html',
//  styleUrls: ['./seat-selection.component.css']
//})
//export class SeatSelectionComponent implements OnInit {

//  selection: any;
//  selectedSeats: string[] = [];
//  seatsPerRow = 10;
//  totalRows = 6;
//  seatPrice = 6;

//  constructor(private router: Router, private bookingService: BookingService) { }

//  ngOnInit(): void {
//    const stored = localStorage.getItem('bookingSelection');
//    if (stored) {
//      this.selection = JSON.parse(stored);
//    }
//  }

//  toggleSeat(seat: string): void {
//    const index = this.selectedSeats.indexOf(seat);
//    if (index === -1) {
//      if (this.selectedSeats.length < 3) {
//        this.selectedSeats.push(seat);
//      } else {
//        alert("⚠️ You can select up to 3 seats only.");
//      }
//    } else {
//      this.selectedSeats.splice(index, 1);
//    }
//  }

//  getTotalPrice(): number {
//    return this.selectedSeats.length * this.seatPrice;
//  }

//  //proceedToPayment(): void {
//  //  if (!this.selection) return;

//  //  const fullBooking = {
//  //    userId: this.selection.userId,
//  //    roomId: this.selection.roomId,
//  //    movieId: this.selection.movieId,
//  //    startTime: this.selection.startTime,
//  //    endTime: this.selection.endTime,
//  //    seat1: this.selectedSeats[0] || null,
//  //    seat2: this.selectedSeats[1] || null,
//  //    seat3: this.selectedSeats[2] || null,
//  //    totalPrice: this.getTotalPrice(),
//  //    paymentStatus: 'Pending',
//  //    paymentMethod: 'Credit Card'
//  //  };

//  //  this.bookingService.createBooking(fullBooking).subscribe({
//  //    next: (res) => {
//  //      localStorage.setItem('bookingWithSeats', JSON.stringify(res));
//  //      this.router.navigate(['/payment']);
//  //    },
//  //    error: (err) => {
//  //      console.error("❌ Booking error:", err);
//  //      alert("Something went wrong while saving the booking.");
//  //    }
//  //  });
//  //}
//  proceedToPayment(): void {
//    const fullBooking = {
//      userId: this.selection.userId,
//      roomId: this.selection.roomId,
//      movieId: this.selection.movieId,
//      startTime: this.selection.startTime,
//      endTime: this.selection.endTime,
//      seat1: this.selectedSeats[0] || null,
//      seat2: this.selectedSeats[1] || null,
//      seat3: this.selectedSeats[2] || null,
//      totalPrice: this.getTotalPrice(),
//      paymentStatus: 'Pending',
//      paymentMethod: 'Credit Card'
//    };

//    this.bookingService.createBooking(fullBooking).subscribe({
//      next: (res) => {
//        console.log("✅ Booking saved:", res);
//        localStorage.setItem('bookingWithSeats', JSON.stringify(res)); // احفظ الاستجابة
//        this.router.navigate(['/payment']);
//      },
//      error: (err) => {
//        console.error("❌ Failed to save booking:", err);
//        alert("Something went wrong while saving the booking.");
//      }
//    });
//  }

//}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BookingService } from '../service/booking.service';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.css']
})
export class SeatSelectionComponent implements OnInit {

  selection: any;
  selectedSeats: string[] = [];
  seatsPerRow = 10;
  totalRows = 6;
  seatPrice = 6;

  constructor(private router: Router, private bookingService: BookingService) { }

  ngOnInit(): void {
    const stored = localStorage.getItem('bookingSelection');
    if (stored) {
      this.selection = JSON.parse(stored);
    } else {
      alert('No booking selection found. Please select a showtime first.');
      this.router.navigate(['/showTiming']);
    }
  }

  toggleSeat(seat: string): void {
    const index = this.selectedSeats.indexOf(seat);
    if (index === -1) {
      if (this.selectedSeats.length < 3) {
        this.selectedSeats.push(seat);
      } else {
        alert("⚠️ You can select up to 3 seats only.");
      }
    } else {
      this.selectedSeats.splice(index, 1);
    }
  }

  getTotalPrice(): number {
    return this.selectedSeats.length * this.seatPrice;
  }

  proceedToPayment(): void {
    if (!this.selection) {
      alert("Booking information is incomplete.");
      return;
    }

    const fullBooking = {
      userId: this.selection.userId,
      roomId: this.selection.roomId,
      movieId: this.selection.movieId,
      startTime: this.selection.startTime,
      endTime: this.selection.endTime,
      seat1: this.selectedSeats[0] || null,
      seat2: this.selectedSeats[1] || null,
      seat3: this.selectedSeats[2] || null,
      totalPrice: this.getTotalPrice(),
      paymentStatus: 'Pending',
      paymentMethod: 'Credit Card'
    };

    this.bookingService.createBooking(fullBooking).subscribe({
      next: (res) => {
        console.log("✅ Booking saved:", res);
        localStorage.setItem('bookingWithSeats', JSON.stringify(res));
        this.router.navigate(['/payment']);
      },
      error: (err) => {
        console.error("❌ Failed to save booking:", err);
        alert("Something went wrong while saving the booking.");
      }
    });
  }

}

