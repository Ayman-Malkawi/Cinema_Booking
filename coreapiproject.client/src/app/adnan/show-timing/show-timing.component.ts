//import { Component, OnInit } from '@angular/core';
//import { Router } from '@angular/router';
//import { BookingService } from '../service/booking.service';

//@Component({
//  selector: 'app-show-timing',
//  templateUrl: './show-timing.component.html',
//  styleUrls: ['./show-timing.component.css']
//})
//export class ShowTimingComponent implements OnInit {

//  selectedDate: Date = new Date();
//  days: { label: string, date: Date }[] = [];
//  screens: { screen: string, times: string[] }[] = [];

//  selectedTime: string | null = null;
//  selectedScreen: string | null = null;

//  constructor(private router: Router, private bookingService: BookingService) { }

//  ngOnInit(): void {
//    this.generateDays();
//    this.loadScreens();
//  }

//  generateDays(): void {
//    const today = new Date();
//    for (let i = 0; i < 7; i++) {
//      const date = new Date();
//      date.setDate(today.getDate() + i);
//      const label = i === 0 ? 'TODAY' : date.toLocaleDateString('en-US', { weekday: 'short', day: 'numeric' });
//      this.days.push({ label, date });
//    }
//  }

//  loadScreens(): void {
//    this.bookingService.getShowTimings().subscribe(data => {
//      this.screens = data;
//    });
//  }

//  selectTime(screen: string, time: string): void {
//    this.selectedScreen = screen;
//    this.selectedTime = time;
//  }

//  continueBooking(): void {
//    if (this.selectedTime && this.selectedScreen) {
//      const dateFromStorage = new Date(this.selectedDate); // تحويل من string إلى Date

//      const [hours, minutes] = this.selectedTime.split(':');
//      const startTime = new Date(dateFromStorage);
//      startTime.setHours(parseInt(hours), parseInt(minutes));

//      const endTime = new Date(startTime);
//      endTime.setHours(startTime.getHours() + 2); // add 2 hours

//      const selection = {
//        userId: 1, // لاحقًا خذه من Session
//        movieId: 1, // لاحقًا خذه من الفيلم المحدد
//        roomId: 1,  // لاحقًا خذه من القاعة
//        screen: this.selectedScreen,
//        date: dateFromStorage.toISOString(),
//        time: this.selectedTime,
//        startTime: startTime.toISOString(),
//        endTime: endTime.toISOString()
//      };

//      localStorage.setItem('bookingSelection', JSON.stringify(selection));
//      this.router.navigate(['/seat-selection']);
//    } else {
//      alert('Please select a show time before continuing.');
//    }
//  }




//}

//import { Component, OnInit } from '@angular/core';
//import { ActivatedRoute, Router } from '@angular/router';
//import { BookingService } from '../service/booking.service';

//@Component({
//  selector: 'app-show-timing',
//  templateUrl: './show-timing.component.html',
//  styleUrls: ['./show-timing.component.css']
//})
//export class ShowTimingComponent implements OnInit {

//  selectedDate: Date = new Date();
//  days: { label: string, date: Date }[] = [];
//  screens: { screen: string, times: string[] }[] = [];

//  selectedTime: string | null = null;
//  selectedScreen: string | null = null;

//  movieId: number = 0;

//  constructor(
//    private router: Router,
//    private bookingService: BookingService,
//    private route: ActivatedRoute
//  ) { }

//  ngOnInit(): void {
//    this.route.queryParams.subscribe(params => {
//      this.movieId = +params['movieId'];
//    });

//    this.generateDays();
//    this.loadScreens();
//  }

//  generateDays(): void {
//    const today = new Date();
//    for (let i = 0; i < 7; i++) {
//      const date = new Date();
//      date.setDate(today.getDate() + i);
//      const label = i === 0 ? 'TODAY' : date.toLocaleDateString('en-US', { weekday: 'short', day: 'numeric' });
//      this.days.push({ label, date });
//    }
//  }

//  loadScreens(): void {
//    this.bookingService.getShowTimings().subscribe(data => {
//      this.screens = data;
//    });
//  }

