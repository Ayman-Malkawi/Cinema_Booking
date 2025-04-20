import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-edit-movies',
  templateUrl: './edit-movies.component.html',
  styleUrls: ['./edit-movies.component.css']
})
export class EditMoviesComponent {

  movieId!: number;
  movie: any = {}; // مبدئيًا يظل فارغًا حتى يتم تحميل الفيلم من الـ API
  categories: any[] = [];
  constructor(
    private route: ActivatedRoute,
    private _url: AUrlService,
    private router: Router
  ) { }


  ngOnInit(): void {
    // التأكد من وجود الـ id في الـ route
    this.movieId = +this.route.snapshot.paramMap.get('id')!;  // تحويله إلى عدد صحيح
    if (!this.movieId) {
      // لو الـ id فارغ أو غير صالح، يمكنك التوجيه إلى صفحة خطأ أو عرض رسالة
      this.router.navigate(['/movies']);
    }

    // جلب كل الفئات لعرضها في الـ dropdown
    this._url.getCategories().subscribe(categories => {
      this.categories = categories;
    });



    // تحميل تفاصيل الفيلم
    this._url.getMovieById(this.movieId).subscribe(movie => {
      if (movie) {
        this.movie = movie;
      }
    });
  }

  // تحديث الفيلم عند التعديل
  editMovie(): void {
    this._url.editMovie(this.movieId, this.movie).subscribe(() => {
      this.router.navigate(['/movies']);
    });
  }
}
