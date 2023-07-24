import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CadastroPessoaComponent } from './Components/cadastro-pessoa/cadastro-pessoa.component';
import { PessoaService } from './Services/pessoa.service';
import { HttpClientModule } from '@angular/common/http';
import { CarroService } from './Services/carro.service';
import { MedicoService } from './Services/medico.service';
import { CidadeServicece } from './Services/cidade.service';
import { ProfessorService } from './Services/professor.service';
import { HotelService } from './Services/hotel.service';

@NgModule({
  declarations: [
    AppComponent,
    CadastroPessoaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt' },
    PessoaService,
    CarroService,
    MedicoService,
    CidadeServicece,
    ProfessorService,
    HotelService
  ],  
  bootstrap: [AppComponent]
})
export class AppModule { }
