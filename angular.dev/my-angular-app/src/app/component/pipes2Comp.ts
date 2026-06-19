import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { interval, of } from 'rxjs';
import { map, delay } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>Async Pipe</h3>
    <p>Time: {{ time$ | async | date:'mediumTime' }}</p>

    <h4>Users (delayed)</h4>
    <ng-container *ngIf="users$ | async as users; else loading">
      <ul>
        <li *ngFor="let u of users">{{ u.name }}</li>
      </ul>
    </ng-container>
    <ng-template #loading>Loading...</ng-template>
  `
})
export class Pipes2Comp {
  time$ = interval(1000).pipe(map(() => new Date()));
  users$ = of([{ name: 'Alice' }, { name: 'Bob' }, { name: 'Carol' }]).pipe(delay(1200));
}

bootstrapApplication(Pipes2Comp);