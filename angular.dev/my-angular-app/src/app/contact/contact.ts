import { Component } from '@angular/core';

@Component({
  selector: 'app-contact',
  standalone: true,
  template: `
    <h2>Contact</h2>
    <p>This is the contact page for my Angular app.</p>
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
export class Contact {}
