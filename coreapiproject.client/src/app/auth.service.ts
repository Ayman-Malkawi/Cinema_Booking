import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  isLoggedIn(): boolean {
    return sessionStorage.getItem('userId') !== null;
  }

  logIn(id: number): void {
    sessionStorage.setItem('userId', id.toString());
  }

  logOut(): void {
    sessionStorage.removeItem('userId');
  }
}
