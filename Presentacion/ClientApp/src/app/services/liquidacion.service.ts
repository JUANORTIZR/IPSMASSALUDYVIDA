import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Liquidacion } from '../Ips/models/liquidacion';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class LiquidacionService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Liquidacion[]> {
    return this.http.get<Liquidacion[]>(this.baseUrl + 'api/Liquidacion')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Liquidacion[]>('Consulta Persona', null))
      );
  }

  post(liquidacion: Liquidacion): Observable<Liquidacion> {
    return this.http.post<Liquidacion>(this.baseUrl + 'api/Liquidacion', liquidacion)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Liquidacion>('Registrar Persona', null))
      );
  }


}
