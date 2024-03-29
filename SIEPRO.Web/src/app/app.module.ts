import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CadastroPessoaComponent } from './Components/cadastro-pessoa/cadastro-pessoa.component';
import { PessoaService } from './Services/pessoa.service';
import { HttpClientModule } from '@angular/common/http';
import { CarroService } from './Services/carro.service';

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
    CarroService
  ],  
  bootstrap: [AppComponent]
})
export class AppModule { }
