//import { Component } from '@angular/core';
//import { UrlService } from '../ClientService/url.service';
//import { Router } from '@angular/router';

//@Component({
//  selector: 'app-log-in',
//  templateUrl: './log-in.component.html',
//  styleUrl: './log-in.component.css'
//})
//export class LogInComponent {
//  errorMessage: string = '';


//  constructor(private _ser: UrlService, private router: Router) { }
//  ngOnInit() { }
//  CheckUser(data: any) {
//    this._ser.CheckUser(data).subscribe(
//      () => {
//        alert("Login successful!");
//      },
//      (error) => {
//        alert(error.error);
//      }
//    );
//  }


//}
//import { Component, OnInit } from '@angular/core';
//import { UrlService } from '../ClientService/url.service';
//import { Router } from '@angular/router';

//@Component({
//  selector: 'app-log-in',
//  templateUrl: './log-in.component.html',
//  styleUrls: ['./log-in.component.css']
//})
//export class LogInComponent implements OnInit {
//  errorMessage: string = '';
//  isLoggedIn: boolean = false; // إضافة الخاصية isLoggedIn

//  constructor(private _ser: UrlService, private router: Router) { }

//  ngOnInit(): void {
//    const userId = sessionStorage.getItem('userId');
//    this.isLoggedIn = !!userId;  // إذا كان فيه userId، يعني هو مسجل دخول
//  }
//  CheckUser(data: any) {
//    console.log(data);  // بس عشان نشيك البيانات

//    const email = data.email?.toLowerCase();
//    const password = data.password;

//    if (email === 'admin@gmail.com' && password === 'Admin') {
//      alert("Welcome Admin!");
//      this.router.navigate(['/admin']);
//      return;
//    }

//    this._ser.CheckUser(data).subscribe(
//      (response: any) => {
//        alert("Login successful!");

//        // نحفظ الـ id من الـ response
//        sessionStorage.setItem('userId', response.id);

//        // بعدها نحوله عالـ home page
//        this.router.navigate(['/']);
//      },
//      (error) => {
//        alert(error.error.message || "An error occurred.");
//      }
//    );
//  }



//}





//////////////////////////////////////////

import { Component, OnInit } from '@angular/core';
import { UrlService } from '../ClientService/url.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  errorMessage: string = '';
  isLoggedIn: boolean = false;

  constructor(private _ser: UrlService, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  CheckUser(data: any) {
    const email = data.email?.toLowerCase();
    const password = data.password;

    if (email === 'admin@gmail.com' && password === 'Admin') {
      alert("Welcome Admin!");
      this.authService.logIn(0); // admin id = 0
      this.router.navigate(['/admin']);
      return;
    }

    this._ser.CheckUser(data).subscribe(
      (response: any) => {
        alert("Login successful!");
        this.authService.logIn(response.id);
        this.router.navigate(['/']).then(() => {
          window.location.reload();
        });
      },
      (error) => {
        alert(error.error.message || "An error occurred.");
      }
    );
  }
}