//  selectTime(screen: string, time: string): void {
//    this.selectedScreen = screen;
//    this.selectedTime = time;
//  }

//  continueBooking(): void {
//    if (this.selectedTime && this.selectedScreen) {
//      const userId = +(sessionStorage.getItem('userId') || 0);
//      if (!userId) {
//        alert('You must be logged in!');
//        return;
//      }

//      const dateFromStorage = new Date(this.selectedDate);

//      const [hours, minutes] = this.selectedTime.split(':');
//      const startTime = new Date(dateFromStorage);
//      startTime.setHours(parseInt(hours), parseInt(minutes));

//      const endTime = new Date(startTime);
//      endTime.setHours(startTime.getHours() + 2);

//      const selection = {
//        userId: userId,
//        movieId: this.movieId,
//        roomId: 1,
//        screen: this.selectedScreen,
//        date: dateFromStorage.toISOString(),
//        time: this.selectedTime,
//        startTime: startTime.toISOString(),
//        endTime: endTime.toISOString()
//      };

//      localStorage.setItem('bookingSelection', JSON.stringify(selection));
//      this.router.navigate(['/seat-selection']);
//    } else {
//      alert('Please select a show time before continuing.');
//    }
//  }
//}



import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingService } from '../service/booking.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-show-timing',
  templateUrl: './show-timing.component.html',
  styleUrls: ['./show-timing.component.css']
})
export class ShowTimingComponent implements OnInit {

  selectedDate: Date = new Date();
  days: { label: string, date: Date }[] = [];
  screens: { screen: string, times: string[] }[] = [];

  selectedTime: string | null = null;
  selectedScreen: string | null = null;

  movieId: number = 0;
  movieTitle: string = '';
  userId: number = 0;

  constructor(
    private router: Router,
    private bookingService: BookingService,
    private route: ActivatedRoute,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.movieId = +params['movieId'];
      this.userId = +params['userId'] || +(sessionStorage.getItem('userId') || 0);
      this.fetchMovieTitle(this.movieId);
    });

    this.generateDays();
    this.loadScreens();
  }

  fetchMovieTitle(id: number): void {
    this.http.get<any>(`https://localhost:7057/api/Users/GetAllMovies`).subscribe(movies => {
      const selectedMovie = movies.find((m: any) => m.id === id);
      this.movieTitle = selectedMovie ? selectedMovie.title : 'Unknown Movie';
    });
  }

  generateDays(): void {
    const today = new Date();
    for (let i = 0; i < 7; i++) {
      const date = new Date();
      date.setDate(today.getDate() + i);
      const label = i === 0 ? 'TODAY' : date.toLocaleDateString('en-US', { weekday: 'short', day: 'numeric' });
      this.days.push({ label, date });
    }
  }

  loadScreens(): void {
    this.bookingService.getShowTimings().subscribe(data => {
      this.screens = data;
    });
  }

  selectTime(screen: string, time: string): void {
    this.selectedScreen = screen;
    this.selectedTime = time;
  }

  continueBooking(): void {
    if (this.selectedTime && this.selectedScreen) {
      if (!this.userId) {
        alert('You must be logged in!');
        return;
      }

      const dateFromStorage = new Date(this.selectedDate);
      const [hours, minutes] = this.selectedTime.split(':');
      const startTime = new Date(dateFromStorage);
      startTime.setHours(parseInt(hours), parseInt(minutes));

      const endTime = new Date(startTime);
      endTime.setHours(startTime.getHours() + 2);

      const selection = {
        userId: this.userId,
        movieId: this.movieId,
        movieTitle: this.movieTitle,
        roomId: 1,
        screen: this.selectedScreen,
        date: dateFromStorage.toISOString(),
        time: this.selectedTime,
        startTime: startTime.toISOString(),
        endTime: endTime.toISOString()
      };

      localStorage.setItem('bookingSelection', JSON.stringify(selection));
      this.router.navigate(['/seat-selection']);
    } else {
      alert('Please select a show time before continuing.');
    }
  }
}
