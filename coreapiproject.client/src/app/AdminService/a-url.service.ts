import { Injectable } from '@angular/core';
import { UrlService } from '../ClientService/url.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { PrivateBookingDTO } from '../Admin/private-room/private-room.component';


export interface PrivateRoomDTO {
  id: number;
  roomId: number;
  roomName: string;
  vipName: string;
  vipDescription: string;
  vipPrice: number;
  capacity: number;
}




@Injectable({
  providedIn: 'root'
})
export class AUrlService {

  private userApi = 'https://localhost:7057/api/User/getAllUsers';
  private categoryApi = 'https://localhost:7057/api/MovieCategory';
  private movieApi = 'https://localhost:7057/api/Movie';
  private privateBooking = 'https://localhost:7057/api/PrivateRoom';
  private baseUrl = 'https://localhost:7057/api/RoomAvailability/GetPrivateRoomsWithAvailability'


  constructor(private http: HttpClient) { }


  GetAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.userApi);  // Explicitly specify the response type
  }



  // للحصول على جميع الفئات
  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${this.categoryApi}/getAllCategories`);
  }

  // لإضافة فئة جديدة
  addCategory(category: any): Observable<any> {
    return this.http.post<any>(`${this.categoryApi}/addCategory`, category);
  }

  //// لحذف فئة
  //deleteCategory(categoryId: number): Observable<any> {
  //  return this.http.delete<any>(`${this.categoryApi}/deleteCategory/${categoryId}`);
  //}
  deleteCategory(categoryId: number): Observable<any> {
    return this.http.delete<any>(`${this.categoryApi}/deleteCategory/${categoryId}?isAdmin=false`);
  }


  // لتعديل فئة
  editCategory(categoryId: number, category: any): Observable<any> {
    return this.http.put<any>(`${this.categoryApi}/editCategory/${categoryId}`, category);
  }




  // جلب جميع الأفلام
  getAllMovies(): Observable<any[]> {
    return this.http.get<any[]>(`${this.movieApi}/getAllMovies`);
  }

  // إضافة فيلم جديد
  // في ملف a-url.service.ts
  addMovie(movie: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post(`${this.movieApi}/addMovie`, movie, {
      headers: headers,
      responseType: 'text'
    }).pipe(
      map(response => {
        try {
          return response ? JSON.parse(response) : response;
        } catch (e) {
          return response;
        }
      })
    );
  }


  // تحميل فيلم معين حسب الـ ID
  getMovieById(id: number): Observable<any> {
    return this.http.get<any>(`${this.movieApi}/getMovieById/${id}`);
  }


  // تعديل فيلم
  editMovie(id: number, movie: any): Observable<any> {
    return this.http.put(`${this.movieApi}/editMovie/${id}`, movie);
  }

  // تغيير حالة الفيلم إلى قابل أو غير قابل
  toggleViable(movieId: number): Observable<any> {
    return this.http.put(`${this.movieApi}/toggleViable/${movieId}`, {});
  }


  GetAllShowFeedback() {

    return this.http.get("https://localhost:7057/api/Contact/GetAllFeedback");

  }

  AddNewContact(data:any) {

    return this.http.post("https://localhost:7057/api/Contact/FeedBack", data);

  }

  // private Rooms
  getAll(): Observable<PrivateBookingDTO[]> {
    return this.http.get<PrivateBookingDTO[]>(`${this.privateBooking}/AllPrivateRooms`);  // هنا تم التعديل
  }

  getById(id: number): Observable<PrivateBookingDTO> {
    return this.http.get<PrivateBookingDTO>(`${this.privateBooking}/GetById/${id}`);
  }

  add(booking: PrivateBookingDTO): Observable<any> {
    return this.http.post(`${this.privateBooking}/Add`, booking);
  }

  update(id: number, booking: PrivateBookingDTO): Observable<any> {
    return this.http.put(`${this.privateBooking}/Update/${id}`, booking);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.privateBooking}/Delete/${id}`);
  }


  //private rooms



  //getAllPrivateRooms(): Observable<any> {
  //  return this.http.get(this.privateRoom);
  //}

  getAllPrivateRooms(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7057/api/PrivateRoom/AllPrivateRooms');
  }


  addPrivateRoom(room: PrivateRoomDTO) {
    return this.http.post('https://localhost:7057/api/PrivateRoom/AddPrivateRoom', room); // غيّر الرابط حسب API تبعك
  }







  getPrivateRooms(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}`);
  }

  // دالة لإضافة غرفة خاصة جديدة مع التوافر



  addPrivateRoomWithAvailability(data: any): Observable<any> {
    return this.http.post('https://localhost:7057/api/PrivateRoom/AddPrivateRoom', data);
  }


  getAllPrivateBookings(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7057/api/PrivateRoomBookings/AllPrivateBookingsRooms');
  }



  AddNewRoom(data: any) {

    return this.http.post("https://localhost:7057/api/Rooms/AddNewRoom", data);

  }

  getAllRoom() {

    return this.http.get("https://localhost:7057/api/Rooms/GetAllRoom");
  }


  AddRoomAvailability(data: any) {

    return this.http.post("https://localhost:7057/api/RoomAvailability/addAvailability", data);

  }

}
