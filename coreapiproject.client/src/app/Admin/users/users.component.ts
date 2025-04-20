import { Component, OnInit } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  allUser: any[] = []; // 👈 نستخدم هنا allUser لتخزين البيانات

  constructor(private _url: AUrlService) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  fetchUsers() {
    this._url.GetAllUsers().subscribe((data: any[]) => {
      console.log(data);  // تحقق من البيانات التي تصل من الـ API
      this.allUser = data;
    });
  }


}
