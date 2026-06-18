import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';

@Injectable()
export class LocalCounterService {
  id = Math.floor(Math.random() * 10000);
  value = 0;
  inc() { this.value++; }
}

@Component({
  selector: 'counter-view',
  standalone: true,
  template: `
    <p>Service #{{ svc.id }} value: {{ svc.value }}</p>
    <button (click)="svc.inc()">+1</button>
  `
})
export class CounterView {
  constructor(public svc: LocalCounterService) {}
}

@Component({
  selector: 'panel-a',
  standalone: true,
  imports: [CommonModule, CounterView],
  providers: [LocalCounterService],
  template: `
    <h4>Panel A (own provider)</h4>
    <counter-view></counter-view>
    <counter-view></counter-view>
  `
})
export class PanelA {}

@Component({
  selector: 'panel-b',
  standalone: true,
  imports: [CommonModule, CounterView],
  providers: [LocalCounterService],
  template: `
    <h4>Panel B (own provider)</h4>
    <counter-view></counter-view>
    <counter-view></counter-view>
  `
})
export class PanelB {}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, PanelA, PanelB],
  styles: [`
    .grid { display: grid; grid-template-columns: repeat(auto-fit, minmax(220px, 1fr)); gap: 16px; }
    h4 { margin: 0 0 8px; }
    button { margin-top: 6px; }
  `],
  template: `
    <h3>Component-Provided Service (Hierarchical DI)</h3>
    <p>Each panel provides its own service instance.</p>
    <p>Counters inside the same panel share the instance.</p>
    <p>Different panels do not.</p>
    <div class="grid">
      <panel-a></panel-a>
      <panel-b></panel-b>
    </div>
  `
})
export class Services3Comp {}

bootstrapApplication(Services3Comp);