//import { Component, OnInit } from '@angular/core';
//import { UrlService } from '../ClientService/url.service';
//import { Router } from '@angular/router';


//@Component({
//  selector: 'app-movies',
//  templateUrl: './movies.component.html',
//  styleUrls: ['./movies.component.css']
//})
//export class MoviesComponent implements OnInit {
//  moviecontunier: any[] = [];
//  categories: any[] = [];

//  constructor(private _ser: UrlService, private router: Router) { }


//  ngOnInit() {
//    this.getAllMovies();
//    this.getAllCategories();
//  }

//  getAllMovies() {
//    this._ser.getAllMovies().subscribe((data: any) => {
//      this.moviecontunier = data;
//    });
//  }

//  getAllCategories() {
//    this._ser.getAllCategories().subscribe((data: any) => {
//      this.categories = data;
//    });
//  }

//  onCategoryChange(event: Event): void {
//    const selectedCategoryId = +(event.target as HTMLSelectElement).value;

//    if (selectedCategoryId == 0) {
//      this.getAllMovies();
//    } else {
//      this._ser.getMoviesByCategory(selectedCategoryId).subscribe((data: any) => {
//        this.moviecontunier = data;
//      });
//    }
//  }
//  goToShowTiming(movieId: number) {
//    const userId = sessionStorage.getItem('userId');
//    if (!userId) {
//      alert('You must be logged in to book a movie!');
//      return;
//    }

//    // ممكن تمرر movieId و userId بالـ query params إذا بدك
//    this.router.navigate(['/showTiming'], { queryParams: { movieId, userId } });
//  }

//}

import { Component, OnInit } from '@angular/core';
import { UrlService } from '../ClientService/url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  moviecontunier: any[] = [];
  categories: any[] = [];

  constructor(private _ser: UrlService, private router: Router) { }

  ngOnInit() {
    this.getAllMovies();
    this.getAllCategories();
  }

  getAllMovies() {
    this._ser.getAllMovies().subscribe((data: any) => {
      this.moviecontunier = data;
    });
  }

  getAllCategories() {
    this._ser.getAllCategories().subscribe((data: any) => {
      this.categories = data;
    });
  }

  onCategoryChange(event: Event): void {
    const selectedCategoryId = +(event.target as HTMLSelectElement).value;

    if (selectedCategoryId == 0) {
      this.getAllMovies();
    } else {
      this._ser.getMoviesByCategory(selectedCategoryId).subscribe((data: any) => {
        this.moviecontunier = data;
      });
    }
  }

  goToShowTiming(movieId: number) {
    const userId = sessionStorage.getItem('userId');
    if (!userId) {
      alert('You must be logged in to book a movie!');
      return;
    }

    this.router.navigate(['/showTiming'], { queryParams: { movieId, userId } });
  }

}
