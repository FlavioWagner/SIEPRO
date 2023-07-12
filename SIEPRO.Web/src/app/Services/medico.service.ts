import { Injectable } from '@angular/core';
import { AbstractService } from './Abstractions/abstract-service';
import { Medico } from '../Models/medico';

@Injectable({
  providedIn: 'root'
})
export class MedicoService extends AbstractService<Medico>{
  protected override urlService(): String {
    return "Medico";
  }
}
