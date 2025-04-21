import { Component } from '@angular/core';
import { AUrlService } from '../AdminService/a-url.service';
import { dateTimestampProvider } from 'rxjs/internal/scheduler/dateTimestampProvider';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css'
})
export class ContactUsComponent {



  constructor(private _ser: AUrlService) { }


  Add_Contact(data: any) {



    this._ser.AddNewContact(data).subscribe(() => {


      alert('Added Data is Successfully');
      console.log(data);

    })

  }

}
