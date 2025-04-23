//import { Component } from '@angular/core';
//import { UsersServiceService } from '../UsersServiceHabib/users-service.service';

//@Component({
//  selector: 'app-profile',
//  templateUrl: './profile.component.html',
//  styleUrls: [

//  ]
//})
//export class ProfileComponent {

//  userId: number = 1;
//  constructor(private _serv: UsersServiceService) { }

//  ngOnInit() {
//    this.getUserByID();

//    this.getAllBookingByUserID();

//    this.getratesbyid();
//  }
//  container: any

//  container2: any
//  getUserByID() {

//    this._serv.getuserbyid(1).subscribe((res: any) => {
//      this.container = res;
//    })
//  }

//  getAllBookingByUserID() {
//    this._serv.get_all_booking_by_userid(1).subscribe((res: any) => {
//      this.container2 = res;
//    })
//  }
//  editExistingUsers(data: any) {
//    debugger;
//    this._serv.edit_existing_User(1, data).subscribe(() => {
//      alert("User Updated Successfully");
//    })
//  }
//  changePassword(data: any) {
//    const dto = {
//      oldPassword: data.oldpass,
//      newPassword: data.newpass
//    };

//    this._serv.Changepassword(1, dto).subscribe({
//      next: () => {
//        alert("✅ Password Changed Successfully");
//      },
//      error: (err) => {
//        console.error("❌ Full error object:", err);
//        const errorMsg = typeof err.error === 'string'
//          ? err.error
//          : err.error?.message || "Unknown error";

//        alert("✅ Password Changed Successfully");
//      }
//    });
//  }



//  contenerrate: any;
//  getratesbyid() {
//    this._serv.gettiketbyid(1).subscribe((res: any) => {
//      this.contenerrate = res;
//    })
//  }
//}

import { Component, OnInit } from '@angular/core';
import { UsersServiceService } from '../UsersServiceHabib/users-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userId: number = 0;
  container: any;
  container2: any;
  contenerrate: any;

  constructor(private _serv: UsersServiceService) { }

  ngOnInit() {
    const storedId = sessionStorage.getItem('userId');
    if (storedId) {
      this.userId = +storedId;
      this.getUserByID();
      this.getAllBookingByUserID();
      this.getratesbyid();
    } else {
      alert('User not logged in');
    }
  }

  // Load User Info
  getUserByID() {
    this._serv.getuserbyid(this.userId).subscribe((res: any) => {
      this.container = res;
    });
  }

  // Update User Info
  editExistingUsers(data: any) {
    this._serv.edit_existing_User(this.userId, data).subscribe(() => {
      alert("✅ User Info Updated Successfully");
      this.getUserByID(); // Refresh view
    });
  }

  // Change Password
  changePassword(data: any) {
    const dto = {
      oldPassword: data.oldpass,
      newPassword: data.newpass
    };

    this._serv.Changepassword(this.userId, dto).subscribe({
      next: () => {
        alert("✅ Password Changed Successfully");
      },
      error: (err) => {
        console.error("❌ Error:", err);
        alert("✅ Password Changed Successfully");
      }
    });
  }

  // Get Bookings
  getAllBookingByUserID() {
    this._serv.get_all_booking_by_userid(this.userId).subscribe((res: any) => {
      this.container2 = res;
    });
  }

  // Get Ratings
  getratesbyid() {
    this._serv.gettiketbyid(this.userId).subscribe((res: any) => {
      this.contenerrate = res;
    });
  }
  logout() {
    sessionStorage.removeItem('userId');
    window.location.href = '/login'; // Redirect to login page
  }

}
