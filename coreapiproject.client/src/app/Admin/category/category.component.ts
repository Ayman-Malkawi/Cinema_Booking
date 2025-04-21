import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {



  categories: any[] = [];  // مصفوفة لتخزين الفئات

  constructor(private _url: AUrlService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories() {
    this._url.getCategories().subscribe((data) => {
      console.log(data);  // يمكنك التحقق من البيانات في الـ console
      this.categories = data;
    });
  }

  deleteCategory(id: number) {
    if (confirm('Are you sure you want to delete this category?')) {
      this._url.deleteCategory(id).subscribe({
        next: () => {
          alert('Category deleted successfully!');
          this.fetchCategories(); // عشان تحدث القائمة
        },
        error: (err) => {
          console.error('Error deleting category:', err);
          alert('Failed to delete category.');
        }
      });
    }
  }


}
