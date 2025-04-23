import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {

  category = { categoryName: '' };

  constructor(private _url: AUrlService, private router: Router) { }

  addCategory() {
    if (!this.category.categoryName.trim()) {
      alert('Please enter a category name');
      return;
    }

    this._url.addCategory(this.category).subscribe({
      next: (res) => {
        console.log('Category added response:', res);
        alert(`Category "${this.category.categoryName}" added successfully!`);
        this.category.categoryName = ''; // Reset the form
        this.router.navigate(['/admin/cat']);
      },
      error: (err) => {
        console.error('Error adding category:', err);
        alert('Added Successfully');
      }
    });
  }


}
