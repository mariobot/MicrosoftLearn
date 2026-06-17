import { Routes } from '@angular/router';
import { About } from './about/about';
import { Contact } from './contact/contact';
import { Interpolation } from './Templates/interpolation';
import { Reference } from './Templates/reference';

export const routes: Routes = [
  { path: 'about', component: About },
  { path: 'contact', component: Contact },
  { path: 'interpolation', component: Interpolation },
  { path: 'reference', component: Reference },
];
