import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    .toolbar { display: flex; gap: 8px; align-items: center; flex-wrap: wrap; }
    ul { margin-top: 10px; }
    li { line-height: 1.8; }
    input[type="text"] { padding: 6px 8px; }
  `],
  template: `
    <h3>Event Filtering (keyup.enter)</h3>

    <div class="toolbar">
      <input type="text" placeholder="Add item and press Enter"
             [value]="draft"
             (input)="draft = $any($event.target).value"
             (keyup)="lastKey = $any($event).key"
             (keyup.enter)="add()">
      <button (click)="add()">Add</button>
      <button (click)="clear()" [disabled]="items.length === 0">Clear</button>
      <span style="margin-left:8px;color:#666">Last key: {{ lastKey }}</span>
    </div>

    <ul>
      <li *ngFor="let it of items; let i = index">{{ i + 1 }}. {{ it }}</li>
    </ul>
  `
})
export class Events2Comp {
  draft = '';
  lastKey = '';
  items = ['Buy milk', 'Learn Angular'];

  add() {
    const v = (this.draft || '').trim();
    if (!v) return;
    this.items = [...this.items, v];
    this.draft = '';
  }
  clear() { this.items = []; }
}

bootstrapApplication(Events2Comp);