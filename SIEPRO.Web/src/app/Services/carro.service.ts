import { Injectable } from '@angular/core';
import { AbstractService } from './Abstractions/abstract-service';
import { Carro } from '../Models/carro';

@Injectable()
export class CarroService extends AbstractService<Carro> {

  protected override urlService(): String {
    return "Carro";
  }
}
