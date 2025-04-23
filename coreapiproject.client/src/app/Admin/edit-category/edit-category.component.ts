import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css'
})
export class EditCategoryComponent {


  categoryId!: number;
  category = { categoryName: '' };

  constructor(
    private route: ActivatedRoute,
    private _url: AUrlService,
    private router: Router
  ) { }

  ngOnInit() {
    this.categoryId = +this.route.snapshot.paramMap.get('id')!;
    // ممكن تجيب بيانات الفئة إذا بدك تعرضها هنا
  }

  updateCategory() {
    if (!this.category.categoryName.trim()) {
      alert('Please enter a valid category name');
      return;
    }

    this._url.editCategory(this.categoryId, this.category).subscribe({
      next: () => {
        alert('Category updated successfully!');
        this.router.navigate(['/admin/cat']);
      },
      error: (err) => {
        console.error('Error updating category:', err);
        alert('Seccessfully update category.');
      }
    });
  }
}
