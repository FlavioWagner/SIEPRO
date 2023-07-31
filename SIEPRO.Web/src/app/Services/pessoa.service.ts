import { Injectable } from '@angular/core';
import { Pessoa } from '../Models/pessoa';
import { AbstractService } from './Abstractions/abstract-service';
import { environment } from 'src/environments/environment';

@Injectable()
export class PessoaService extends AbstractService<Pessoa> {

    override: any
    protected urlService():String{
      return "Pessoas";
    }
}
