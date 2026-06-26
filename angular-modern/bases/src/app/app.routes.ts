import { Routes } from '@angular/router';
import { CounterPageComponent } from './pages/counter/counter.component';
import { HeroPageComponent } from './pages/hero/hero-page.component';
import { DragonPageComponent } from './pages/dragonball/dragon-page.component';
import { DragonSuperPageComponent } from './pages/dragonball-super/dragon-super-page.component';

export const routes: Routes = [
    {
        path: '',
        component: CounterPageComponent,
    },
    {
        path: 'hero',
        component: HeroPageComponent,
    },
    {
        path: 'dragonball',
        component: DragonPageComponent,
    },
    {
        path: 'dragonball-super',
        component: DragonSuperPageComponent,
    },
    {
        path: '**',
        redirectTo: '',
    },
];
