import { Component, OnInit } from '@angular/core';
import { IEmpleado } from '../model/empleado';
import { EmpleadosService } from '../service/empleados.service';


@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.scss']
})
export class EmpleadosComponent implements OnInit {

  empleados : IEmpleado[];

  constructor(private empleadosService: EmpleadosService) { }

  ngOnInit(): void {
    this.cargarData();
  }
  cargarData() {
    this.empleadosService.getEmpleados()
      .subscribe(empleadosWS => this.empleados = empleadosWS,
        error => console.error(error));
  }
  delete(empleado: IEmpleado) {
    this.empleadosService.deleteEmpleado(empleado.Id)
      .subscribe(empleado => this.cargarData(),
        error => console.error(error));
  }

}
