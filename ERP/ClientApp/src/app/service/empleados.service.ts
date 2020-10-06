import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { Empleado } from '../model/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Empleados/';
}

getEmpleados(): Observable<Empleado[]> {
  return this.http.get<Empleado[]>(this.myAppUrl + this.myApiUrl)
  .pipe(
    retry(1),
    catchError(this.errorHandler)
  );
}

getEmpleado(Id: number): Observable<Empleado> {
    return this.http.get<Empleado>(this.myAppUrl + this.myApiUrl + Id)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

saveEmpleado(empleado): Observable<Empleado> {
    return this.http.post<Empleado>(this.myAppUrl + this.myApiUrl, JSON.stringify(empleado), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

updateEmpleado(Id: number, empleado): Observable<Empleado> {
    return this.http.put<Empleado>(this.myAppUrl + this.myApiUrl + Id, JSON.stringify(empleado), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

deleteEmpleado(Id: number): Observable<Empleado> {
    return this.http.delete<Empleado>(this.myAppUrl + this.myApiUrl + Id)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

errorHandler(error) {
  let errorMessage = '';
  if (error.error instanceof ErrorEvent) {
    // Get client-side error
    errorMessage = error.error.message;
  } else {
    // Get server-side error
    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  }
  console.log(errorMessage);
  return throwError(errorMessage);
}
}
