import { Injectable } from '@angular/core';
import { Cidade } from '../Models/cidade';
import { AbstractService } from './Abstractions/abstract-service';

@Injectable({
  providedIn: 'root'
})
export class CidadeServicece extends AbstractService<Cidade>{
  
  protected override urlService(): String {
    return "Cidade";
  }

}
