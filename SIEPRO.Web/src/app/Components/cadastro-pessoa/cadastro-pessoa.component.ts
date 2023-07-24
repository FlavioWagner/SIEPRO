import { ProfessorService } from './../../Services/professor.service';
import { Cidade } from 'src/app/Models/cidade';
import { Pessoa } from './../../Models/pessoa';
import { Component, OnInit } from '@angular/core';
import { Medico } from 'src/app/Models/medico';
import { MedicoService } from 'src/app/Services/medico.service';
import { PessoaService } from 'src/app/Services/pessoa.service';
import { CidadeServicece } from 'src/app/Services/cidade.service';
import { Professor } from 'src/app/Models/professor';
import { Hotel } from 'src/app/Models/hotel';
import { HotelService } from 'src/app/Services/hotel.service';

@Component({
  selector: 'app-cadastro-pessoa',
  templateUrl: './cadastro-pessoa.component.html',
  styleUrls: ['./cadastro-pessoa.component.css']
})
export class CadastroPessoaComponent implements OnInit {

  pessoas:Pessoa[] = [];
  medicos:Medico[] = [];
  cidades:Cidade[] = [];
  professores:Professor[] = [];
  hoteis:Hotel[] = []; 

  constructor(private pessoaService:PessoaService,
              private medicoService:MedicoService,
              private cidadeService:CidadeServicece,
              private professorService :ProfessorService,
              private hotelService :HotelService) { }

  async ngOnInit() {
    await this.carregarDados();
  }
  
  private async carregarDados() {
    this.pessoas = (await this.pessoaService.GetAll());
    this.medicos = (await this.medicoService.GetAll());
    this.cidades = (await this.cidadeService.GetAll());
    this.professores = (await this.professorService.GetAll());
    this.hoteis = (await this.hotelService.GetAll());
  }
}
