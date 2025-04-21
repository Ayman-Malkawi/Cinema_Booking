import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {


  private baseUrl = 'https://localhost:7057/api';

  constructor(private http: HttpClient) { }

  // GET /api/ShowTimes
  getShowTimings(): Observable<any> {
    return this.http.get(`${this.baseUrl}/ShowTimes`);
  }

  // POST /api/Booking/Create
  createBooking(booking: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Booking/Create`, booking);
  }

  // GET /api/Booking/MyBookings/{userId}
  getMyBookings(userId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/Booking/MyBookings/${userId}`);
  }

  // PUT /api/Booking/Cancel/{id}
  cancelBooking(id: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/Booking/Cancel/${id}`, {});
  }

  // POST /api/Payment/Create
  createPayment(payment: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Payment/Create`, payment);
  }

  // GET /api/Payment/ByBooking/{bookingId}
  getPaymentByBooking(bookingId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/Payment/ByBooking/${bookingId}`);
  }

}
