import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  standalone: true,
  template: `
    <h2>About</h2>
    <p>This is the about page for my Angular app.</p>
  `,
  styles: [`
    :host {
      display: block;
      padding: 1rem;
    }
    h2 {
      color: var(--bright-blue, #007bff);
    }
  `]
})
export class About {}
