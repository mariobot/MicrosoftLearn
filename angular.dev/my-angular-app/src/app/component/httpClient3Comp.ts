import { bootstrapApplication } from '@angular/platform-browser';
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideHttpClient, HttpClient, withInterceptors, HttpResponse, HttpErrorResponse, HttpRequest, HttpHandlerFn } from '@angular/common/http';
import { of, throwError } from 'rxjs';

// Fake HTTP interceptor so the demo works without external network calls
function mockHttp(req: HttpRequest<any>, next: HttpHandlerFn) {
  if (req.method === 'GET' && req.url.includes('jsonplaceholder.typicode.com/usersx')) {
    return throwError(() => new HttpErrorResponse({ status: 404, statusText: 'Not Found', url: req.url }));
  }
  if (req.method === 'GET' && req.url.includes('jsonplaceholder.typicode.com/users')) {
    const body = [
      { id: 1, name: 'Leanne Graham', email: 'leanne@example.com' },
      { id: 2, name: 'Ervin Howell', email: 'ervin@example.com' }
    ];
    return of(new HttpResponse({ status: 200, body }));
  }
  return next(req);
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    button { margin-right: 8px; }
    .error { color: crimson; }
    .ok { color: seagreen; }
  `],
  template: `
    <h3>HTTP Error Handling</h3>

    <div>
      <button (click)="loadOk()" [disabled]="loading">Load OK</button>
      <button (click)="loadFail()" [disabled]="loading">Load Fail</button>
      <button (click)="retry()" [disabled]="!lastAction || loading">Retry</button>
    </div>

    <p *ngIf="loading">Loading...</p>
    <p *ngIf="error" class="error">{{ error }}</p>
    <p *ngIf="!error && data" class="ok">Loaded {{ isArray(data) ? data.length + ' items' : '1 item' }}</p>

    <ul *ngIf="isArray(data)">
      <li *ngFor="let u of data">{{ u.name }} ({{ u.email }})</li>
    </ul>
  `
})
export class HttpClient3Comp {
  http = inject(HttpClient);
  loading = false;
  error = '';
  data: any[] | null = null;
  lastAction = '';
  isArray(value: unknown): value is any[] { return Array.isArray(value as any); }

  fetch(url: string): void {
    this.loading = true;
    this.error = '';
    this.data = null;
    this.http.get<any[]>(url).subscribe({
      next: (res) => { this.data = res; this.loading = false; },
      error: (err) => {
        const status = err?.status ?? 'unknown';
        this.error = `Request failed (status ${status}). Please try again.`;
        this.loading = false;
      }
    });
  }

  loadOk() {
    this.lastAction = 'ok';
    this.fetch('https://jsonplaceholder.typicode.com/users');
  }

  loadFail() {
    this.lastAction = 'fail';
    this.fetch('https://jsonplaceholder.typicode.com/usersx');
  }

  retry() {
    if (this.lastAction === 'ok') this.loadOk();
    else if (this.lastAction === 'fail') this.loadFail();
  }
}

bootstrapApplication(HttpClient3Comp, { providers: [provideHttpClient(withInterceptors([mockHttp]))] });