import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CounterService {
  value = 0;
  inc() { this.value++; }
  dec() { this.value--; }
}

@Component({
  selector: 'counter-a',
  standalone: true,
  template: `
    <h4>Counter A</h4>
    <p>Value: {{ counter.value }}</p>
    <button (click)="counter.inc()">+1</button>
    <button (click)="counter.dec()">-1</button>
  `
})
export class CounterA {
  constructor(public counter: CounterService) {}
}

@Component({
  selector: 'counter-b',
  standalone: true,
  template: `
    <h4>Counter B</h4>
    <p>Value: {{ counter.value }}</p>
    <button (click)="counter.inc()">+1</button>
    <button (click)="counter.dec()">-1</button>
  `
})
export class CounterB {
  constructor(public counter: CounterService) {}
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CounterA, CounterB],
  template: `
    <h3>Shared Service Across Components</h3>
    <counter-a></counter-a>
    <counter-b></counter-b>
    <p><em>Both components use the same CounterService instance.</em></p>
  `
})
export class Services2Comp {}

bootstrapApplication(Services2Comp);