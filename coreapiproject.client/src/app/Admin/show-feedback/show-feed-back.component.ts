import { Component } from '@angular/core';
import { AUrlService } from '../../AdminService/a-url.service';

@Component({
  selector: 'app-show-feed-back',
  templateUrl: './show-feed-back.component.html',
  styleUrl: './show-feed-back.component.css'
})
export class ShowFeedBackComponent {


  constructor(private _ser: AUrlService) { }

  ngOnInit() {

    this.GetAllData();

  }

  AllData: any;


  GetAllData() {

    this._ser.GetAllShowFeedback().subscribe(data => {

      console.log(data);
      this.AllData = data;
    })

  }


  


}
