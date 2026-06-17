import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'counter-button',
  standalone: true,
  template: `
    <button (click)="inc()">Clicked {{ count }} times</button>
  `
})
export class CounterButton {
  @Input() step = 1;
  @Output()
  /** @type {import('@angular/core').EventEmitter<number>} */
  clicked = new EventEmitter();
  count = 0;
  inc() {
    this.count += this.step;
    this.clicked.emit(this.count);
  }
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CounterButton],
  template: `
    <h3>Component Output</h3>
    <counter-button [step]="2" (clicked)="onChildClicked($event)"></counter-button>
    <p>Parent received: {{ lastCount }}</p>
  `
})
export class OutputComponent {
  lastCount = 0;
  /** @param {number} n */
  onChildClicked(n: number) {
    this.lastCount = n;
  }
}

bootstrapApplication(OutputComponent);