import { Injectable } from '@angular/core';
import { AbstractService } from './Abstractions/abstract-service';
import { Professor } from '../Models/professor';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService extends AbstractService<Professor>{
  protected override urlService(): String {
    return "Professor";
  }
}
