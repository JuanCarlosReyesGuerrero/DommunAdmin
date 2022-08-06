import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Component pages
import { BasicComponent } from "./basic/basic.component";
import { DepartamentoComponent } from './departamento/departamento.component';
import { GridjsComponent } from "./gridjs/gridjs.component";
import { ListjsComponent } from "./listjs/listjs.component";
import { ZonaComponent } from './zona/zona.component';

const routes: Routes = [
  {
    path: "basic",
    component: BasicComponent
  },
  {
    path: "gridjs",
    component: GridjsComponent
  },
  {
    path: "listjs",
    component: ListjsComponent
  },
  {
    path: "departamento",
    component: DepartamentoComponent
  },
  {
    path: "zona",
    component: ZonaComponent
  }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class TablesRoutingModule { }
