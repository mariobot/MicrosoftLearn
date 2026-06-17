import { Routes } from '@angular/router';
import { About } from './about/about';
import { Contact } from './contact/contact';
import { Interpolation } from './Templates/interpolation';
import { Reference } from './Templates/reference';
import { NullSafe } from './Templates/nullsafe';
import { StructuralDirectives } from './Templates/structuraldirectives';
import { TemplateOutlet } from './Templates/TemplateOutlet';
import { Alias } from './Templates/alias';
import { Pipes } from './Templates/pipes';  

export const routes: Routes = [
  { path: 'about', component: About },
  { path: 'contact', component: Contact },
  { path: 'interpolation', component: Interpolation },
  { path: 'reference', component: Reference },
  { path: 'nullsafe', component: NullSafe },
  { path: 'structuraldirectives', component: StructuralDirectives },
  { path: 'templateoutlet', component: TemplateOutlet },
  { path: 'alias', component: Alias },
  { path: 'pipes', component: Pipes },
];
