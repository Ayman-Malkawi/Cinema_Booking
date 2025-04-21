import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-rating-for-movies',
  templateUrl: './add-rating-for-movies.component.html',
  styleUrls: ['./add-rating-for-movies.component.css']
})
export class AddRatingForMoviesComponent implements OnInit {
  movieId: number = 0;
  userId: number = 1;
  selectedRating: number = 0;
  comment: string = '';
  movieTitle: string = '';

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.movieId = +this.route.snapshot.params['id'];

    const sessionUser = sessionStorage.getItem('userId');
    if (sessionUser) {
      this.userId = +sessionUser;
    }

    this.getMovieTitle();
  }

  movies: any[] = []; // هذا متغير جديد

  getMovieTitle() {
    this.http.get<any[]>('https://localhost:7057/api/Users/GetAllMovies').subscribe({
      next: (movies) => {
        this.movies = movies;
        const movie = movies.find(m => m.id === this.movieId);
        this.movieTitle = movie ? movie.title : 'Unknown Movie';
      },
      error: (err) => {
        console.error('Failed to load movie title:', err);
        this.movieTitle = 'Unknown Movie';
      }
    });
  }


  selectRating(rating: number) {
    this.selectedRating = rating;
  }

  submitRating() {
    if (this.selectedRating === 0 || !this.comment.trim()) {
      alert("❌ Please provide a rating and comment.");
      return;
    }

    const payload = {
      userId: this.userId,
      movieId: this.movieId,
      rating: this.selectedRating,
      reviewText: this.comment
    };

    this.http.post('https://localhost:7057/api/Users/addRating', payload).subscribe({
      next: () => {
        alert("✅ Thank you for your review!");
        this.selectedRating = 0;
        this.comment = '';
      },
      error: (err) => {
        console.error(err);
        alert("❌ Failed to submit rating.");
      }
    });
  }
}
