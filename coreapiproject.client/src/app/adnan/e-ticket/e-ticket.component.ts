import { Component } from '@angular/core';

@Component({
  selector: 'app-e-ticket',
  templateUrl: './e-ticket.component.html',
  styleUrl: './e-ticket.component.css'
})
export class ETicketComponent {

  bookingData: any;

  ngOnInit(): void {
    const stored = localStorage.getItem('bookingWithSeats');
    if (stored) {
      this.bookingData = JSON.parse(stored);
    }
  }

}
