import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    .toolbar { display: flex; gap: 8px; align-items: center; flex-wrap: wrap; }
    input { padding: 6px 8px; }
  `],
  template: `
    <h3>Template Reference Variables (#var)</h3>
    <div class="toolbar">
      <input #box type="text" placeholder="Type something" (input)="current = box.value" />
      <button (click)="read(box.value)">Read value</button>
      <button (click)="box.focus()">Focus input</button>
      <span style="margin-left:8px;color:#666">length={{ box.value.length || 0 }}</span>
    </div>
    <p>Current: {{ current || '(empty)' }}</p>
  `
})
export class Reference {
  current = '';
  read(val: string) { this.current = val ?? ''; }
}

bootstrapApplication(Reference);