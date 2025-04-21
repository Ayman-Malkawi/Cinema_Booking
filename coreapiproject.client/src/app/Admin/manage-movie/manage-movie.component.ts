import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-movie',
  templateUrl: './manage-movie.component.html',
  styleUrl: './manage-movie.component.css'
})
export class ManageMovieComponent {


  movies: any;

  constructor(private _url: AUrlService, private router: Router) { }

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies(): void {
    this._url.getAllMovies().subscribe(movies => {
      this.movies = movies;
    });
  }


  editMovie(id: number): void {
    this.router.navigate([`/edit-movie/${id}`]);  // الانتقال إلى صفحة التعديل مع ID الفيلم
  }


  // تبديل حالة "Viable" للفيلم
  toggleViable(id: number): void {
    this._url.toggleViable(id).subscribe(() => {
      this.loadMovies();  // إعادة تحميل الأفلام بعد التغيير
    });
  }

  navigateToEditMovie(movie: any): void {
    console.log('الموفي المستلم:', movie);
    if (movie && movie.id) {
      console.log('Navigating to edit movie with ID:', movie.id);
      this.router.navigate(['/admin/edit-movie', movie.id]);
    } else {
      console.error('Movie ID is undefined', movie);
      alert('Cannot edit: Movie ID is missing');
    }
  }



}
