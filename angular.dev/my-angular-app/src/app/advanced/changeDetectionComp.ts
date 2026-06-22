import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal, ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { App } from '../app';

@Component({
  selector: 'app-root',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [CommonModule],
  template: `
    <h3>OnPush + Signals</h3>
    <p>Count: {{ count() }}</p>
    <button (click)="inc()">Increment</button>

    <ul>
      @for (it of items(); track it.id) {
        <li>{{ it.label }}</li>
      }
    </ul>
  `
})
export class ChangeDetectionComp{
  count = signal(0);
  items = signal([{ id: 1, label: 'A' }, { id: 2, label: 'B' }]);
  inc() { this.count.set(this.count() + 1); }
}

bootstrapApplication(ChangeDetectionComp);