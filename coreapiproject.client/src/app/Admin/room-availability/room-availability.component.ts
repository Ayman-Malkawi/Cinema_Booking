import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-room-availability',
  templateUrl: './room-availability.component.html',
  styleUrl: './room-availability.component.css'
})
export class RoomAvailabilityComponent {


  Room_ID: any;



  constructor(private _ser: AUrlService, private _Act: ActivatedRoute) {

  }





  addAvailability(data: any) {

    this.Room_ID = this._Act.snapshot.paramMap.get("id");

        data.RoomId = this.Room_ID;

    this._ser.AddRoomAvailability(data).subscribe(() => {

      alert('Save Data is The data has been saved successfully');

    })


  }


}
