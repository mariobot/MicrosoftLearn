import { Routes } from '@angular/router';
import { CountryLayout } from './layouts/country-layout/country-layout';
import { ByCapitalPage } from './pages/by-capital-page/by-capital-page';

export const routes: Routes = [
    {
        path: '',
        component: CountryLayout,
        children: [
            {
                path: 'by-capital',
                component: ByCapitalPage
            },
            {
                path: '**',
                redirectTo: 'by-capital',
            }
        ]
    },
    /*{
        path: '**',
        redirectTo: '',
    }*/
];

export default routes;