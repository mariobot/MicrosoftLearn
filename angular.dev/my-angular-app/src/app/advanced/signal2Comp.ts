import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal, computed, effect } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Derived & Effects</h3>
    <p>a: {{ a() }} | b: {{ b() }} | sum: {{ sum() }}</p>
    <button (click)="incA()">inc a</button>
    <button (click)="incB()">inc b</button>
  `
})
export class Signal2Comp {
  a = signal(2);
  b = signal(3);
  sum = computed(() => this.a() + this.b());
  constructor() { effect(() => console.log('sum =', this.sum())); }
  incA() { this.a.update(n => n + 1); }
  incB() { this.b.update(n => n + 1); }
}

bootstrapApplication(Signal2Comp);