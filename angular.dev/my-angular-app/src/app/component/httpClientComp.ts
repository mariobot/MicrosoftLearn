import { bootstrapApplication } from '@angular/platform-browser';
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideHttpClient, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>HttpClient</h3>
    <button (click)="load()">Load Users</button>
    <p *ngIf="loading">Loading...</p>
    <p *ngIf="error" style="color:crimson">{{ error }}</p>
    <ul>
      <li *ngFor="let u of users">{{ u.name }} ({{ u.email }})</li>
    </ul>
  `
})
export class HttpClientComp {
  http = inject(HttpClient);
  users: any[] = [];
  loading = false;
  error = '';

  load() {
    this.loading = true;
    this.error = '';
    this.http.get<any[]>('https://jsonplaceholder.typicode.com/users')
      .subscribe({
        next: (data) => { this.users = data; this.loading = false; },
        error: () => { this.error = 'Failed to load users'; this.loading = false; }
      });
  }
}

bootstrapApplication(HttpClientComp, { providers: [provideHttpClient()] });