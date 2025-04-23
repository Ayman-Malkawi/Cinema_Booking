import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from '../service/booking.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.css'
})
export class PaymentComponent {




  bookingData: any;
  paymentMethod: string = 'Credit Card';

  // ✅ معلومات البطاقة
  cardInfo = {
    name: '',
    number: '',
    expiry: '',
    cvv: ''
  };

  constructor(private bookingService: BookingService, private router: Router) { }

  ngOnInit(): void {
    const data = localStorage.getItem('bookingWithSeats');
    if (data) {
      this.bookingData = JSON.parse(data);
    }
  }

  submitPayment(): void {
    if (this.paymentMethod === 'Credit Card') {
      if (!this.cardInfo.name || !this.cardInfo.number || !this.cardInfo.expiry || !this.cardInfo.cvv) {
        alert('⚠️ Please fill in all credit card details.');
        return;
      }
    }

    const paymentDto = {
      bookingId: this.bookingData.id || 4,
      amount: this.bookingData.totalPrice,
      paymentMethod: this.paymentMethod,
      paymentStatus: 'Paid'
    };

    this.bookingService.createPayment(paymentDto).subscribe({
      next: res => {
        alert('✅ Payment completed!');
        this.router.navigate(['/ticket']);
      },
      error: err => {
        console.error(err);
        alert('❌ Payment failed!');
      }
    });
  }

}





////////////////
//bookingData: any;
//paymentMethod: string = '';
//cardDetails = {
//  name: '',
//  cardNumber: '',
//  expMonth: '',
//  expYear: '',
//  cvv: ''
//};

//constructor(private http: HttpClient, private router: Router) { }

//ngOnInit(): void {
//  const stored = localStorage.getItem('bookingWithSeats');
//  if (stored) {
//    this.bookingData = JSON.parse(stored);
//  }
//}

//submitPayment() {
//  const dto = {
//    bookingId: this.bookingData?.bookingId || 0, // bookingId يكون عندك بعد الحجز
//    amount: this.bookingData?.seats.length * 10, // السعر حسب عدد المقاعد
//    paymentMethod: this.paymentMethod,
//    paymentStatus: 'Paid'
//  };

//  this.http.post('https://localhost:7057/api/Payment/Create', dto).subscribe({
//    next: res => {
//      alert('Payment successful!');
//      this.router.navigate(['/ticket']);
//    },
//    error: err => {
//      alert('Payment failed');
//      console.error(err);
//    }
//  });
//}






//booking: any;
//amount: number = 0;
//paymentMethod: string = 'Credit Card';

//constructor(private bookingService: BookingService, private router: Router) { }

//ngOnInit(): void {
//  const stored = localStorage.getItem('bookingWithSeats');
//  if (stored) {
//    this.booking = JSON.parse(stored);
//    this.amount = this.booking.totalPrice;
//  }
//}

//confirmPayment(): void {
//  if (!this.booking || !this.booking.id) {
//    alert('❌ Booking data is missing!');
//    return;
//  }

//  const payment = {
//    bookingId: this.booking.id,
//    amount: this.amount,
//    paymentMethod: this.paymentMethod,
//    paymentStatus: 'Paid'
//  };

//  this.bookingService.createPayment(payment).subscribe({
//    next: (res) => {
//      alert('✅ Payment Successful!');
//      this.router.navigate(['/']);
//    },
//    error: (err) => {
//      console.error('❌ Payment failed:', err);
//      alert('Something went wrong during payment.');
//    }
//  });
//}




//bookingData: any;

//constructor(private bookingService: BookingService, private router: Router) { }

//ngOnInit(): void {
//  const data = localStorage.getItem('bookingWithSeats');
//  if (data) {
//    this.bookingData = JSON.parse(data);
//  }
//}

//submitPayment(): void {
//  const paymentDto = {
//    bookingId: this.bookingData.id || 4, // ❗ عدّل إذا عندك bookingId حقيقي من الـ backend
//    amount: this.bookingData.totalPrice,
//    paymentMethod: this.bookingData.paymentMethod || 'Credit Card',
//    paymentStatus: 'Paid'
//  };

//  this.bookingService.createPayment(paymentDto).subscribe({
//    next: res => {
//      alert('✅ Payment completed successfully!');
//      this.router.navigate(['/']); // 🔁 عدّل التوجيه حسب ما بدك
//    },
//    error: err => {
//      console.error(err);
//      alert('❌ Payment failed!');
//    }
//  });
//}




//bookingData: any;
//paymentMethod: string = 'Credit Card';

//constructor(private bookingService: BookingService, private router: Router) { }

//ngOnInit(): void {
//  const data = localStorage.getItem('bookingWithSeats');
//  if (data) {
//    this.bookingData = JSON.parse(data);
//  }
//}

//submitPayment(): void {
//  const paymentDto = {
//    bookingId: this.bookingData.id || 4, // ❗ تأكد إنو bookingId حقيقي
//    amount: this.bookingData.totalPrice,
//    paymentMethod: this.paymentMethod,
//    paymentStatus: 'Paid'
//  };

//  this.bookingService.createPayment(paymentDto).subscribe({
//    next: res => {
//      alert('✅ Payment completed!');
//      this.router.navigate(['/']);
//    },
//    error: err => {
//      console.error(err);
//      alert('❌ Payment failed!');
//    }
//  });
//}

