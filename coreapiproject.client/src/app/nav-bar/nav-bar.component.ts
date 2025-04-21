//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-nav-bar',
//  templateUrl: './nav-bar.component.html',
//  styleUrl: './nav-bar.component.css'
//})
//export class NavBarComponent {
//  isLoggedIn: boolean = false;

//  ngOnInit(): void {
//    const userId = sessionStorage.getItem('userId');
//    this.isLoggedIn = !!userId;
//  }

//  logout() {
//    sessionStorage.clear(); // أو فقط sessionStorage.removeItem('userId');
//    window.location.reload(); // أو router.navigate to login
//  }
//}



///////////////////////
//import { Component, OnInit } from '@angular/core';
//import { Router } from '@angular/router';

//@Component({
//  selector: 'app-nav-bar',
//  templateUrl: './nav-bar.component.html',
//  styleUrls: ['./nav-bar.component.css']
//})
//export class NavBarComponent implements OnInit {
//  isLoggedIn: boolean = false;

//  constructor(private router: Router) { }

//  ngOnInit(): void {

//    const userId = localStorage.getItem('ID');  // تعديل القراءة من localStorage
//    this.isLoggedIn = !!userId;
//  }

//  logout() {
//    localStorage.removeItem('ID');  // تعديل المسح من localStorage
//    this.isLoggedIn = false;
//    this.router.navigate(['/LogIn']);
//  }

//}
/////////////////////////////////
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    const userId = sessionStorage.getItem('userId');  // استرجاع الـ userId من sessionStorage
    this.isLoggedIn = !!userId;  // إذا كان فيه userId، يعني هو مسجل دخول
  }

  logout() {
    sessionStorage.removeItem('userId');  // مسح الـ userId من sessionStorage
    this.isLoggedIn = false;
    this.router.navigate(['/LogIn']);
  }
}
