import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  isLoggedIn: boolean = false;

  ngOnInit(): void {
    const userId = sessionStorage.getItem('userId');
    this.isLoggedIn = !!userId;
  }

  logout() {
    sessionStorage.clear(); // أو فقط sessionStorage.removeItem('userId');
    window.location.reload(); // أو router.navigate to login
  }
}
