import { Component } from '@angular/core';
import { UsersServiceService } from '../UsersServiceHabib/users-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: [

  ]
})
export class ProfileComponent {

  userId: number = 1;
  constructor(private _serv: UsersServiceService) { }

  ngOnInit() {
    this.getUserByID();

    this.getAllBookingByUserID();

    this.getratesbyid();
  }
  container: any

  container2: any
  getUserByID() {
    debugger;
    this._serv.getuserbyid(1).subscribe((res: any) => {
      this.container = res;
    })
  }

  getAllBookingByUserID() {
    this._serv.get_all_booking_by_userid(1).subscribe((res: any) => {
      this.container2 = res;
    })
  }
  editExistingUsers(data: any) {
    debugger;
    this._serv.edit_existing_User(1, data).subscribe(() => {
      alert("User Updated Successfully");
    })
  }
  changePassword(data: any) {
    const dto = {
      oldPassword: data.oldpass,
      newPassword: data.newpass
    };

    this._serv.Changepassword(1, dto).subscribe({
      next: () => {
        alert("✅ Password Changed Successfully");
      },
      error: (err) => {
        console.error("❌ Full error object:", err);
        const errorMsg = typeof err.error === 'string'
          ? err.error
          : err.error?.message || "Unknown error";

        alert("✅ Password Changed Successfully");
      }
    });
  }



  contenerrate: any;
  getratesbyid() {
    this._serv.gettiketbyid(1).subscribe((res: any) => {
      this.contenerrate = res;
    })
  }
}
