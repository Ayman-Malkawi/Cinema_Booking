import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-show-all-rooms',
  templateUrl: './show-all-rooms.component.html',
  styleUrl: './show-all-rooms.component.css'
})
export class ShowAllRoomsComponent {

  apiBaseUrl = 'https://localhost:7057/'; 
  constructor(private _ser: AUrlService) { }

  ngOnInit() {

    this.GetAllData();
  }


  AllRooms:any

  GetAllData() {
    this._ser.getAllRoom().subscribe(data => {
      console.log('sadddddddddddddddddddddddddddddddd'); 
      console.log(data); 
      this.AllRooms = data;
    });
  }





  



}
