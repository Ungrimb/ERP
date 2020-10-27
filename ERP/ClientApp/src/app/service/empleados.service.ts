import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IEmpleado } from '../model/empleado';

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

getEmpleados(): Observable<IEmpleado[]> {
  return this.http.get<IEmpleado[]>(this.myAppUrl + this.myApiUrl)
  .pipe(
    retry(1),
    catchError(this.errorHandler)
  );
}

getEmpleado(Id: number): Observable<IEmpleado> {
    return this.http.get<IEmpleado>(this.myAppUrl + this.myApiUrl + Id)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

saveEmpleado(empleado): Observable<IEmpleado> {
    return this.http.post<IEmpleado>(this.myAppUrl + this.myApiUrl, JSON.stringify(empleado), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

updateEmpleado(Id: number, empleado): Observable<IEmpleado> {
    return this.http.put<IEmpleado>(this.myAppUrl + this.myApiUrl + Id, JSON.stringify(empleado), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
}

deleteEmpleado(Id: number): Observable<IEmpleado> {
    return this.http.delete<IEmpleado>(this.myAppUrl + this.myApiUrl + Id)
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
