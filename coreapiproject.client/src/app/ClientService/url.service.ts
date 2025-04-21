//import { HttpClient } from '@angular/common/http';
//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class UrlService {

//  constructor(private _http: HttpClient) { }



//  getAllMovies() {

//    return this._http.get<any>('https://localhost:7057/api/ShowFilm/GetAllMovies')



//  }

//  getMoviesByCategory(categoryId: number) {
//    return this._http.get<any>(`https://localhost:7057/api/ShowFilm/GetMoviesByCategory/${categoryId}`);
//  }
//}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private _http: HttpClient) { }

  getAllMovies() {
    return this._http.get<any>('https://localhost:7057/api/ShowFilm/GetAllMovies');
  }

  getMoviesByCategory(categoryId: number) {
    return this._http.get<any>(`https://localhost:7057/api/ShowFilm/GetMoviesByCategory/${categoryId}`);
  }

  getAllCategories() {
    return this._http.get<any>('https://localhost:7057/api/ShowFilm/GetAllCategories');
  }

}

