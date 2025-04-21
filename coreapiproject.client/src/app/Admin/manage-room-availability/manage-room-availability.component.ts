import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-manage-room-availability',
  templateUrl: './manage-room-availability.component.html',
  styleUrls: ['./manage-room-availability.component.css']
})
export class ManageRoomAvailabilityComponent {
  rooms: any[] = [];

  constructor(private _url: AUrlService) { }

  ngOnInit(): void {
    this._url.getPrivateRooms().subscribe((data: any) => {
      console.log('Rooms data:', data); // ✅ تأكد من وجود البيانات
      this.rooms = data;
    });
  }


}
