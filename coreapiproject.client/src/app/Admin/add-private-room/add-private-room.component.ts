import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';  // تأكد من مسار الخدمة

@Component({
  selector: 'app-add-private-room',
  templateUrl: './add-private-room.component.html',
  styleUrls: ['./add-private-room.component.css']
})
export class AddPrivateRoomComponent {

  privateRoom = {
    id: 0,
    roomId: 0,
    roomName: '',
    vipName: '',
    vipDescription: '',
    vipPrice: 0,
    capacity: 0,
    availability: [
      {
        availableDay: '',
        startTime: '',
        endTime: ''
      }
    ]
  };

  constructor(private _url: AUrlService) { }

  // Add Room Method
  addRoom() {
    this._url.addPrivateRoom(this.privateRoom).subscribe({
      next: () => {
        console.log('Room added successfully');
        this.resetForm();
      },
      error: (err) => console.error('Error adding room', err)
    });
  }

  // Reset the form
  resetForm() {
    this.privateRoom = {
      id: 0,
      roomId: 0,
      roomName: '',
      vipName: '',
      vipDescription: '',
      vipPrice: 0,
      capacity: 0,
      availability: [
        {
          availableDay: '',
          startTime: '',
          endTime: ''
        }
      ]
    };
  }

  // Add new time slot to availability
  addAvailabilityRow() {
    this.privateRoom.availability.push({
      availableDay: '',
      startTime: '',
      endTime: ''
    });
  }

  // Remove an availability time slot
  removeAvailability(index: number) {
    this.privateRoom.availability.splice(index, 1);
  }
}
