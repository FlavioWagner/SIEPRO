import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable()
export abstract class AbstractService<T> {

  constructor(public http: HttpClient) { }

  protected abstract urlService(): String;

  async GetAll() {
    try {
      let resultado = await this.http.get<T[]>(environment.urlSistema + this.urlService()).toPromise();
      return resultado;
    } catch (error) {
      return null;
    }
  }

  async GetById(id:any) {
    try {
      let resultado = await this.http.get<T[]>(environment.urlSistema + this.urlService() + "/" + id).toPromise();
      return resultado;
    } catch (error) {
      return null;
    }
  }

  async Add(dado: T): Promise<Boolean> {
    try {
      let resultado = await this.http.post<T>(environment.urlSistema + this.urlService(), dado).toPromise();
      return resultado != null;
    } catch (error) {
      return false;
    }
  }

  async Update(id: any, dado: T): Promise<Boolean> {
    try {
      let resultado = await this.http.put<T>(environment.urlSistema + this.urlService() + "/" + id, dado).toPromise();
      return resultado != null;
    } catch (error) {
      return false;
    }
  }

  async Remove(id: any): Promise<Boolean> {
    let resultado = await this.http.delete<Boolean>(environment.urlSistema + this.urlService() + '/' + id).toPromise();
    return resultado != null;
  }

}
