import { Routes } from '@angular/router';
import { ByCapitalPage } from './pages/by-capital-page/by-capital-page';

export const routes: Routes = [
    {
        path: '',
        component: ByCapitalPage,
    },
    {
        path: '**',
        redirectTo: '',
    }
];

export default routes;