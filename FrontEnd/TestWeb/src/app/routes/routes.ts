import { LayoutComponent } from '../layout/layout.component';

export const routes = [

    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
            { path: 'busqueda', loadChildren: () => import('./busqueda/busqueda.module').then(m => m.BusquedaModule) }
        ]
    },

    // Not found
    { path: '**', redirectTo: 'home' }

];
