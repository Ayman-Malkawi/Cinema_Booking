import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-private-booking-list',
  templateUrl: './private-booking-list.component.html',
  styleUrl: './private-booking-list.component.css'
})
export class PrivateBookingListComponent {
  bookings: any[] = [];

  constructor(private aUrlService: AUrlService) { }

  ngOnInit(): void {
    this.aUrlService.getAllPrivateBookings().subscribe({
      next: (data) => {
        this.bookings = data;
        console.log('تم جلب الحجوزات:', this.bookings);
      },
      error: (err) => {
        console.error('فشل في تحميل الحجوزات:', err);
      }
    });
  }
}
