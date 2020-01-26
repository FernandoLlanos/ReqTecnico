import { NgModule } from '@angular/core';
import { BusquedaComponent } from './busqueda/busqueda.component';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';

const routes: Routes = [
    { path: '', component: BusquedaComponent },
];

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes)
    ],
    declarations: [BusquedaComponent],
    exports: [
        RouterModule
    ]
})
export class BusquedaModule { }