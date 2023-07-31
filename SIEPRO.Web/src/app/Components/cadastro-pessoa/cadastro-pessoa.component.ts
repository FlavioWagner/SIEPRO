import { CarroService } from './../../Services/carro.service';
import { Pessoa } from './../../Models/pessoa';
import { Component, OnInit } from '@angular/core';
import { Carro } from 'src/app/Models/carro';
import { PessoaService } from 'src/app/Services/pessoa.service';

@Component({
  selector: 'app-cadastro-pessoa',
  templateUrl: './cadastro-pessoa.component.html',
  styleUrls: ['./cadastro-pessoa.component.css'],
})
export class CadastroPessoaComponent implements OnInit {

  pessoas:Pessoa[] = [];
  carros:Carro[] = [];

  constructor(private pessoaService:PessoaService,
              private carroService:CarroService,
              ) { }

  async ngOnInit() {
    await this.carregarDados();
  }
  
  private async carregarDados() {
    this.pessoas = (await this.pessoaService.GetAll());
     await this.carroService.GetById('f336c0b3-7531-4e97-84b9-28846669718a').then(x=>{
      this.carros.push(x)
    });
  }
}
