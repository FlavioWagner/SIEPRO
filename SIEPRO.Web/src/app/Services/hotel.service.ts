import { Injectable } from '@angular/core';
import { AbstractService } from './Abstractions/abstract-service';
import { Hotel } from '../Models/hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService extends AbstractService<Hotel> {
  protected override urlService(): String {
    return "Hotel";
  }
}
