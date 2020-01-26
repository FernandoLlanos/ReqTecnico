import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

//Services
import { SettingsService } from '../settings/settings.service';

//Librerias
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';



@Injectable()
export class EvaluacionService {

  url_servicio: any;

  constructor(
    public config: SettingsService,
    public http: HttpClient,
    public router: Router
  ) {
        this.url_servicio = this.config.getAppSetting('ApiUrl') + '/evaluacion';
  }

  public getListar(strCorreoElectronico: string, strFechaInicio: string, strFechaFin: string):Observable<any>{
    const params = new HttpParams()
        .set('strCorreoElectronico', strCorreoElectronico)
        .set('strFechaInicio', strFechaInicio)
        .set('strFechaFin', strFechaFin)
    return this.http.get(this.url_servicio + '/listar', {params});
  }

  public getListarPorCorreo(strCorreoElectronico: string):Observable<any>{
    const params = new HttpParams()
        .set('strCorreoElectronico', strCorreoElectronico)
    return this.http.get(this.url_servicio + '/listarporcorreo', {params});
  }

  public postGrabar(model:any):Observable<any>{
    return this.http.post(this.url_servicio + '/grabar', model);
  }

  public putActualizar(model:any):Observable<any>{
    return this.http.put(this.url_servicio + '/actualizar' , model);
  }
}
