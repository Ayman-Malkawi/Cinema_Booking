import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-rooms',
  templateUrl: './add-rooms.component.html',
  styleUrls: ['./add-rooms.component.css']
})
export class AddRoomsComponent {
  // متغيرات تحميل الصورة
  selectedFile: File | null = null;
  previewUrl: string | ArrayBuffer | null = null;
  isDragging = false;

  constructor(private _ser: AUrlService) { }
  Add_Room(form: NgForm) {
    if (form.valid) {
      this._ser.AddNewRoom(form.value).subscribe({
        next: () => {
          alert("Room added successfully!");
          form.resetForm();
        },
        error: (err) => {
          console.error('Error:', err);
          alert("Failed to add room");
        }
      });
    }
  }

  //// دالة إضافة الغرفة
  //Add_Room(form: NgForm) {
  //  if (form.valid && this.selectedFile) {
  //    const formData = new FormData();
  //    formData.append('RoomName', form.value.RoomName);
  //    formData.append('Capacity', form.value.Capacity);
  //    formData.append('RoomDescription', form.value.RoomDescription);
  //    formData.append('RoomImage', this.selectedFile);

  //    this._ser.AddNewRoom(formData).subscribe({
  //      next: () => {
  //        alert("Room added successfully!");
  //        this.resetForm(form);
  //      },
  //      error: (err) => {
  //        console.error('Error adding room:', err);
  //        alert("Error occurred while adding room");
  //      }
  //    });
  //  } else {
  //    alert("Please fill all required fields and select an image");
  //  }
  //}

  // دالة معالجة اختيار الملف
  onFileSelected(event: any): void {
    const file = event.target.files[0];
    this.processFile(file);
  }

  // دالة معالجة السحب والإفلات
  onDrop(event: DragEvent): void {
    event.preventDefault();
    this.isDragging = false;
    const file = event.dataTransfer?.files[0];
    if (file) this.processFile(file);
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    this.isDragging = true;
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    this.isDragging = false;
  }

  // دالة مشتركة لمعالجة الملفات
  private processFile(file: File): void {
    if (file && file.type.match(/image\/*/)) {
      this.selectedFile = file;
      const reader = new FileReader();
      reader.onload = () => {
        this.previewUrl = reader.result;
      };
      reader.readAsDataURL(file);
    } else {
      alert('Please select a valid image file (JPEG, PNG)');
    }
  }

  // دالة إعادة تعيين النموذج
  private resetForm(form: NgForm): void {
    form.resetForm();
    this.selectedFile = null;
    this.previewUrl = null;
  }
}
