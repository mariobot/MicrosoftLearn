import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Events</h3>
    <p>Count: {{ count }}</p>
    <button (click)="increment()">Click me</button>

    <div style="margin-top:12px">
      <input placeholder="Type..." (input)="onInput($event)" (keyup)="lastKey = $any($event).key">
      <p>Value: {{ value }}</p>
      <p>Last key: {{ lastKey }}</p>
    </div>
  `
})
export class EventsComp {
  count = 0;
  value = '';
  lastKey = '';

  increment() { this.count++; }
  onInput(e: Event) { this.value = (e.target as HTMLInputElement).value; }
}

bootstrapApplication(EventsComp);