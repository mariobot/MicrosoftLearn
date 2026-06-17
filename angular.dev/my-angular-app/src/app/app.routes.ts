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
import { AttributesBinding } from './Templates/attributesBinding';
import { TrackBy } from './Templates/trackBy';

import { InputComponent } from './component/input';
import { OutputComponent } from './component/output';
import { Parent } from './component/parent';
import { DataBinding } from './component/dataBinding';
import { NgModuleComp } from './component/ngModuleComp';
import { AttrBinding } from './component/attrBinding';
import { NgIfComp } from './component/ngIfComp';
import { NgComp } from './component/ngComp';
import { AttrDirective } from './component/attrDirective';
import { EventsComp } from './component/eventsComp';

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
  { path: 'attributesbinding', component: AttributesBinding },
  { path: 'trackby', component: TrackBy },
  { path: 'input', component: InputComponent },
  { path: 'output', component: OutputComponent },
  { path: 'parent', component: Parent },
  { path: 'databinding', component: DataBinding },
  { path: 'ngmodule', component: NgModuleComp },
  { path: 'attrbinding', component: AttrBinding },
  { path: 'ngif', component: NgIfComp },
  { path: 'ngcomp', component: NgComp },
  { path: 'attrdirective', component: AttrDirective },
  { path: 'events', component: EventsComp }
];
