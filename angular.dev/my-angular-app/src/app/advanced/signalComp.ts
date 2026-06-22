import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal, computed, effect } from '@angular/core';
import { App } from '../app';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Signals</h3>
    <p>Count: {{ count() }}</p>
    <p>Double: {{ double() }}</p>
    <button (click)="inc()">Increment</button>
  `
})
export class SignalComp {
  count = signal(0);
  double = computed(() => this.count() * 2);
  constructor() {
    effect(() => console.log('count changed', this.count()));
  }
  inc() { this.count.update(n => n + 1); }
}

bootstrapApplication(SignalComp);