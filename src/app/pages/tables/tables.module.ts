import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbDropdownModule, NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

// FlatPicker
import { FlatpickrModule } from 'angularx-flatpickr';

// Component pages
import { TablesRoutingModule } from './tables-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { BasicComponent } from './basic/basic.component';
import { GridjsComponent } from './gridjs/gridjs.component';
import { ListjsComponent } from './listjs/listjs.component';

// Sorting page
import { NgbdGridJsSortableHeader } from './../tables/gridjs/gridjs-sortable.directive';
import { DepartamentoComponent } from './departamento/departamento.component';
import { ZonaComponent } from './zona/zona.component';

@NgModule({
  declarations: [
    BasicComponent,
    GridjsComponent,
    ListjsComponent,
    NgbdGridJsSortableHeader,
    DepartamentoComponent,
    ZonaComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbDropdownModule,
    NgbPaginationModule,
    NgbTypeaheadModule,
    FlatpickrModule,
    TablesRoutingModule,
    SharedModule
  ]
})
export class TablesModule { }
