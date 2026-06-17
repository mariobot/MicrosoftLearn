import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <button (click)="toggle()">Toggle user</button>
    <p *ngIf="user as u; else empty">Hello {{ u.name }}!</p>
    <ng-template #empty>No user</ng-template>
  `
})
export class Alias {
  user: { name: string } | null = { name: 'Ada' };
  toggle() { this.user = this.user ? null : { name: 'Ada' }; }
}

bootstrapApplication(Alias);