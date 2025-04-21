import { Component } from '@angular/core';
import { UrlService } from '../ClientService/url.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  constructor(private _ser: UrlService) { }

  ngOnInit() {


  }


  addUser(data: any) {


    if (data.Password !== data.ConfirmPassword) {
      alert("Passwords don't match!");
      return;
    }

    this._ser.AddUser(data).subscribe(
      () => {
        alert("Registration successful!");
      });

  }

}
