import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CounterService {
  value = 0;
  inc() { this.value++; }
  dec() { this.value--; }
  reset() { this.value = 0; }
}

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Services</h3>
    <p>Counter: {{ counter.value }}</p>
    <button (click)="counter.inc()">+</button>
    <button (click)="counter.dec()">-</button>
    <button (click)="counter.reset()">Reset</button>
  `
})
export class Services2Comp {
  constructor(public counter: CounterService) {}
}

bootstrapApplication(Services2Comp);