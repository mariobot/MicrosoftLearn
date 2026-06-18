import { bootstrapApplication } from '@angular/platform-browser';
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideHttpClient, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>HttpClient POST</h3>
    <button (click)="createPost()" [disabled]="loading">Create Post</button>
    <p *ngIf="loading">Sending...</p>
    <p *ngIf="error" style="color:crimson">{{ error }}</p>
    <div *ngIf="result">
      <p>Created Post ID: {{ result.id }}</p>
      <p>Title: {{ result.title }}</p>
    </div>
  `
})
export class HttpClient2Comp {
  http = inject(HttpClient);
  loading = false;
  error = '';
  result: any = null;

  createPost() {
    this.loading = true;
    this.error = '';
    this.result = null;
    this.http.post<any>('https://jsonplaceholder.typicode.com/posts', {
      title: 'foo',
      body: 'bar',
      userId: 1
    }).subscribe({
      next: (res) => { this.result = res; this.loading = false; },
      error: () => { this.error = 'Failed to create post'; this.loading = false; }
    });
  }
}

bootstrapApplication(HttpClient2Comp, { providers: [provideHttpClient()] });