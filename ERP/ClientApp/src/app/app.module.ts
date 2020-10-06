import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpleadoComponent } from './empleado/empleado.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { AddEditEmpleadosComponent } from './add-edit-empleados/add-edit-empleados.component';
import { EmpleadosService } from './service/empleados.service';

@NgModule({
  declarations: [
    AppComponent,
    EmpleadoComponent,
    EmpleadosComponent,
    AddEditEmpleadosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    EmpleadosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
