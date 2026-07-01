import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'dashboard',
        loadComponent: () => import('./gifs/pages/dashboard-page/dashboard-page'),
        children: [
            {
                path: 'trading',
                loadComponent: () => import('./gifs/pages/trading-page/trading-page')
            },
            {
                path: 'search',
                loadComponent: () => import('./gifs/pages/search-page/search-page')
            },
            {
                path: 'history/:query',
                loadComponent: () => import('./gifs/pages/gift-history/gift-history')
            },

        ]
    },
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' }    
];
