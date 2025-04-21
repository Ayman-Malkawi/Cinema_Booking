import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsersServiceService {

  constructor(private _http: HttpClient) { }

  getuserbyid(id: number) {
    return this._http.get(`https://localhost:7057/api/Users/getUserByID/${id}`)
  }
  get_all_booking_by_userid(id: number) {
    return this._http.get(`https://localhost:7057/api/Users/GetBookingDataByID/${id}`)
  }
  edit_existing_User(id:number,data :any) {
    return this._http.put(`https://localhost:7057/api/Users/EditUser/${id}`,data)
  }
  gettiketbyid(id: number) {
    return this._http.get(`https://localhost:7057/api/Users/getRates/${id}`)
  }
  Changepassword(id: any, data: any) {
    return this._http.put(`https://localhost:7057/api/Users/changepassword/${id}`, data);
  }
  getallmovies() {
    return this._http.get(`https://localhost:7057/api/Users/GetAllMovies`)
  }
  addnewrating(data : any) {
    return this._http.post(`https://localhost:7057/api/Users/addRating`,data)

  }
}
