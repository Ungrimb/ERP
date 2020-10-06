import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEditEmpleadosComponent } from './add-edit-empleados/add-edit-empleados.component';
import { EmpleadoComponent } from './empleado/empleado.component';
import { EmpleadosComponent } from './empleados/empleados.component';

const routes: Routes = [
  { path:'', component:EmpleadosComponent,pathMatch:'full'},
  { path:'Empleados/:id', component:EmpleadoComponent},
  { path:'add', component: AddEditEmpleadosComponent},
  { path:'Empleados/edit/:id', component: AddEditEmpleadosComponent},
  { path:'**', redirectTo:'/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
