import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <button (click)="ok = !ok">Toggle</button>
    <div *ngIf="ok; else other">OK</div>
    <ng-template #other>Not OK</ng-template>
    <ul>
      <li *ngFor="let item of items; index as i">{{ i }} - {{ item }}</li>
    </ul>
  `
})
export class StructuralDirectives {
  ok = true;
  items = ['A','B','C'];
}

bootstrapApplication(StructuralDirectives);