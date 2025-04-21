import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-private-rooms',
  templateUrl: './private-rooms.component.html',
  styleUrl: './private-rooms.component.css'
})
export class PrivateRoomsComponent {

  privateRooms: any[] = [];

  constructor(private _url: AUrlService) { }

  ngOnInit(): void {
    this.getPrivateRooms();
  }

  getPrivateRooms(): void {
    this._url.getAllPrivateRooms().subscribe(
      (data) => {
        this.privateRooms = data; // تخزين البيانات المستلمة
      },
      (error) => {
        console.error('There was an error!', error);
      }
    );
  }





}
