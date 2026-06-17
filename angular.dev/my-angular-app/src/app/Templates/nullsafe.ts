import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <button (click)="toggle()">Toggle user</button>
    <p>Email: {{ user?.profile?.email || '(none)' }}</p>
  `
})
export class NullSafe {
  user: { profile?: { email?: string } } | undefined = undefined;
  toggle() {
    this.user = this.user ? undefined : { profile: { email: 'a@example.com' } };
  }
}

bootstrapApplication(NullSafe);