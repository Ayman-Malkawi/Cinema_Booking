//import { Component } from '@angular/core';
//import { AUrlService } from '../../AdminService/a-url.service';
//import { ActivatedRoute } from '@angular/router';

//@Component({
//  selector: 'app-room-availability',
//  templateUrl: './room-availability.component.html',
//  styleUrl: './room-availability.component.css'
//})
//export class RoomAvailabilityComponent {


//  Room_ID: any;



//  constructor(private _ser: AUrlService, private _Act: ActivatedRoute) {

//  }





//  addAvailability(data: any) {

//    this.Room_ID = this._Act.snapshot.paramMap.get("id");

//        data.RoomId = this.Room_ID;

//    this._ser.AddRoomAvailability(data).subscribe(() => {

//      alert('Save Data is The data has been saved successfully');

//    })


//  }


//}
import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-room-availability',
  templateUrl: './room-availability.component.html',
  styleUrls: ['./room-availability.component.css'] // ✅ FIXED typo (styleUrl → styleUrls)
})
export class RoomAvailabilityComponent {
  Room_ID: any;

  constructor(private _ser: AUrlService, private _Act: ActivatedRoute) { }

  addAvailability(data: any) {
    this.Room_ID = this._Act.snapshot.paramMap.get("id");
    data.RoomId = +this.Room_ID; // ensure it's a number

    this._ser.AddRoomAvailability(data).subscribe({
      next: () => {
        alert('The data has been saved successfully');
      },
      error: (err) => {
        console.error('Failed to save availability:', err);
        alert('Error saving availability');
      }
    });
  }
}
