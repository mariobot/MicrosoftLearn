import { Component } from '@angular/core';

@Component({
  selector: 'app-contact',
  standalone: true,
  template: `
    <h2>Contact</h2>
    <p>This application is a lab tutorial from W3School from the Angular topic.</p>
    <p>Autor: W3School, developed: Mario Botero </p>
    <p>Content at <a href="https://www.w3schools.com/angular/">W3School Angular</a></p>
    <p>Source code at <a href="https://github.com/mariobot/MicrosoftLearn/tree/master/angular.dev/my-angular-app">https://github.com/mariobot/MicrosoftLearn/tree/master/angular.dev/my-angular-app</a>
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
