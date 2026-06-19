import { bootstrapApplication } from '@angular/platform-browser';
import { Component, inject } from '@angular/core';
import { HttpClient, provideHttpClient, withInterceptors, HttpResponse, HttpRequest, HttpHandlerFn } from '@angular/common/http';
import { of } from 'rxjs';
import { JsonPipe } from '@angular/common';

const logInterceptor = (req: HttpRequest<any>, next: HttpHandlerFn) => {
    console.log('Request', req.method, req.url);
    return next(req);
};

// Mock interceptor so the demo runs without external network
const mockInterceptor = (req: HttpRequest<any>, next: HttpHandlerFn) => {
    if (req.method === 'GET' && req.url.includes('jsonplaceholder.typicode.com/todos/1')) {
        const body = { id: 1, title: 'Mocked todo', completed: false };
        return of(new HttpResponse({ status: 200, body }));
    }
    return next(req);
};

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [JsonPipe],
    template: `
    <h3>HTTP Interceptor</h3>
    <button (click)="load()">Load</button>
    <pre>{{ data | json }}</pre>
  `
})
export class HttpClient4Comp {
    #http = inject(HttpClient);
    data: any;
    load() {
        this.#http.get('https://jsonplaceholder.typicode.com/todos/1').subscribe(r => this.data = r);
    }
}

bootstrapApplication(HttpClient4Comp, { providers: [provideHttpClient(withInterceptors([mockInterceptor, logInterceptor]))] });

