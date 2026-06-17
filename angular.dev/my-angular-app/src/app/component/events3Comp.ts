import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Debounced Input</h3>
    <input type="text" placeholder="Type here" (input)="onInput($event)">
    <p>Immediate: {{ immediate }}</p>
    <p>Debounced (400ms): {{ debounced }}</p>
  `
})
export class Events3Comp {
  immediate = '';
  debounced = '';
  private handle: any;

  onInput(e: Event) {
    const v = (e.target as HTMLInputElement)?.value ?? '';
    this.immediate = v;
    clearTimeout(this.handle);
    this.handle = setTimeout(() => this.debounced = v, 400);
  }
}

bootstrapApplication(Events3Comp);