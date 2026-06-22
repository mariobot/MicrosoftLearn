import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Control Flow</h3>
    <button (click)="show.set(!show())">Toggle</button>
    <button (click)="items.set([])">Clear</button>
    <button (click)="reset()">Reset</button>

    @if (show()) {
      <p>Visible</p>
    } @else {
      <p>Hidden</p>
    }

    <ul>
      @for (item of items(); track item) {
        <li>{{ item }}</li>
      } @empty {
        <li>No items</li>
      }
    </ul>
  `
})
export class ControlFlowComp {
  show = signal(true);
  items = signal(['One','Two','Three']);
  reset() { this.items.set(['One','Two','Three']); }
}

bootstrapApplication(ControlFlowComp);