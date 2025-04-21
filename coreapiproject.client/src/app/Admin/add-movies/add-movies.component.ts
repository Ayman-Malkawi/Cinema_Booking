import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-movies',
  templateUrl: './add-movies.component.html',
  styleUrl: './add-movies.component.css'
})
export class AddMoviesComponent {
  movie: any = {};  
  categories: any;

  constructor(private _url: AUrlService, private router: Router) { }

  ngOnInit(): void {
    this._url.getCategories().subscribe((data: any[]) => {
      this.categories = data;
    });
  }





  addMovie(): void {
    // تحويل البيانات إلى الأنواع المناسبة
    const movieToSubmit = {
      ...this.movie,
      categoryId: +this.movie.categoryId,
      duration: +this.movie.duration,
      ticketPrice: +this.movie.ticketPrice,
      rating: +this.movie.rating
    };

    console.log('Submitting movie:', movieToSubmit);

    this._url.addMovie(movieToSubmit).subscribe({
      next: (response) => {
        console.log('Response from server:', response);
        // إذا كانت الاستجابة true أو إذا كانت ناجحة بأي شكل
        alert('تمت إضافة الفيلم بنجاح!');
        this.router.navigate(['/movies']);
      },
      error: (error) => {
        console.error('Complete error object:', error);

        // محاولة استخراج رسالة خطأ أكثر فائدة
        let errorMessage = 'حدث خطأ غير معروف';

        if (error.error && typeof error.error === 'string') {
          errorMessage = error.error;
        } else if (error.message) {
          errorMessage = error.message;
        } else if (typeof error === 'string') {
          errorMessage = error;
        }

        alert(`فشل في إضافة الفيلم: ${errorMessage}`);
      }
    });
  }

}
