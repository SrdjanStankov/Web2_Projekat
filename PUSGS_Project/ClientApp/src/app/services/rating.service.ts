import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rating } from '../entities/rating';

@Injectable({
  providedIn: 'root'
})
export class RatingService {
  http: HttpClient;
  ratingControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_RENTACAR_URL') baseUrl: string) {
    this.http = http;
    this.ratingControllerUri = baseUrl + 'api/rating/';
  }

  rateCar(rating: Rating) {
    return this.http.post(this.ratingControllerUri, rating).toPromise();
  }
}
