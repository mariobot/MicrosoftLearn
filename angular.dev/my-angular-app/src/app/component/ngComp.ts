import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>ngIf with else</h3>

    <button (click)="loggedIn = !loggedIn">
      {{ loggedIn ? 'Log out' : 'Log in' }}
    </button>

    <ng-container *ngIf="loggedIn; else loggedOut">
      <p>Welcome back, {{ user }}!</p>
    </ng-container>

    <ng-template #loggedOut>
      <p>Please log in to continue.</p>
    </ng-template>

    <hr>

    <h4>ngIf then/else syntax</h4>
    <button (click)="hasAccess = !hasAccess">
      Toggle Access ({{ hasAccess ? 'granted' : 'denied' }})
    </button>

    <ng-container *ngIf="hasAccess; then accessTpl; else noAccessTpl"></ng-container>

    <ng-template #accessTpl>
      <p style="color: seagreen">Access granted.</p>
    </ng-template>
    <ng-template #noAccessTpl>
      <p style="color: crimson">Access denied.</p>
    </ng-template>
  `
})
export class NgComp {
  loggedIn = false;
  user = 'Angular User';
  hasAccess = true;
}

bootstrapApplication(NgComp);